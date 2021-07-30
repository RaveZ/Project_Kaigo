using System;
using UnityEngine;
using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Stat
{
	internal partial class AIStat : ScriptableObject, IAIStat
	{
		[Serializable]
		internal class SensorEyeStat : ISensorEyeStat
		{
			[field: SerializeField]
			[field: Range (0f, 1f)]
			public float UpdateInterval { get; private set; } = 0.333f;
			[field: SerializeField]
			[field: Min (0f)]
			public float Radius { get; private set; } = 5f;
		}
	}
}
