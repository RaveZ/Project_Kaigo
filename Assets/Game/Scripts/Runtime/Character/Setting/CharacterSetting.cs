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

		public int AllocationCount => _initialCharSetting.AllocationCount;
		public float Radius => _initialCharSetting.Radius;
		public LayerMask Layer => _initialCharSetting.Layer;
		public QueryTriggerInteraction TriggerInteraction => _initialCharSetting.TriggerInteraction;

		public float MoveDampTime => _initialCharSetting.MoveDampTime;

		public bool IsCamRelative { get; private set; } = false;

		private void Init (bool isCamRelative)
		{
			IsCamRelative = isCamRelative;
		}

		internal void Init (bool isInputFromUser, InitialCharacterSetting initialCharSetting = null)
		{
			if (initialCharSetting != null)
				_initialCharSetting = initialCharSetting;

			if (_initialCharSetting != null)
				Init (isInputFromUser);
		}
	}
}
