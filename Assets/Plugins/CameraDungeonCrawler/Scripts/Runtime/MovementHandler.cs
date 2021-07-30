using UnityEngine;
using Z.Ease;
using Z.Timer.Runtime;
using Z.UnityHelper.Input;
using Z.UnityHelper.TransformUtil;

namespace Z.CameraDungeonCrawler.Runtime
{
	[DisallowMultipleComponent]
	public class MovementHandler : MonoBehaviour
	{
		private Transform _camTransform = null;
		private Transform _pitchTransform = null;
		private ITransform _camTargetTransform = null;
		private IInputAxis _inputAxis = null;
		private IMovementSetting _moveSetting = null;
		private ITransitionSetting _transitionSetting = null;
		private ITimer _timer = null;

		private bool _isTargetValid = false;
		private Vector3 _camVelocity = default;
		private float _pitchAngle = 0f;
		private float _yawAngle = 0f;
		private float _transitionOffsetY = 0f;
		private float _transitionOffsetZ = 0f;
		private float _transitionPitchAngle = 0f;
		private float _transitionYawAngle = 0f;
		private float _transitionTargetYawAngle = 0f;

		public float TimeLimit => _transitionSetting.Time;

		public void Init (IMovementHandlerInitialPayload initialPayload)
		{

			_camTransform = initialPayload.CamTransform;
			_pitchTransform = initialPayload.PitchTransform;
			_inputAxis = initialPayload.InputAxis;
			_camTargetTransform = initialPayload.CamTargetTransform;
			_moveSetting = initialPayload.MoveSetting;
			_transitionSetting = initialPayload.TransitionSetting;
			_timer = initialPayload.Timer;

			_isTargetValid = _camTargetTransform != null;

			initialPayload.Dispose ();
		}

		public void SetTarget (ITransform camTargetTransform)
		{
			_camTargetTransform = camTargetTransform;
			_isTargetValid = _camTargetTransform != null;
		}

		public void Activate ()
		{
			_transitionOffsetY = transform.position.y;
			_transitionOffsetZ = -_camTransform.localPosition.z;
			_transitionPitchAngle = _pitchTransform.localEulerAngles.x;
			_transitionYawAngle = transform.eulerAngles.y;
			_transitionTargetYawAngle = _yawAngle;

			_timer.Restart ();
		}

		public void OnLateUpdate ()
		{
			if (!_isTargetValid)
				return;

			FollowTarget ();
			RotateCamera ();
		}

		private void FollowTarget ()
		{
			float offsetY;
			float offsetZ;

			if (_timer.IsTicking)
			{
				float t = EaseCalculator.GetCalculatedAlpha (_timer.TickNormalized, _transitionSetting.InterpolationType);
				offsetY = Mathf.Lerp (_transitionOffsetY, _moveSetting.CamOffsetY, t);
				offsetZ = Mathf.Lerp (_transitionOffsetZ, _moveSetting.CamOffsetZ, t);
			}
			else
			{
				offsetY = _moveSetting.CamOffsetY;
				offsetZ = _moveSetting.CamOffsetZ;
			}

			Vector3 targetPos = Vector3.SmoothDamp (transform.position, _camTargetTransform.Position + (offsetY * Vector3.up), ref _camVelocity, _moveSetting.MoveSpeed);
			transform.position = targetPos;

			Vector3 locPos = _camTransform.transform.localPosition;
			locPos.z = -offsetZ;
			_camTransform.transform.localPosition = locPos;
		}

		private void RotateCamera ()
		{
			Vector3 eul;
			Quaternion targetRot;

			if (_timer.IsTicking)
			{
				float t = EaseCalculator.GetCalculatedAlpha (_timer.TickNormalized, _transitionSetting.InterpolationType);
				Quaternion from = Quaternion.Euler (_transitionPitchAngle, _transitionYawAngle, 0f);
				Quaternion to = Quaternion.Euler (_moveSetting.CamPitchAngle, _transitionTargetYawAngle, 0f);
				Vector3 transitionEul = Quaternion.Slerp (from, to, t).eulerAngles;
				_pitchAngle = transitionEul.x;
				_yawAngle = transitionEul.y;
			}
			else
			{
				_pitchAngle = _moveSetting.CamPitchAngle;
				_yawAngle += (_inputAxis.Horizontal * _moveSetting.LookSpeed);
			}

			eul = Vector3.zero;
			eul.y = _yawAngle;
			targetRot = Quaternion.Euler (eul);
			transform.localRotation = targetRot;

			eul = Vector3.zero;
			eul.x = _pitchAngle;
			targetRot = Quaternion.Euler (eul);
			_pitchTransform.localRotation = targetRot;
		}
	}
}
