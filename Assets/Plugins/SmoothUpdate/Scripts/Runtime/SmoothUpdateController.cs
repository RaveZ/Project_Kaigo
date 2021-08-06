using System.Collections;
using UnityEngine;
using Z.Collections;

namespace Z.SmoothUpdate.Runtime
{
	[DisallowMultipleComponent]
	[RequireComponent (typeof (FactorHandler))]
	public class SmoothUpdateController : MonoBehaviour
	{
		[Header ("Own Reference")]
		[SerializeField]
		private FactorHandler _factorHandler = null;

		private UniqueList<SmoothUpdateHandler> _smoothUpdateHandlerList = new UniqueList<SmoothUpdateHandler> ();

		private bool _isInitialized = false;
		private readonly WaitForEndOfFrame _waitForEndOfFrame = new WaitForEndOfFrame ();
		private readonly WaitForFixedUpdate _waitForFixedUpdate = new WaitForFixedUpdate ();

#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_factorHandler == null)
				_factorHandler = GetComponent<FactorHandler> ();
		}
#endif

		public void Init ()
		{
			if (_isInitialized)
				return;

			_isInitialized = true;

			_factorHandler.Init ();
			for (int i = 0; i < _smoothUpdateHandlerList.Count; ++i)
			{
				_smoothUpdateHandlerList [i].Init ();
				_smoothUpdateHandlerList [i].OnDestroyedTriggered += HandleSmoothUpdateDestroyed;
			}

			StartCoroutine (OnEndOfFrameRoutine ());
			StartCoroutine (AfterFixedUpdateRoutine ());
		}

		private IEnumerator AfterFixedUpdateRoutine ()
		{
			while (true)
			{
				/// WaitForFixedUpdate will be called after all FixedUpdate has been called
				yield return _waitForFixedUpdate;

				AfterFixedUpdate ();
			}
		}

		private IEnumerator OnEndOfFrameRoutine ()
		{
			while (true)
			{
				/// WaitForEndOfFrame will be called after all LateUpdate has been called
				yield return _waitForEndOfFrame;

				BeforeFixedUpdate ();
			}
		}

		private void HandleSmoothUpdateDestroyed (SmoothUpdateHandler objectHandler)
		{
			_smoothUpdateHandlerList.Remove (objectHandler);
		}

		public void AddSmoothedUpdateHandler (SmoothUpdateHandler smoothUpdateHandler)
		{
			_smoothUpdateHandlerList.Add (smoothUpdateHandler);

			if (_isInitialized)
			{
				smoothUpdateHandler.Init ();
				smoothUpdateHandler.OnDestroyedTriggered += HandleSmoothUpdateDestroyed;
			}
		}

		private void BeforeFixedUpdate ()
		{
			for (int i = 0; i < _smoothUpdateHandlerList.Count; ++i)
				_smoothUpdateHandlerList [i].BeforeFixedUpdate ();
		}

		private void FixedUpdate ()
		{
			_factorHandler.HandleFixedUpdate ();
		}

		private void AfterFixedUpdate ()
		{
			for (int i = 0; i < _smoothUpdateHandlerList.Count; ++i)
				_smoothUpdateHandlerList [i].AfterFixedUpdate ();
		}

		private void Update ()
		{
			_factorHandler.HandleUpdate ();
			for (int i = 0; i < _smoothUpdateHandlerList.Count; ++i)
				_smoothUpdateHandlerList [i].HandleUpdate (_factorHandler.Factor);
		}
	}
}
