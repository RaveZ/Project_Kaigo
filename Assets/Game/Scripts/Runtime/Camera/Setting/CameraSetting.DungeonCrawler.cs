using System;
using UnityEngine;
using Z.CameraDungeonCrawler.Runtime;

namespace Kaigo.Runtime.Camera.Setting
{
	internal partial class CameraSetting
	{
		[Serializable]
		internal class DungeonCrawlerSetting : IMovementSetting
		{
			[field: SerializeField]
			[field: Min (0f)]
			public float MoveSpeed { get; private set; } = 0.2f;
			[field: SerializeField]
			[field: Min (0f)]
			public float LookSpeed { get; private set; } = 2f;
			[field: SerializeField]
			public float CamOffsetY { get; private set; } = 10f;
			[field: SerializeField]
			[field: Min (0f)]
			public float CamOffsetZ { get; private set; } = 10f;
			[field: SerializeField]
			[field: Min (0f)]
			public float CamPitchAngle { get; private set; } = 10f;
		}
	}
}
