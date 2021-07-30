using Kaigo.Runtime.Character.AI.Stat;
using UnityEngine;
using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Stat
{
	[CreateAssetMenu (fileName = "AIStat", menuName = "Kaigo/Character/AI Stat")]
	internal partial class AIStat : ScriptableObject, IAIStat
	{
		[field: Header ("General Stat")]
		[field: SerializeField]
		public float IdleTime { get; private set; } = 3f;

		[Header ("Sensor Eye Stat")]
		[SerializeField]
		public SensorEyeStat _eyeStat = null;
		public ISensorEyeStat EyeStat => _eyeStat;
	}
}
