using Kaigo.Generated.Input;
using UnityEngine;

namespace Kaigo.Runtime.Camera.DungeonCrawler
{
	using static UnityEngine.InputSystem.InputAction;

	internal class DungeonCrawlerMovementHandler : MonoBehaviour
	{
		private CameraDungeonCrawlerInput _cameraDungeonCrawlerInput = null;

		private bool _isActive = false;
		private bool _isInitialized = false;
		private bool _isAltRotationEnabled = false;

		internal float LookH { get; private set; } = 0f;
		internal float LookV { get; private set; } = 0f;

		internal void Init ()
		{
			_cameraDungeonCrawlerInput = new CameraDungeonCrawlerInput ();
			_cameraDungeonCrawlerInput.Game.Rotation.performed += RotationPerformed;
			_cameraDungeonCrawlerInput.Game.AltRotation.performed += AltRotationPerformed;
			_cameraDungeonCrawlerInput.Game.EnableAltRotation.started += EnableAltRotationStarted;
			_cameraDungeonCrawlerInput.Game.EnableAltRotation.canceled += EnableAltRotationCanceled;

			_isInitialized = true;
		}

		private void OnEnable ()
		{
			if (_isInitialized && _isActive)
				_cameraDungeonCrawlerInput.Enable ();
		}

		private void OnDisable ()
		{
			if (_isInitialized && _isActive)
				_cameraDungeonCrawlerInput.Disable ();
		}

		private void OnDestroy ()
		{
			if (_isInitialized)
				_cameraDungeonCrawlerInput.Dispose ();
		}

		internal void Activate ()
		{
			if (_isActive)
				return;

			_isActive = true;
			_cameraDungeonCrawlerInput.Enable ();
		}

		internal void Deactivate ()
		{
			if (!_isActive)
				return;

			_isActive = false;
			_cameraDungeonCrawlerInput.Disable ();
		}

		private void RotationPerformed (CallbackContext context)
		{
			Vector2 lookInput = context.ReadValue<Vector2> ();
			LookH = lookInput.x;
		}

		private void AltRotationPerformed (CallbackContext context)
		{
			if (!_isAltRotationEnabled)
				return;

			Vector2 lookInput = context.ReadValue<Vector2> ();
			LookH = lookInput.x;
		}

		private void EnableAltRotationStarted (CallbackContext context)
		{
			_isAltRotationEnabled = true;
		}

		private void EnableAltRotationCanceled (CallbackContext context)
		{
			_isAltRotationEnabled = false;
		}
	}
}
