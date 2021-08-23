using UnityEngine;
using Z.CharacterLocomotion.Runtime;

namespace Kaigo.Runtime.Character.Input
{
	internal abstract class BaseInputHandler : ScriptableObject, IInputAxis
	{
		internal delegate void ActivateTargetLockAction ();
		internal delegate void DeactivateTargetLockAction ();
		internal delegate void AttackAction ();
		internal delegate void JumpAction ();

		internal event ActivateTargetLockAction OnActivateTargetLockTriggerd = null;
		internal event DeactivateTargetLockAction OnDeactivateTargetLockTriggerd = null;
		internal event AttackAction OnAttackTriggered = null;
		internal event JumpAction OnJumpTriggered = null;

		protected bool IsTargetLockOn = false;

		public bool IsInitialized { get; protected set; } = false;
		public bool IsSprinting { get; protected set; } = false;
		public bool CanAttack { get; protected set; } = false;
		public float Horizontal { get; protected set; } = 0f;
		public float Vertical { get; protected set; } = 0f;

		internal virtual void HandleUpdate () { }

		protected void InvokActivateTargetLockAction ()
		{
			OnActivateTargetLockTriggerd.Invoke ();
		}

		protected void InvokeDeactivateTargetLockAction ()
		{
			OnDeactivateTargetLockTriggerd.Invoke ();
		}

		protected void InvokeAttackAction ()
		{
			OnAttackTriggered.Invoke ();
		}

		protected void InvokeJumpAction ()
		{
			OnJumpTriggered.Invoke ();
		}
	}
}
