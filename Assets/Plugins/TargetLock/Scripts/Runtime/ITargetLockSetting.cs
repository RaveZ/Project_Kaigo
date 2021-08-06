using UnityEngine;

namespace Z.TargetLock.Runtime
{
	public interface ITargetLockSetting
	{
		int AllocationCount { get; }
		float Radius { get; }
		LayerMask Layer { get; }
		QueryTriggerInteraction TriggerInteraction { get; }
	}
}

