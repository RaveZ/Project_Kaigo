using UnityEngine;

namespace Kaigo.Runtime.Character.Stat
{
	[CreateAssetMenu (fileName = "CharacterStat", menuName = "Kaigo/Character/Initial Stat")]
	internal class InitialCharacterStat : ScriptableObject, ICharacterStat
	{
		[field: SerializeField]
		public float MoveForwardSpeed { get; private set; } = 6f;
		[field: SerializeField]
		public float MoveBackwardSpeed { get; private set; } = 3f;
	}
}
