using Kaigo.Runtime.Camera.Input;
using Kaigo.Runtime.Camera.Selection;
using Kaigo.Runtime.Camera.Setting;
using UnityEngine;
using Z.CameraThirdPerson.Runtime;
using Z.Timer.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Camera
{
	using CameraType = Selection.CameraType;
	using MovementHandler = Movement.MovementHandler;
	using MovementHandlerInitialPayload = Movement.MovementHandlerInitialPayload;
	using UCamera = UnityEngine.Camera;

	[DisallowMultipleComponent]
	[RequireComponent (typeof (SelectionHandler), typeof (UserInputHandler), typeof (MovementHandler))]
	[RequireComponent (typeof (TimerHandler))]
	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
		[Header ("References")]
		[SerializeField]
		private UCamera _mainCam = null;
		[SerializeField]
		private Transform _pitchTransform = null;
		[SerializeField]
		private SelectionHandler _selectHandler = null;
		[SerializeField]
		private UserInputHandler _inputHandler = null;
		[SerializeField]
		private MovementHandler _moveHandler = null;
		[SerializeField]
		private CameraSetting _camSetting = null;
		[SerializeField]
		private TimerHandler _timerCamTransitionHandler = null;

		private bool _isInitialized = false;

		internal void Init (ITransform camTargetTransform, IFocusedObject focusedObject)
		{
			DebugInit ();

			_inputHandler.Init (_selectHandler);
			_moveHandler.Init (new MovementHandlerInitialPayload
			{
				CamSelection = _selectHandler,
				CamTargetTransform = camTargetTransform,
				CamTransform = _mainCam.transform,
				PitchTransform = _pitchTransform,
				DCInputAxis = _inputHandler.DCInputAxis,
				TPInputAxis = _inputHandler.TPInputAxis,
				FocusedObject = focusedObject,
				DCMoveSetting = _camSetting.DungeonCrawler,
				TPMoveSetting = _camSetting.ThirdPerson,
				DCTransitionSetting = _camSetting,
				TPTransitionSetting = _camSetting,
				FocusSetting = _camSetting,
				TimerCamTransition = _timerCamTransitionHandler
			});
			_timerCamTransitionHandler.Init (this);

			_selectHandler.OnSelectCameraTriggered += _inputHandler.OnSelectCamera;
			_selectHandler.OnSelectCameraTriggered += _moveHandler.OnSelectCamera;

			_selectHandler.SelectCamera (CameraType.ThirdPerson);

			_isInitialized = true;
		}

		private void OnDestroy ()
		{
			_selectHandler.OnSelectCameraTriggered -= _inputHandler.OnSelectCamera;
			_selectHandler.OnSelectCameraTriggered -= _moveHandler.OnSelectCamera;
		}

		private void Update ()
		{
			if (!_isInitialized)
				return;

			_timerCamTransitionHandler.HandleUpdate ();
		}

		private void LateUpdate ()
		{
			if (!_isInitialized)
				return;

			_moveHandler.HandleLateUpdate ();
		}
	}
}
