using UnityEngine;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController
	{
		public Vector3 Position => _camTargetTransform.position;
		public Vector3 LocalPosition => _camTargetTransform.localPosition;
		public Vector3 EulerAngles => _camTargetTransform.eulerAngles;
		public Vector3 LocalEulerAngles => _camTargetTransform.localEulerAngles;
		public Quaternion Rotation => _camTargetTransform.rotation;
		public Quaternion LocalRotation => _camTargetTransform.localRotation;
		public Vector3 LocalScale => _camTargetTransform.localScale;
		public float Roll => _camTargetTransform.eulerAngles.z;
		public float Pitch => _camTargetTransform.eulerAngles.x;
		public float Yaw => _camTargetTransform.eulerAngles.y;
		public Vector3 Up => _camTargetTransform.up;
		public Vector3 Right => _camTargetTransform.right;
		public Vector3 Forward => _camTargetTransform.forward;
	}
}
