using Kaigo.Generated.Input;
using UnityEngine;

namespace Kaigo.Runtime.Camera.Input
{
	using Z.UnityHelper.Input;
	using static UnityEngine.InputSystem.InputAction;

	[DisallowMultipleComponent]
	internal partial class ThirdPersonInputHandler : MonoBehaviour, IInputAxis
	{
		private CameraThirdPersonInput _cameraThirdPersonInput = null;

		private bool _isActive = false;
		private bool _isInitialized = false;

		public float Horizontal { get; private set; } = 0f;
		public float Vertical { get; private set; } = 0f;

		internal void Init ()
		{
			_cameraThirdPersonInput = new CameraThirdPersonInput ();
			_cameraThirdPersonInput.Game.Look.performed += LookPerformed;

			DebugInit ();

			_isInitialized = true;
		}

		private void OnEnable ()
		{
			if (!_isInitialized)
				return;

			if (_isInitialized && _isActive)
			{
				_cameraThirdPersonInput.Enable ();
				DebugEnable ();
			}
		}

		private void OnDisable ()
		{
			if (!_isInitialized)
				return;

			if (_isInitialized && _isActive)
			{
				_cameraThirdPersonInput.Disable ();
				DebugDisable ();
			}
		}

		private void OnDestroy ()
		{
			if (_isInitialized)
			{
				_cameraThirdPersonInput.Dispose ();
				DebugDestroy ();
			}
		}

		internal void Activate ()
		{
			if (_isActive)
				return;

			_isActive = true;
			_cameraThirdPersonInput.Enable ();
			DebugEnable ();
		}

		internal void Deactivate ()
		{
			if (!_isActive)
				return;

			_isActive = false;
			_cameraThirdPersonInput.Disable ();
			DebugDisable ();
		}

		private void LookPerformed (CallbackContext context)
		{
			Vector2 lookInput = context.ReadValue<Vector2> ();
			Horizontal = lookInput.x;
			Vertical = lookInput.y;
		}
	}
}
