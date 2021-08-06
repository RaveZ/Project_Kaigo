using UnityEngine;

namespace Kaigo.Runtime.Character.Setting
{
	[CreateAssetMenu (fileName = "CharacterSetting", menuName = "Kaigo/Character/Initial Setting")]
	internal class InitialCharacterSetting : ScriptableObject, ICharacterSetting
	{
		[field: Header ("Locomotion")]
		[field: SerializeField]
		[field: Range (0.1f, 0.9f)]
		public float MoveSmoothSpeed { get; private set; } = 0.5f;
		[field: SerializeField]
		[field: Range (0.1f, 0.9f)]
		public float TurnSmoothTime { get; private set; } = 0.2f;
		[field: SerializeField]
		[field: Min (0f)]
		public float GravityScale { get; private set; } = 1f;
		[field: SerializeField]
		public bool IsCamRelative { get; private set; } = false;

		[field: Header ("Target Lock")]
		[field: SerializeField]
		[field: Min (1f)]
		public int AllocationCount { get; private set; } = 10;
		[field: SerializeField]
		[field: Min (1f)]
		public float Radius { get; private set; } = 20f;
		[field: SerializeField]
		public LayerMask Layer { get; private set; } = default;
		[field: SerializeField]
		public QueryTriggerInteraction TriggerInteraction { get; private set; } = QueryTriggerInteraction.Ignore;
	}
}
