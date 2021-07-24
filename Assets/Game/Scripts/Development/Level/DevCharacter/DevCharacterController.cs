using Kaigo.Runtime;
using Kaigo.Runtime.Camera;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Setting;
using UnityEngine;
using Z.SmoothUpdate.Runtime;

namespace Kaigo.Development.Level.DevCharacter
{
	using CharacterController = Runtime.Character.CharacterController;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (SmoothUpdateController))]
	internal partial class DevCharacterController : MonoBehaviour
	{
		internal delegate void AwakeAction (DevCharacterController devCharController);
		internal static event AwakeAction OnAwakeTriggered = null;

		[SerializeField]
		private SmoothUpdateController _smoothUpdateController = null;
		[SerializeField]
		private CameraController _camController = null;
		[SerializeField]
		private CharacterController _charController = null;
		[SerializeField]
		private CharacterPreset _charPreset = null;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			OnAwakeTriggered.Invoke (this);
		}

		internal void Init ()
		{
			_smoothUpdateController.Init ();
			_charController.Init (_charPreset, _camController, InputType.User);
			_camController.Init (_charController);

			_smoothUpdateController.AddSmoothedUpdateHandler (_charController.SmoothUpdtHandler);
		}
	}
}
