namespace Kaigo.Runtime.Camera.Movement
{
	using DCMovementHandler = Z.CameraDungeonCrawler.Runtime.MovementHandler;
	using TPMovementHandler = Z.CameraThirdPerson.Runtime.MovementHandler;

	internal partial class MovementHandler
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_dcMoveHandler == null)
				_dcMoveHandler = GetComponent<DCMovementHandler> ();
			if (_tpMoveHandler == null)
				_tpMoveHandler = GetComponent<TPMovementHandler> ();
		}
#endif
	}
}
