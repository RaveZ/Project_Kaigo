using UnityEngine;

namespace Kaigo.Runtime.Character.AI
{
	internal abstract partial class BaseBrainHandler
	{
		protected bool HasTarget ()
		{
			return Blackboard.Target != null;
		}

		protected bool NoTarget ()
		{
			return !HasTarget ();
		}

		protected bool InSpawnArea ()
		{
			return Vector3.Distance (ControlledObj.transform.position, Blackboard.SpawnPosition) <= Setting.StoppingDistance;
		}

		protected bool NotInSpawnArea ()
		{
			return !InSpawnArea ();
		}

		protected bool InDestArea (Vector3 destPos)
		{
			return Vector3.Distance (ControlledObj.transform.position, destPos) <= Setting.StoppingDistance;
		}

		protected bool NotInDestArea (Vector3 destPos)
		{
			return !InDestArea (destPos);
		}
	}
}
