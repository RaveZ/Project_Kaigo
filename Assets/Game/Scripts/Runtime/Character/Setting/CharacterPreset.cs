using Kaigo.Runtime.Character.Attribute;
using UnityEngine;

namespace Kaigo.Runtime.Character.Setting
{
	[CreateAssetMenu (fileName = "CharacterPreset", menuName = "Kaigo/Character/Character Preset")]
	internal class CharacterPreset : ScriptableObject
	{
		[field: SerializeField]
		internal InitialCharacterSetting InitialCharSetting { get; private set; } = null;
		[field: SerializeField]
		internal InitialStatAttribute InitialStatAttribute { get; private set; } = null;
		//[field: SerializeField]
		//internal AssetReference
	}
}
