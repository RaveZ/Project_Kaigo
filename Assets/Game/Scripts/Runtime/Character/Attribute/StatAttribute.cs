using UnityEngine;

namespace Kaigo.Runtime.Character.Attribute
{
	[DisallowMultipleComponent]
	internal class StatAttribute : MonoBehaviour, IStatAttribute
	{
#if UNITY_EDITOR
		[SerializeField]
#endif
		private InitialStatAttribute _initialStatAttribute = null;

		public float MoveSpeed { get; private set; } = 0f;

		[ContextMenu ("Reset Attribute")]
		private void Init ()
		{
			//Strength = _initialStatAttribute.Strength;
			//Agility = _initialStatAttribute.Agility;
			//Inteligence = _initialStatAttribute.Inteligence;
			MoveSpeed = _initialStatAttribute.MoveSpeed;
			//HealthPoint = _initialStatAttribute.HealthPoint;

			//EyeSensorUpdateInterval = _initialStatAttribute.EyeSensorUpdateInterval;
			//EyeSensorRadius = _initialStatAttribute.EyeSensorRadius;
		}

		internal void Init (InitialStatAttribute initialStatAttribute = null)
		{
			if (initialStatAttribute != null)
				_initialStatAttribute = initialStatAttribute;

			if (_initialStatAttribute != null)
				Init ();
		}
	}
}
