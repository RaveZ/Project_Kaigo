using Kaigo.Runtime.Utility;
using UnityEngine;

namespace Kaigo.Runtime.Camera
{
	using UCamera = UnityEngine.Camera;

	[RequireComponent (typeof (UCamera))]
	internal partial class CameraController : MonoBehaviour, ICameraTransform
	{
		[SerializeField]
		private UCamera _mainCam = null;
		[SerializeField]
		private Transform _pitchTransform = null;
	}
}
