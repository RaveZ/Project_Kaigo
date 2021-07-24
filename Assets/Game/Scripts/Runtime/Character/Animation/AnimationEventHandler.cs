using Z.DeterministicAnimationEvent.Runtime;

namespace Kaigo.Runtime.Character.Animation
{
	internal class AnimationEventHandler : BaseAnimationEventHandler
	{
		internal delegate void SetMovabilityAction (bool isEnable);
		internal delegate void SetTurnabilityAction (bool isEnable);
		internal delegate void SnapDirectionAction ();
		internal delegate void EnableAttackAction ();
		internal delegate void AttackComboAction ();
		internal delegate void ResetComboAction ();

		internal event SetMovabilityAction OnSetMovabilityTriggered = null;
		internal event SetTurnabilityAction OnSetTurnabilityTriggered = null;
		internal event SnapDirectionAction OnSnapDirectionTriggered = null;
		internal event EnableAttackAction OnEnableAttackTriggered = null;
		internal event AttackComboAction OnAttackComboTriggered = null;
		internal event ResetComboAction OnResetComboTriggered = null;

		private int _movabilityAnimID = -1;
		private int _turnabilityAnimID = -1;
		private int _attackabilityAnimID = -1;

		public void AnimEventDisableMove (int id)
		{
			_movabilityAnimID = id;
			OnSetMovabilityTriggered?.Invoke (false);
		}

		public void AnimEventEnableMove (int id)
		{
			if (_movabilityAnimID == id || id < 0)
				OnSetMovabilityTriggered?.Invoke (true);
		}

		public void AnimEventDisableTurn (int id)
		{
			_turnabilityAnimID = id;
			OnSetTurnabilityTriggered?.Invoke (false);
		}

		public void AnimEventEnableTurn (int id)
		{
			if (_turnabilityAnimID == id || id < 0)
				OnSetTurnabilityTriggered?.Invoke (true);
		}

		internal void AnimEventDisableAttack (int id)
		{
			_attackabilityAnimID = id;
		}

		public void AnimEventEnableAttack (int id)
		{
			if (_attackabilityAnimID == id || id < 0)
				OnEnableAttackTriggered.Invoke ();
		}

		public void AnimEventSnapDirection (int id)
		{
			OnSnapDirectionTriggered?.Invoke ();
		}

		public void AnimEventAttackCombo (int id)
		{
			OnAttackComboTriggered.Invoke ();
		}

		public void AnimEventResetCombo (int id)
		{
			if (_attackabilityAnimID == id || id < 0)
				OnResetComboTriggered.Invoke ();
		}
	}
}
