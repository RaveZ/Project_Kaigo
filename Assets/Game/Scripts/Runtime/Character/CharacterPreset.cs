using Kaigo.Runtime.Character.Attribute;
using UnityEngine;

namespace Kaigo.Runtime.Character
{
	[CreateAssetMenu (fileName = "CharacterPreset", menuName = "Kaigo/Character/Character Preset")]
	internal class CharacterPreset : ScriptableObject
	{
		[field: SerializeField]
		internal CharacterSetting CharSetting { get; private set; } = null;
		[field: SerializeField]
		internal StatAttribute StatAttribute { get; private set; } = null;
		//[field: SerializeField]
		//internal AssetReference
	}
}
