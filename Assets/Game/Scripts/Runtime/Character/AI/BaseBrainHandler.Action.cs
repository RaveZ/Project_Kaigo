using CleverCrow.Fluid.BTs.Tasks;
using UnityEngine;
using UnityEngine.AI;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Character.AI
{
	internal abstract partial class BaseBrainHandler : ScriptableObject, ITimerLimit
	{
		protected TaskStatus MoveToSpawnArea ()
		{
			if (NotInDestArea (Blackboard.SpawnPosition))
				MoveTo (Blackboard.SpawnPosition);

			return TaskStatus.Success;
		}

		protected TaskStatus MoveToTarget ()
		{
			if (NotInDestArea (Blackboard.Target.transform.position))
				MoveTo (Blackboard.Target.transform.position);

			return TaskStatus.Success;
		}

		protected TaskStatus WaitIdle ()
		{
			return Wait (Stat.IdleTime);
		}

		protected TaskStatus WaitToRecalculatePathToTarget ()
		{
			return Wait (Setting.WaitTimeForRecalculatePath);
		}

		protected TaskStatus WaitTillArriveAtSpawnArea ()
		{
			return WaitTillArriveAtDestination (Blackboard.SpawnPosition);
		}

		protected TaskStatus WaitTillArriveAtDestination (Vector3 destination)
		{
			if (GetPathStatus () == NavMeshPathStatus.PathInvalid || GetPathStatus () == NavMeshPathStatus.PathPartial)
				return TaskStatus.Failure;

			if (NotInDestArea (destination))
				return TaskStatus.Continue;

			return TaskStatus.Success;
		}

		protected TaskStatus Wait (float time)
		{
			TimeLimit = time;
			Timer.Restart ();

			return TaskStatus.Success;
		}
	}
}
