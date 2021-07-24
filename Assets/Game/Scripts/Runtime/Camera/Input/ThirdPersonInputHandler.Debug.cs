using System.Diagnostics;
using UnityEngine;

namespace Kaigo.Runtime.Camera.Input
{
	using static UnityEngine.InputSystem.InputAction;

	internal partial class ThirdPersonInputHandler : MonoBehaviour, IInput
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		private Generated.Input.Debug.DebugCameraThirdPersonInput _debugCameraThirdPersonInput = null;
#endif

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInit ()
		{
			_debugCameraThirdPersonInput = new Generated.Input.Debug.DebugCameraThirdPersonInput ();
			_debugCameraThirdPersonInput.Game.CancelLook.started += DebugCancelLookStarted;
			_debugCameraThirdPersonInput.Game.CancelLook.canceled += DebugCancelLookCanceled;
		}

#if UNITY_EDITOR || DEVELOPMENT_BUILD
		private void DebugCancelLookStarted (CallbackContext context)
		{
			if (_isActive)
				_cameraThirdPersonInput.Game.Look.performed -= LookPerformed;

			LookH = 0f;
			LookV = 0f;
		}

		private void DebugCancelLookCanceled (CallbackContext context)
		{
			_cameraThirdPersonInput.Game.Look.performed -= LookPerformed;
			if (_isActive)
				_cameraThirdPersonInput.Game.Look.performed += LookPerformed;
		}
#endif
	}
}
