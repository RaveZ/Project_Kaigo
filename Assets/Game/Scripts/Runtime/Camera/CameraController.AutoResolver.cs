using UnityEngine;

namespace Kaigo.Runtime.Camera
{
	using UCamera = UnityEngine.Camera;

	internal partial class CameraController : MonoBehaviour, ICameraTransform
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (_mainCam == null)
				_mainCam = GetComponentInChildren<UCamera> ();
			if (_pitchTransform == null)
				_pitchTransform = transform.GetChild (0);
		}
#endif
	}
}
