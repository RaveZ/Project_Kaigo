using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;
using Z.Tasks;

namespace Kaigo.Runtime.Level
{
	[DisallowMultipleComponent]
	internal class LevelController : MonoBehaviour
	{
		internal delegate void LoadingAction (int levelIndex, float progress);

		internal event LoadingAction OnLoadingTriggered = null;

		internal async void LoadLevelAsync (int levelIndex, bool isAdditive = false, bool withPhysics = false)
		{
			await TaskUtil.DoTask (LoadLevelTask (levelIndex, isAdditive, withPhysics), AppController.CT);
		}

		private async Task LoadLevelTask (int levelIndex, bool isAdditive = false, bool withPhysics = false)
		{
			AsyncOperation loadOps = SceneManager.LoadSceneAsync (levelIndex, new LoadSceneParameters
			{
				loadSceneMode = isAdditive ? LoadSceneMode.Additive : LoadSceneMode.Single,
				localPhysicsMode = withPhysics ? LocalPhysicsMode.Physics3D : LocalPhysicsMode.None
			});

			loadOps.allowSceneActivation = false;

			while (loadOps.progress < 0.9f)
			{
				await Task.Yield ();

				if (AppController.CT.IsCancellationRequested)
					return;

				OnLoadingTriggered?.Invoke (levelIndex, loadOps.progress);
			}

			loadOps.allowSceneActivation = true;

			OnLoadingTriggered?.Invoke (levelIndex, 1f);
		}
	}
}
