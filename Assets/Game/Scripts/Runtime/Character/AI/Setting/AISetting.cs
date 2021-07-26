using UnityEngine;
using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Setting
{
	[CreateAssetMenu (fileName = "AISetting", menuName = "Kaigo/Character/AI Setting")]
	internal partial class AISetting : ScriptableObject, IAISetting
	{
		[field: Header ("General Setting")]
		[field: SerializeField]
		[field: Range (0f, 1f)]
		public float WaitTimeForRecalculatePath { get; private set; } = 0.1f;
		[field: SerializeField]
		[field: Range (0f, 1f)]
		public float StoppingDistance { get; private set; } = 1f;

		[Header ("Sensor Eye Setting")]
		[SerializeField]
		private SensorEyeSetting _eyeSetting = null;
		public ISensorEyeSetting EyeSetting => _eyeSetting;
	}
}
