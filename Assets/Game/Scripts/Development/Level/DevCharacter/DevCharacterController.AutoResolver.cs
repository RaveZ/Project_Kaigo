using Kaigo.Runtime.Camera;
using UnityEngine;
using Z.SmoothUpdate.Runtime;

namespace Kaigo.Development.Level.DevCharacter
{
	using CharacterController = Runtime.Character.CharacterController;

	internal partial class DevCharacterController : MonoBehaviour
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
			if (_charController == null)
				_charController = FindObjectOfType<CharacterController> ();
		}
#endif
	}
}
