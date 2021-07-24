using Kaigo.Runtime.Character.Input;
using UnityEngine;

namespace Kaigo.Runtime.Character.Setting
{
	[DisallowMultipleComponent]
	internal class CharacterSetting : MonoBehaviour, ICharacterSetting
	{
#if UNITY_EDITOR
		[SerializeField]
#endif
		private InitialCharacterSetting _initialCharSetting = null;

		public float MoveSmoothSpeed => _initialCharSetting.MoveSmoothSpeed;
		public float TurnSmoothTime => _initialCharSetting.TurnSmoothTime;
		public float GravityScale => _initialCharSetting.GravityScale;

		public bool IsCamRelative { get; private set; } = false;

		[ContextMenu ("Reset Attribute")]
		private void Init (bool isCamRelative)
		{
			//Strength = _initialStatAttribute.Strength;
			//Agility = _initialStatAttribute.Agility;
			//Inteligence = _initialStatAttribute.Inteligence;
			IsCamRelative = isCamRelative;
			//HealthPoint = _initialStatAttribute.HealthPoint;

			//EyeSensorUpdateInterval = _initialStatAttribute.EyeSensorUpdateInterval;
			//EyeSensorRadius = _initialStatAttribute.EyeSensorRadius;
		}

		internal void Init (InputType inputType, InitialCharacterSetting initialCharSetting = null)
		{
			if (initialCharSetting != null)
				_initialCharSetting = initialCharSetting;

			Init (inputType == InputType.User);
		}

		internal void Init (InputType inputType)
		{
			if (_initialCharSetting != null)
				Init (inputType == InputType.User);
		}
	}
}
