using UnityEngine;
using Z.UnityHelper.Input;

namespace Kaigo.Runtime.Character.Input
{
	internal abstract class BaseInputHandler : ScriptableObject, IInputAxis, IInputLockOn
	{
		internal delegate void AttackAction ();
		internal delegate void JumpAction ();

		internal event AttackAction OnAttackTriggered = null;
		internal event JumpAction OnJumpTriggered = null;

		public bool IsInitialized { get; protected set; } = false;
		public bool IsSprinting { get; protected set; } = false;
		public bool IsLockOn { get; protected set; } = false;
		public float Horizontal { get; protected set; } = 0f;
		public float Vertical { get; protected set; } = 0f;

		internal virtual void OnUpdate () { }

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
