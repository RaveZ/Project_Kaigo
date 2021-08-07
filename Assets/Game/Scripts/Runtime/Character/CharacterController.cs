using Kaigo.Runtime.Camera;
using Kaigo.Runtime.Character.AI;
using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Setting;
using Kaigo.Runtime.Character.Stat;
using UnityEngine;
using Z.CharacterLocomotion.Runtime;
using Z.SmoothUpdate.Runtime;
using Z.TargetLock.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	using ICTPFocusedObject = Z.CameraThirdPerson.Runtime.IFocusedObject;
	using ILocoFocusedObject = IFocusedObject;
	using UCharacterController = UnityEngine.CharacterController;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (UCharacterController), typeof (SmoothUpdateHandler))]
	[RequireComponent (typeof (CharacterStat), typeof (CharacterSetting))]
	[RequireComponent (typeof (LocomotionHandler), typeof (AnimationHandler), typeof (TargetLockHandler))]
	internal partial class CharacterController : MonoBehaviour, ITransform, ILocoFocusedObject, ICTPFocusedObject, ITargetable
	{
		[Header ("References")]
		[SerializeField]
		private UCharacterController _ucharController = null;
		[field: SerializeField]
		internal SmoothUpdateHandler SmoothUpdtHandler { get; private set; } = null;

		[SerializeField]
		private Transform _camTargetTransform = null;
		[SerializeField]
		private Animator _anim = null;
		[SerializeField]
		private CharacterStat _stat = null;
		[SerializeField]
		private CharacterSetting _charSetting = null;
		[SerializeField]
		private LocomotionHandler _locoHandler = null;
		[SerializeField]
		private AnimationHandler _animHandler = null;
		[SerializeField]
		private TargetLockHandler _lockHandler = null;
		[SerializeField]
		private AnimationEventHandler _animEventHandler = null;
		[SerializeField]
		private NoInputHandler _noInputHandler = null;
		[SerializeField]
		private Renderer [] _renderers = null;

		private BaseInputHandler _inputHandler = null;
		private ICameraTransform _camTransform = null;
		private ICamera _cam = null;

		private bool _isInitialized = false;

		internal bool IsInputFromUser { get; private set; } = false;

		internal void Init (CharacterPreset charPreset, ICameraTransform camTransform, ICamera cam)
		{
			_camTransform = camTransform;
			_cam = cam;

			Init (charPreset);
		}

		internal void Init (CharacterPreset charPreset)
		{
			if (charPreset != null)
			{
				_inputHandler = (BaseInputHandler) ScriptableObject.CreateInstance (charPreset.InputHandler.GetType ());
				IsInputFromUser = typeof (UserInputHandler).IsAssignableFrom (_inputHandler.GetType ());

				_charSetting.Init (IsInputFromUser, charPreset.InitialSetting);

				if (IsInputFromUser)
					((UserInputHandler) _inputHandler).Init ();
				else
					((AIInputHandler) _inputHandler).Init (new AIInputHandlerInitialPayload
					{
						ControlledObj = gameObject,
						SpawnPos = transform.position,
						UCharController = _ucharController,
						AISetting = charPreset.AISetting,
						AIStat = charPreset.AIStat,
						BrainHandler = (BaseBrainHandler) ScriptableObject.CreateInstance (charPreset.BrainHandler.GetType ())
					});

				_stat.Init (charPreset.InitialStat);

				DebugInitInput (IsInputFromUser);
			}
			else
			{
				_inputHandler = _noInputHandler;
				_charSetting.Init (false, charPreset.InitialSetting);
				_stat.Init (null);
			}

			Init ();

			_isInitialized = true;
		}

		private void Init ()
		{
			_lockHandler.Init (_charSetting, this);
			_locoHandler.Init (new LocomotionHandlerInitialPayload
			{
				CamTransform = _camTransform,
				InputAxis = _inputHandler,
				FocusedObject = this,
				LocoSetting = _charSetting,
				Stat = _stat,
				UCharController = _ucharController
			});
			_animHandler.Init (_anim, _locoHandler, _stat);
			_animEventHandler.Init (_anim);

			_inputHandler.OnActivateTargetLockTriggerd += _lockHandler.ActivateTargetLock;
			_inputHandler.OnDeactivateTargetLockTriggerd += _lockHandler.DeactivateTargetLock;

			_isInitialized = true;
		}

		private void OnDestroy ()
		{
			_inputHandler = null;
			_camTransform = null;
			_cam = null;
		}

		private void FixedUpdate ()
		{
			if (!_isInitialized)
				return;

			_locoHandler.HandleFixedUpdate ();
		}

		private void Update ()
		{
			if (!_isInitialized)
				return;

			_inputHandler.HandleUpdate ();
			_animHandler.HandleUpdate ();
		}

		private Bounds GetBounds ()
		{
			bool isBoundsInitialized = false;
			Bounds bounds = new Bounds ();
			foreach (Renderer renderer in _renderers)
			{
				if (!renderer.enabled)
					continue;

				if (isBoundsInitialized)
					bounds.Encapsulate (renderer.bounds);
				else
				{
					isBoundsInitialized = true;
					bounds = renderer.bounds;
				}
			}

			return bounds;
		}
	}
}
