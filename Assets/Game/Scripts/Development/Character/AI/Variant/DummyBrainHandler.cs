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
			BTree = new BehaviorTreeBuilder (ControlledObj)
				.Selector ("Actions selector")
					.Decorator ("No target", MustHasNoTarget)
						.Selector ("Idle")
							.Sequence ("Move to spawn position")
								.Condition ("Not in post area", NotInSpawnArea)
								.Do ("Move to post area", MoveToSpawnArea)
								.Do ("Wait till arrive at post area", WaitTillArriveAtSpawnArea)
							.End ()
							.Do ("Wait idle", WaitIdle)
						.End ()
					.End ()
					.Selector ("Attack")
						//.Condition ("Has target", HasTarget)
						//.RepeatUntilSuccess ("Until target chased")
						.Decorator ("Until target chased", MustInTargetRadius)
							.Sequence ("Chase target")
								//.Condition ("Not in target area", NotInTargetArea)
								.Do ("Move to target area", MoveToTarget)
								.Do ("Wait to recalculate path to target area", WaitToRecalculatePathToTarget)
							//.Condition ("In target area", InTargetArea)
							.End ()
						.End ()
						.Do ("Wait Attack", WaitIdle)
					.End ()
				.End ()
			.Build ();
		}
	}
}
