using Kaigo.Runtime.Camera.Input;
using Kaigo.Runtime.Camera.Movement;
using Kaigo.Runtime.Camera.Selection;
using UnityEngine;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Camera
{
	using UCamera = UnityEngine.Camera;

	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_mainCam == null)
				_mainCam = GetComponentInChildren<UCamera> ();
			if (_pitchTransform == null)
				_pitchTransform = transform.GetChild (0);

			if (_selectHandler == null)
				_selectHandler = GetComponent<SelectionHandler> ();
			if (_inputHandler == null)
				_inputHandler = GetComponent<UserInputHandler> ();
			if (_moveHandler == null)
				_moveHandler = GetComponent<MovementHandler> ();
			if (_timerHandler == null)
				_timerHandler = GetComponent<TimerHandler> ();
		}
#endif
	}
}
