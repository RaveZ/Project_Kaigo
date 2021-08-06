using System;
using UnityEngine;
using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Setting
{
	internal partial class AISetting : ScriptableObject
	{
		[Serializable]
		internal class SensorEyeSetting : ISensorEyeSetting
		{
			[field: SerializeField]
			public LayerMask TargetLayer { get; private set; } = default;
			[field: SerializeField]
			public LayerMask ObstructLayer { get; private set; } = default;
			[field: SerializeField]
			public QueryTriggerInteraction TriggerInteraction { get; private set; } = default;
			[field: SerializeField]
			[field: Range (0f, 1f)]
			public float FrontDotLimit { get; private set; } = 0.75f;
			[field: SerializeField]
			[field: Min (0.001f)]
			public float UpdateMaxTime { get; private set; } = 0.015f;
			[field: SerializeField]
			public float LineOfSightHeight { get; private set; } = 0.5f;
		}
	}
}
