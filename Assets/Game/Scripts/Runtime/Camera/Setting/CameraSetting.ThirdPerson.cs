using System;
using UnityEngine;
using Z.CameraThirdPerson.Runtime;

namespace Kaigo.Runtime.Camera.Setting
{
	internal partial class CameraSetting
	{
		[Serializable]
		internal class ThirdPersonSetting : IMovementSetting
		{
			[field: SerializeField]
			[field: Min (0f)]
			public float MoveSpeed { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Min (0f)]
			public float LookSpeed { get; private set; } = 2f;
			[field: SerializeField]
			[field: Min (0f)]
			public float DistanceLength { get; private set; } = 3f;
			[field: SerializeField]
			[field: Min (0f)]
			public float MinTargetDistance { get; private set; } = 1.5f;
			[field: SerializeField]
			[field: Range (-90f, 90f)]
			public float MinPitchAngle { get; private set; } = -35f;
			[field: SerializeField]
			[field: Range (-90f, 90f)]
			public float MaxPitchAngle { get; private set; } = 35f;
			[field: SerializeField]
			[field: Min (0f)]
			public float CamCollisionRadius { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Min (0f)]
			[field: Tooltip ("How much the camera will jump off of objects its colliding with")]
			public float CamCollisionOffset { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Min (0f)]
			[field: Tooltip ("Minimum distance for camera to jump off when collide")]
			public float CamMinCollisionOffset { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Range (0.1f, 0.9f)]
			public float CamCollisionJumpSmoothSpeed { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Tooltip ("The layer for the camera to detect collision")]
			public LayerMask CamCollisionLayer { get; private set; } = default;
			[field: SerializeField]
			public bool InvertY { get; private set; } = false;
		}
	}
}
