using Kaigo.Generated.Input;
using UnityEngine;

namespace Kaigo.Runtime.Character.Input
{
	using static UnityEngine.InputSystem.InputAction;

	[CreateAssetMenu (fileName = "UserInput", menuName = "Kaigo/Character/Input Handler/User")]
	internal class UserInputHandler : BaseInputHandler
	{
		private CharacterInput _charInput;

		internal void Init ()
		{
			_charInput = new CharacterInput ();

			_charInput.Game.Movement.performed += MovementPerformed;
			_charInput.Game.Sprint.started += SprintStarted;
			_charInput.Game.Sprint.canceled += SprintCanceled;
			_charInput.Game.Attack.performed += MovementPerformed;
			_charInput.Game.Jump.performed += MovementPerformed;
			_charInput.Game.ToggleTargetLock.performed += ToggleTargetLockPerformed;

			_charInput.Enable ();

			IsInitialized = true;
		}

		private void OnEnable ()
		{
			if (IsInitialized)
				_charInput?.Enable ();
		}

		private void OnDisable ()
		{
			if (IsInitialized)
				_charInput?.Disable ();
		}

		private void OnDestroy ()
		{
			if (IsInitialized)
				_charInput?.Dispose ();
		}

		private void MovementPerformed (CallbackContext context)
		{
			Vector2 moveInput = context.ReadValue<Vector2> ();
			Horizontal = moveInput.x;
			Vertical = moveInput.y;
		}

		private void SprintStarted (CallbackContext context)
		{
			IsSprinting = true;
		}

		private void SprintCanceled (CallbackContext context)
		{
			IsSprinting = false;
		}

		private void AttackPerformed (CallbackContext context)
		{
			InvokeAttackAction ();
		}

		private void JumpPerformed (CallbackContext context)
		{
			InvokeJumpAction ();
		}

		private void ToggleTargetLockPerformed(CallbackContext context)
		{
			IsTargetLockOn = !IsTargetLockOn;
			if (IsTargetLockOn)
				InvokActivateTargetLockAction ();
			else
				InvokeDeactivateTargetLockAction ();
		}
	}
}
