using UnityEngine;
using Z.UnityHelper.Input;

namespace Kaigo.Runtime.Character.Input
{
	internal abstract class BaseInputHanlder : MonoBehaviour, IInputAxis
	{
		internal delegate void AttackAction ();
		internal delegate void JumpAction ();

		internal event AttackAction OnAttackTriggered = null;
		internal event JumpAction OnJumpTriggered = null;

		public bool IsInitialized { get; protected set; }
		public bool IsSprinting { get; protected set; }
		public float Horizontal { get; protected set; }
		public float Vertical { get; protected set; }

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
