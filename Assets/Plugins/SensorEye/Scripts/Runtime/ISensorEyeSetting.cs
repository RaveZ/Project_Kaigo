using UnityEngine;

namespace Z.SensorEye.Runtime
{
	public interface ISensorEyeSetting
	{
		LayerMask TargetLayer { get; }
		LayerMask ObstructLayer { get; }
		float FrontDotLimit { get; }
		float UpdateMaxTime { get; }
		float LineOfSightHeight { get; }
	}
}
