using System.Diagnostics;
using UnityEngine;

namespace Kaigo.Runtime.Camera
{
	internal partial class CameraController
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		[Header ("Editor Only")]
		[SerializeField]
		private bool _useAwakeToInit = false;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			if (_useAwakeToInit)
				Init (null, null);
		}
#endif

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInit ()
		{
			_inputHandler.DebugOnSelectNextCameraTriggered += _selectHandler.DebugSelectNextCamera;
		}
	}
}
