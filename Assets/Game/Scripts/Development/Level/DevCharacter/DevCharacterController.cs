using Kaigo.Runtime;
using Kaigo.Runtime.Camera;
using Kaigo.Runtime.Character.Input;
using Kaigo.Runtime.Character.Setting;
using UnityEngine;
using Z.SmoothUpdate.Runtime;

namespace Kaigo.Development.Level.DevCharacter
{
	using KaigoCharacterController = Runtime.Character.CharacterController;

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
		private KaigoCharacterController _charController = null;
		[SerializeField]
		private KaigoCharacterController _charController2 = null;
		[SerializeField]
		private CharacterPreset _charPreset = null;
		[SerializeField]
		private CharacterPreset _char2Preset = null;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			OnAwakeTriggered.Invoke (this);
		}

		internal void Init ()
		{
			_smoothUpdateController.Init ();
			_charController.Init (_charPreset, _camController);
			_charController2.Init (_char2Preset, _camController);
			_camController.Init (_charController2, _charController2);

			_smoothUpdateController.AddSmoothedUpdateHandler (_charController.SmoothUpdtHandler);
			_smoothUpdateController.AddSmoothedUpdateHandler (_charController2.SmoothUpdtHandler);
		}
	}
}
