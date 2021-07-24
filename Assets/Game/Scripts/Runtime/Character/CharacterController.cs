using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Attribute;
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
	[RequireComponent (typeof (StatAttribute), typeof (CharacterSetting))]
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
		private StatAttribute _statAttribute = null;
		[SerializeField]
		private CharacterSetting _charSetting = null;
		[SerializeField]
		private LocomotionHandler _locoHandler = null;
		[SerializeField]
		private AnimationHandler _animHandler = null;
		[SerializeField]
		private AnimationEventHandler _animEventHandler = null;
		[SerializeField]
		private InputType _inputType = InputType.User;

		private BaseInputHanlder _inputHandler = null;
		private ICameraTransform _camTransform = null;

		private bool _isInitialized = false;

		internal void Init (CharacterPreset charPreset, ICameraTransform camTransform, InputType inputType)
		{
			_camTransform = camTransform;
			_inputType = inputType;

			Init (charPreset);
		}

		internal void Init (CharacterPreset charPreset)
		{
			if (charPreset != null)
			{
				_charSetting.Init (_inputType, charPreset.InitialCharSetting);
				_statAttribute.Init (charPreset.InitialStatAttribute);
			}

			Init ();

			_isInitialized = true;
		}

		private void Init ()
		{
			InitInput ();
			_statAttribute.Init ();
			_locoHandler.Init (new LocomotionHandlerInitialPayload
			{
				CamTransform = _camTransform,
				InputAxis = _inputHandler,
				LocoSetting = _charSetting,
				Stat = _statAttribute,
				UCharController = _ucharController
			});
			_animHandler.Init (_anim, _locoHandler, _statAttribute);
			_animEventHandler.Init (_anim);

			_isInitialized = true;
		}

		private void InitInput()
		{
			if (_inputType == InputType.User)
			{
				UserInputHanlder userInputHandler = gameObject.AddComponent<UserInputHanlder> ();
				userInputHandler.Init ();
				_inputHandler = userInputHandler;
			}
			else
			{

			}
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

			_animHandler.OnUpdate ();
		}
	}
}
