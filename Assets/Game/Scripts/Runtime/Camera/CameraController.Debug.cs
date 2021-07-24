using System.Diagnostics;
using UnityEngine;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Camera
{
	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		[Header ("Editor Only")]
		[SerializeField]
		private bool _useAwakeToInit = false;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			if (_useAwakeToInit)
				Init (null);
		}
#endif

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInit ()
		{
			_inputHandler.DebugOnSelectNextCameraTriggered += _selectHandler.DebugSelectNextCamera;
		}
	}
}
