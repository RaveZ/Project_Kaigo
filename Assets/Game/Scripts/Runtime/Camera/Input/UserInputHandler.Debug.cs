using System.Diagnostics;

namespace Kaigo.Runtime.Camera.Input
{
	using static UnityEngine.InputSystem.InputAction;

	internal partial class UserInputHandler
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		internal delegate void DebugSelectNextCameraAction ();
		internal event DebugSelectNextCameraAction DebugOnSelectNextCameraTriggered = null;

		private Generated.Input.Debug.DebugCameraInput _debugCameraInput = null;
#endif

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInit ()
		{
			_debugCameraInput = new Generated.Input.Debug.DebugCameraInput ();
			_debugCameraInput.Game.SwitchCamera.performed += DebugSwitchCameraPerformed;
			_debugCameraInput.Enable ();
		}

#if UNITY_EDITOR || DEVELOPMENT_BUILD
		private void OnEnable ()
		{
			if (_isInitialized)
				_debugCameraInput.Enable ();
		}

		private void OnDisable ()
		{
			if (_isInitialized)
				_debugCameraInput.Disable ();
		}

		internal void OnDestroy ()
		{
			if (_isInitialized)
				_debugCameraInput.Dispose ();
		}

		private void DebugSwitchCameraPerformed (CallbackContext context)
		{
			DebugOnSelectNextCameraTriggered.Invoke ();
		}
#endif
	}
}
