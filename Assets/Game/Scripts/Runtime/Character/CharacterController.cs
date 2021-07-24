using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Attribute;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Movement.Locomotion;
using UnityEngine;

namespace Kaigo.Runtime.Character
{
	using UCharacterController = UnityEngine.CharacterController;

	[RequireComponent (typeof (UCharacterController))]
	[RequireComponent (typeof (StatAttribute), typeof (LocomotionHandler))]
	[RequireComponent (typeof (AnimationEventHandler), typeof (AnimationHandler))]
	internal partial class CharacterController : MonoBehaviour
	{
		internal enum InputType
		{
			User,
			AI
		}

		[Header ("References")]
		[SerializeField]
		private UCharacterController _ucharController = null;
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
		private bool _isInitialized = false;

		internal void Init (CharacterPreset charPreset)
		{
			_statAttribute = charPreset.StatAttribute;
			_charSetting = charPreset.CharSetting;

			_isInitialized = true;
		}

		internal void Init (CharacterPreset charPreset, InputType inputType)
		{
			_statAttribute = charPreset.StatAttribute;
			_charSetting = charPreset.CharSetting;
		}

		private void Init ()
		{
			InitInput ();
			_statAttribute.Init ();
			_locoHandler.Init (new LocomotionHandlerInitialPayload
			{
				CamTransform = null,
				Input = _inputHandler,
				LocoSetting = _charSetting,
				StatAttribute = _statAttribute,
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
