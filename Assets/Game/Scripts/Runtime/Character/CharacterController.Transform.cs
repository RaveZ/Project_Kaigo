using UnityEngine;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController : MonoBehaviour, ITransform
	{
		Vector3 ITransform.Position => _camTTargetransform.position;
		Vector3 ITransform.LocalPosition => _camTTargetransform.localPosition;
		Vector3 ITransform.EulerAngles => _camTTargetransform.eulerAngles;
		Vector3 ITransform.LocalEulerAngles => _camTTargetransform.localEulerAngles;
		Quaternion ITransform.Rotation => _camTTargetransform.rotation;
		Quaternion ITransform.LocalRotation => _camTTargetransform.localRotation;
		Vector3 ITransform.LocalScale => _camTTargetransform.localScale;
		float ITransform.Roll => _camTTargetransform.eulerAngles.z;
		float ITransform.Pitch => _camTTargetransform.eulerAngles.x;
		float ITransform.Yaw => _camTTargetransform.eulerAngles.y;
		Vector3 ITransform.Up => _camTTargetransform.up;
		Vector3 ITransform.Right => _camTTargetransform.right;
		Vector3 ITransform.Forward => _camTTargetransform.forward;
	}
}
