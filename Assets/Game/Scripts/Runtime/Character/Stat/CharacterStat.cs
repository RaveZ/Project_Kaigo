using UnityEngine;

namespace Kaigo.Runtime.Character.Stat
{
	[DisallowMultipleComponent]
	internal class CharacterStat : MonoBehaviour, ICharacterStat
	{
#if UNITY_EDITOR
		[SerializeField]
#endif
		private InitialCharacterStat _initialStat = null;

		public float MoveForwardSpeed { get; private set; } = 0f;
		public float MoveBackwardSpeed { get; private set; } = 0f;

		[ContextMenu ("Reset Stat")]
		private void Init ()
		{
			//Strength = _initialStatAttribute.Strength;
			//Agility = _initialStatAttribute.Agility;
			//Inteligence = _initialStatAttribute.Inteligence;
			MoveForwardSpeed = _initialStat.MoveForwardSpeed;
			MoveBackwardSpeed = _initialStat.MoveBackwardSpeed;
			//HealthPoint = _initialStatAttribute.HealthPoint;

			//EyeSensorUpdateInterval = _initialStatAttribute.EyeSensorUpdateInterval;
			//EyeSensorRadius = _initialStatAttribute.EyeSensorRadius;
		}

		internal void Init (InitialCharacterStat initialStat)
		{
			if (initialStat != null)
				_initialStat = initialStat;

			if (_initialStat != null)
				Init ();
		}
	}
}
