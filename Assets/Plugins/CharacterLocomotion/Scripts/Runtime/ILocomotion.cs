using UnityEngine;

namespace Z.CharacterLocomotion.Runtime
{
	public interface ILocomotion
	{
		Vector3 MoveDir { get; }
		float MoveSpeed { get; }
		Vector3 MoveVelocity { get; }
		float TurnInPlaceSpeed { get; }
		bool HasTargetLocked { get; }
	}
}
