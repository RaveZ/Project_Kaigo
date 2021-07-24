using UnityEngine;

namespace Kaigo.Runtime.Camera.Input
{
	internal partial class UserInputHandler : MonoBehaviour
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_tpInputHandler == null)
				_tpInputHandler = GetComponent<ThirdPersonInputHandler> ();
			if (_dcInputHandler == null)
				_dcInputHandler = GetComponent<DungeonCrawlerInputHandler> ();
		}
#endif
	}
}
