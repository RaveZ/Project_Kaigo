using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Stat;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Setting;
using UnityEngine;
using Z.CharacterLocomotion.Runtime;
using Z.SmoothUpdate.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	using UCharacterController = UnityEngine.CharacterController;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (UCharacterController), typeof (SmoothUpdateHandler))]
	[RequireComponent (typeof (CharacterStat), typeof (CharacterSetting))]
	[RequireComponent (typeof (LocomotionHandler), typeof (AnimationHandler))]
	internal partial class CharacterController : MonoBehaviour, ITransform
	{
		[Header ("References")]
		[SerializeField]
		private UCharacterController _ucharController = null;
		[field: SerializeField]
		internal SmoothUpdateHandler SmoothUpdtHandler { get; private set; } = null;
		[SerializeField]
		private Transform _camTTargetransform = null;
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
		private AnimationEventHandler _animEventHandler = null;
		[SerializeField]
		private NoInputHandler _noInputHandler = null;

		private BaseInputHandler _inputHandler = null;
		private ICameraTransform _camTransform = null;

		private bool _isInitialized = false;

		internal void Init (CharacterPreset charPreset, ICameraTransform camTransform)
		{
			_camTransform = camTransform;

			Init (charPreset);
		}

		internal void Init (CharacterPreset charPreset)
		{
			if (charPreset != null)
			{
				_inputHandler = charPreset.InputHandler;
				bool isInputFromUser = typeof (UserInputHandler).IsAssignableFrom (_inputHandler.GetType ());

				_charSetting.Init (isInputFromUser, charPreset.InitialSetting);

				if (isInputFromUser)
					((UserInputHandler) _inputHandler).Init ();
				else
					((AIInputHandler) _inputHandler).Init (new AIInputHandlerInitialPayload
					{
						ControlledObj = gameObject,
						SpawnPos = transform.position,
						UCharController = _ucharController,
						AISetting = charPreset.AISetting,
						AIStat = charPreset.AIStat,
						BrainHandler = charPreset.BrainHandler
					});

				_stat.Init (charPreset.InitialStat);
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
			_locoHandler.Init (new LocomotionHandlerInitialPayload
			{
				CamTransform = _camTransform,
				InputAxis = _inputHandler,
				InputLockOn = _inputHandler,
				LocoSetting = _charSetting,
				Stat = _stat,
				UCharController = _ucharController
			});
			_animHandler.Init (_anim, _locoHandler, _stat);
			_animEventHandler.Init (_anim);

			_isInitialized = true;
		}

		private void FixedUpdate ()
		{
			if (!_isInitialized)
				return;

			_locoHandler.OnFixedUpdate ();
		}

		private void Update ()
		{
			if (!_isInitialized)
				return;

			_inputHandler.OnUpdate ();
			_animHandler.OnUpdate ();
		}
	}
}
