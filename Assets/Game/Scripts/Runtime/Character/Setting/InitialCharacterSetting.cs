using UnityEngine;

namespace Kaigo.Runtime.Character.Setting
{
	[CreateAssetMenu (fileName = "CharacterSetting", menuName = "Kaigo/Character/Initial Character Setting")]
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
	}
}
