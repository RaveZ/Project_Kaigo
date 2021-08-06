using Kaigo.Runtime.Camera;
using Z.SmoothUpdate.Runtime;

namespace Kaigo.Development.Level.DevCharacter
{
	using KaigoCharacterController = Runtime.Character.CharacterController;

	internal partial class DevCharacterController
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_smoothUpdateController == null)
				_smoothUpdateController = GetComponent<SmoothUpdateController> ();

			if (_camController == null)
				_camController = FindObjectOfType<CameraController> ();
			KaigoCharacterController [] _charControllers = FindObjectsOfType<KaigoCharacterController> ();
			if (_charController == null)
				_charController = _charControllers [0];
			if (_charController2 == null)
				_charController2 = _charControllers [1];
		}
#endif
	}
}
