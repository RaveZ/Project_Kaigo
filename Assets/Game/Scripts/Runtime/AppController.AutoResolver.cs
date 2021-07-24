using Kaigo.Runtime.Level;
using UnityEngine;

namespace Kaigo.Runtime
{
	internal partial class AppController : MonoBehaviour
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_lvlController == null)
				_lvlController = GetComponent<LevelController> ();
		}
#endif
	}
}
