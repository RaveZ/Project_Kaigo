using UnityEngine;

namespace Z.CharacterLocomotion.Runtime
{
	public interface ILocomotion
	{
		Vector3 MoveDir { get; }
		float MoveSpeed { get; }
	}
}
