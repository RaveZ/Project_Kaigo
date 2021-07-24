using Kaigo.Runtime.Level;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kaigo.Runtime
{
	[DisallowMultipleComponent]
	[RequireComponent (typeof (LevelController))]
	internal partial class AppController : MonoBehaviour
	{
		private static CancellationTokenSource _cts = null;
		internal static CancellationToken CT { get; private set; }

		[SerializeField]
		private LevelController _lvlController = null;

		private void Awake ()
		{
			DebugInit ();

			GameObject [] roots = SceneManager.GetSceneByBuildIndex (LevelIndexConst.Main).GetRootGameObjects ();
			for (int i = 0; i < roots.Length; ++i)
				DontDestroyOnLoad (roots [i]);

			if (_isPlayedFromMain)
				_lvlController.LoadLevelAsync (LevelIndexConst.Menu);

			_isReady = true;
		}

		private void OnDestroy ()
		{
			_cts.Cancel ();
			_cts.Dispose ();
		}
	}
}
