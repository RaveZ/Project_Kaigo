using UnityEngine;

namespace Kaigo.Runtime.Character.Movement.Locomotion
{
	public interface ILocomotion
	{
		Vector3 MoveDir { get; }
		float MoveSpeed { get; }
	}
}
