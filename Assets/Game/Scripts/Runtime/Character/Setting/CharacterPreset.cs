using Kaigo.Runtime.Character.AI;
using Kaigo.Runtime.Character.AI.Setting;
using Kaigo.Runtime.Character.AI.Stat;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Stat;
using UnityEngine;

namespace Kaigo.Runtime.Character.Setting
{
	[CreateAssetMenu (fileName = "CharacterPreset", menuName = "Kaigo/Character/Character Preset")]
	internal class CharacterPreset : ScriptableObject
	{
		[field: SerializeField]
		internal InitialCharacterSetting InitialSetting { get; private set; } = null;
		[field: SerializeField]
		internal InitialCharacterStat InitialStat { get; private set; } = null;
		[field: SerializeField]
		internal AISetting AISetting { get; private set; } = null;
		[field: SerializeField]
		internal AIStat AIStat { get; private set; } = null;
		[field: SerializeField]
		internal BaseInputHandler InputHandler { get; private set; } = null;
		[field: SerializeField]
		internal BaseBrainHandler BrainHandler { get; private set; } = null;
	}
}
