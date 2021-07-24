using UnityEngine;

namespace Z.CameraThirdPerson.Runtime
{
	public interface IMovementSetting
	{
		float MoveSpeed { get; }
		float LookSpeed { get; }
		float DistanceLength { get; }
		float MinTargetDistance { get; }
		float MinPitchAngle { get; }
		float MaxPitchAngle { get; }
		float CamCollisionRadius { get; }
		float CamCollisionOffset { get; }
		float CamMinCollisionOffset { get; }
		float CamCollisionJumpSmoothSpeed { get; }
		LayerMask CamCollisionLayer { get; }
		bool InvertY { get; }
	}
}
