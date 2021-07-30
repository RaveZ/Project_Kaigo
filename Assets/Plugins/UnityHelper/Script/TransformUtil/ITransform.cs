using UnityEngine;

namespace Z.UnityHelper.TransformUtil
{
	public interface ITransform
	{
		Vector3 Position { get; }
		Vector3 LocalPosition { get; }
		Vector3 EulerAngles { get; }
		Vector3 LocalEulerAngles { get; }
		Quaternion Rotation { get; }
		Quaternion LocalRotation { get; }
		Vector3 LocalScale { get; }
		float Roll { get; }
		float Pitch { get; }
		float Yaw { get; }
		Vector3 Up { get; }
		Vector3 Right { get; }
		Vector3 Forward { get; }
	}
}
