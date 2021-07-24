using Kaigo.Runtime.Camera.Selection;
using UnityEngine;
using Z.UnityHelper;

namespace Kaigo.Runtime.Camera.Movement
{
	using CameraType = Selection.CameraType;
	using DCMovementHandler = Z.CameraDungeonCrawler.Runtime.MovementHandler;
	using DCMovementHandlerInitialPayload = Z.CameraDungeonCrawler.Runtime.MovementHandlerInitialPayload;
	using TPMovementHandler = Z.CameraThirdPerson.Runtime.MovementHandler;
	using TPMovementHandlerInitialPayload = Z.CameraThirdPerson.Runtime.MovementHandlerInitialPayload;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (DCMovementHandler), typeof (TPMovementHandler))]
	internal partial class MovementHandler : MonoBehaviour
	{
		[SerializeField]
		private DCMovementHandler _dcMoveHandler = null;
		[SerializeField]
		private TPMovementHandler _tpMoveHandler = null;

		private ICameraSelection _camSelection = null;

		internal void Init (IMovementHandlerInitialPayload initialPayload)
		{
			_camSelection = initialPayload.CamSelection;

			_dcMoveHandler.Init (new DCMovementHandlerInitialPayload
			{
				CamTransform = initialPayload.CamTransform,
				PitchTransform = initialPayload.PitchTransform,
				CamTargetTransform = initialPayload.CamTargetTransform,
				Input = initialPayload.DCInput,
				MoveSetting = initialPayload.DCMoveSetting,
				TransitionSetting = initialPayload.DCTransitionSetting,
				Timer = initialPayload.Timer
			});

			_tpMoveHandler.Init (new TPMovementHandlerInitialPayload
			{
				CamTransform = initialPayload.CamTransform,
				PitchTransform = initialPayload.PitchTransform,
				CamTargetTransform = initialPayload.CamTargetTransform,
				Input = initialPayload.TPInput,
				MoveSetting = initialPayload.TPMoveSetting,
				TransitionSetting = initialPayload.TPTransitionSetting,
				Timer = initialPayload.Timer
			});

			initialPayload.Dispose ();
		}

		internal void SetTarget (ITransform camTargetTransform)
		{

		}

		internal void OnSelectCamera (CameraType type)
		{
			switch (type)
			{
				default:
				case CameraType.Length:
				case CameraType.DungeonCrawler:
					_dcMoveHandler.Activate ();
					break;
				case CameraType.ThirdPerson:
					_tpMoveHandler.Activate ();
					break;
			}
		}

		internal void OnLateUpdate ()
		{
			switch (_camSelection.CamType)
			{
				default:
				case CameraType.Length:
				case CameraType.DungeonCrawler:
					_dcMoveHandler.OnLateUpdate ();
					break;
				case CameraType.ThirdPerson:
					_tpMoveHandler.OnLateUpdate ();
					break;
			}
		}
	}
}
