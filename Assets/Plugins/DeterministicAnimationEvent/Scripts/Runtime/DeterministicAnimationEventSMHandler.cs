using UnityEngine;

namespace Z.DeterministicAnimationEvent.Runtime
{
	[SharedBetweenAnimators]
	public class DeterministicAnimationEventSMHandler : StateMachineBehaviour
	{
		[SerializeField]
		private AnimationClip _clip = null;

		public override void OnStateExit (Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
		{
			if (animator.TryGetComponent (out BaseAnimationEventHandler animEventHdlr))
				animEventHdlr.ExecuteAllSkippedEventsInAnimatorStateInfo (_clip, animatorStateInfo.normalizedTime);
		}
	}
}
