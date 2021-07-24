using UnityEngine;

namespace Kaigo.Runtime.Character.Attribute
{
	[CreateAssetMenu (fileName = "CharacterAttribute", menuName = "Kaigo/Character/Initial Stat Attribute")]
	internal class InitialStatAttribute : ScriptableObject, IStatAttribute
	{
		[field: SerializeField]
		public float MoveSpeed { get; private set; } = 6f;
	}
}
