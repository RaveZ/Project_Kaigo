using UnityEngine;

namespace Kaigo.Runtime.Character.Stat
{
	[CreateAssetMenu (fileName = "CharacterStat", menuName = "Kaigo/Character/Initial Stat")]
	internal class InitialCharacterStat : ScriptableObject, ICharacterStat
	{
		[field: SerializeField]
		public float MoveSpeed { get; private set; } = 6f;
	}
}
