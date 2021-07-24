using UnityEngine;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Camera
{
	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
		public Vector3 Position => transform.position;
		public float Pitch => transform.eulerAngles.x;
		public float Yaw => _pitchTransform.eulerAngles.y;
		public Vector3 Up => _pitchTransform.up;
		public Vector3 Right => _mainCam.transform.right;
		public Vector3 Forward => transform.forward;
	}
}
