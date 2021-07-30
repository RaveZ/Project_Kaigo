using UnityEngine;

namespace Z.UnityHelper.TransformUtil
{
	public interface ICameraTransform
	{
		Vector3 Position { get; }
		float Pitch { get; }
		float Yaw { get; }
		Vector3 Up { get; }
		Vector3 Right { get; }
		Vector3 Forward { get; }
	}
}
