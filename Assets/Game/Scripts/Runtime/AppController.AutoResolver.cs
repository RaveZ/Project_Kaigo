using Kaigo.Runtime.Level;

namespace Kaigo.Runtime
{
	internal partial class AppController
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
