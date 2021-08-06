using Kaigo.Runtime.Level;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Kaigo.Runtime
{
	internal partial class AppController
	{
		private static bool _isPlayedFromMain = false;
		private static bool _isReady = false;

		[RuntimeInitializeOnLoadMethod (RuntimeInitializeLoadType.BeforeSceneLoad)]
		private async static void OnBeforeSceneLoadRuntimeMethod ()
		{
			_cts = new CancellationTokenSource ();
			CT = _cts.Token;

			_isPlayedFromMain = SceneManager.GetActiveScene ().buildIndex == LevelIndexConst.Main;
			if (_isPlayedFromMain)
				return;

			SceneManager.LoadScene (LevelIndexConst.Main, new LoadSceneParameters
			{
				loadSceneMode = LoadSceneMode.Additive,
				localPhysicsMode = LocalPhysicsMode.None
			});

			await Task.Yield ();

			if (CT.IsCancellationRequested)
				return;

			SceneManager.UnloadSceneAsync (LevelIndexConst.Main);
		}

		internal static async Task WaitTillReady ()
		{
			while (!_isReady)
			{
				await Task.Yield ();

				if (CT.IsCancellationRequested)
					return;
			}
		}
	}
}
