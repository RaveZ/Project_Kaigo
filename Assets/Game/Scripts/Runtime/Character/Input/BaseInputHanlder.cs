using UnityEngine;

namespace Kaigo.Runtime.Character.Input
{
	internal abstract class BaseInputHanlder : MonoBehaviour, IInput
	{
		internal delegate void AttackAction ();
		internal delegate void JumpAction ();

		internal event AttackAction OnAttackTriggered = null;
		internal event JumpAction OnJumpTriggered = null;

		public bool IsInitialized { get; protected set; }
		public bool IsSprinting { get; protected set; }
		public float MoveH { get; protected set; }
		public float MoveV { get; protected set; }

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
