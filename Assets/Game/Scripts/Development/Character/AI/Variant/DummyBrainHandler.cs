using CleverCrow.Fluid.BTs.Trees;
using Kaigo.Runtime.Character.AI;
using UnityEngine;

namespace Kaigo.Development.Character.AI.Variant
{
	[CreateAssetMenu (fileName = "DummyBrain", menuName = "Kaigo/Character/Brain/Dummy")]
	internal class DummyBrainHandler : BaseBrainHandler
	{
		protected override void InitBrain ()
		{
			BTree = new BehaviorTreeBuilder(ControlledObj)
				.Selector("Actions selector")
					.Decorator("No target", MustHasNoTarget)
						.Selector("Idle")
							.Sequence("Move to spawn position")
								.Condition("Not in spawn area", NotInSpawnArea)
								.Do("Move to spawn area", MoveToSpawnArea)
								.Do("Wait till arrive at spawn area", WaitTillArriveAtSpawnArea)
							.End()
							.Do("Wait idle", WaitIdle)
						.End()
					.End()
					.Selector("Player Detected")
						//.Condition ("Has target", HasTarget)
						//.RepeatUntilSuccess ("Until target chased")
						.Decorator("Until target chased", NotInTargetRadius)// decorator if fail then go to next decorator
							.Sequence("Chase target")
								//.Condition ("Not in target area", NotInTargetArea)
								.Do("Move to target area", MoveToTarget)
								.Do("Wait to recalculate path to target area", WaitToRecalculatePathToTarget)
							//.Condition ("In target area", InTargetArea)
							.End()
						.End()
						.Sequence("Attack")
							.Sequence("Observe Sequence")
								.Condition("InObserveRadius", InObserveArea)
								.Do("Stop in Place", StopAgent)
							.End()
						.End ()
						/*.Sequence("Observe Target")
							.Condition("Not in target area", NotInTargetArea)
							.Do("Move to target area", MoveToTarget)
							.Do("Wait to recalculate path to target area", WaitToRecalculatePathToTarget)
						.End()*/

					/*.Decorator("Target must in radius", InTargetRadius)
						.Sequence("Attack target")
						.End()
					.End()*/
					.End()
				.End ()
			.Build ();
		}
	}
}
