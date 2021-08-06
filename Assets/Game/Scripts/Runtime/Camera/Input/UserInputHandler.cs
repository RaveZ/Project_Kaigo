using Kaigo.Runtime.Camera.Selection;
using UnityEngine;

namespace Kaigo.Runtime.Camera.Input
{
	using CameraType = Selection.CameraType;
	using IDCInputAxis = Z.CameraDungeonCrawler.Runtime.IInputAxis;
	using ITPInputAxis = Z.CameraThirdPerson.Runtime.IInputAxis;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (DungeonCrawlerInputHandler), typeof (ThirdPersonInputHandler))]
	internal partial class UserInputHandler : MonoBehaviour
	{
		[SerializeField]
		private ThirdPersonInputHandler _tpInputHandler = null;
		[SerializeField]
		private DungeonCrawlerInputHandler _dcInputHandler = null;

		private bool _isInitialized = false;
		private ICameraSelection _camSelection = null;

		internal IDCInputAxis DCInputAxis => _dcInputHandler;
		internal ITPInputAxis TPInputAxis => _tpInputHandler;

		internal void Init (ICameraSelection camSelection)
		{
			_isInitialized = true;

			_camSelection = camSelection;

			_tpInputHandler.Init ();
			_dcInputHandler.Init ();

			DebugInit ();
		}

		internal void OnSelectCamera (CameraType type)
		{
			switch (type)
			{
				default:
				case CameraType.Length:
				case CameraType.DungeonCrawler:
					ActivateDungeonCrawlerCamera ();
					break;
				case CameraType.ThirdPerson:
					ActivateThirdPersonCamera ();
					break;
			}
		}

		private void ActivateDungeonCrawlerCamera ()
		{
			_tpInputHandler.Deactivate ();
			_dcInputHandler.Activate ();
		}

		private void ActivateThirdPersonCamera ()
		{
			_dcInputHandler.Deactivate ();
			_tpInputHandler.Activate ();
		}
	}
}
