using UnityEngine;
using Z.Ease;
using Z.Timer.Runtime;
using Z.UnityHelper;

namespace Z.CameraThirdPerson.Runtime
{
	[DisallowMultipleComponent]
	public class MovementHandler : MonoBehaviour
	{
		private Transform _camTransform = null;
		private Transform _pitchTransform = null;
		private ITransform _camTargetTransform = null;
		private IInput _input = null;
		private IMovementSetting _moveSetting = null;
		private ITransitionSetting _transitionSetting = null;
		private ITimer _timer = null;

		private bool _isTargetValid = false;
		private Vector3 _camVelocity = default;
		private float _pitchAngle = 0f;
		private float _yawAngle = 0f;
		private float _currentCamLength = 0f;
		private float _transitionOffsetY = 0f;
		private float _transitionOffsetZ = 0f;
		private float _transitionPitchAngle = 0f;
		private float _transitionYawAngle = 0f;
		private float _transitionTargetYawAngle = 0f;
		private readonly RaycastHit [] _hits = new RaycastHit [10];

		public void Init (IMovementHandlerInitialPayload initialPayload)
		{

			_camTransform = initialPayload.CamTransform;
			_pitchTransform = initialPayload.PitchTransform;
			_input = initialPayload.Input;
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
			_currentCamLength = -_moveSetting.DistanceLength;

			_transitionOffsetY = transform.position.y;
			_transitionOffsetZ = -_camTransform.localPosition.z;
			_transitionPitchAngle = _pitchTransform.localEulerAngles.x;
			_transitionYawAngle = transform.eulerAngles.y;
			_transitionTargetYawAngle = _camTargetTransform.Yaw;

			_timer.Restart ();
		}

		public void OnLateUpdate ()
		{
			if (!_isTargetValid)
				return;

			FollowTarget ();
			RotateCamera ();
			if (!_timer.IsTicking)
				HandleCollision ();
		}

		private void FollowTarget ()
		{
			float offsetY;
			float offsetZ;

			if (_timer.IsTicking)
			{
				float t = EaseCalculator.GetCalculatedAlpha (_timer.TickNormalized, _transitionSetting.InterpolationType);
				offsetY = Mathf.Lerp (_transitionOffsetY, 0f, t);
				offsetZ = Mathf.Lerp (_transitionOffsetZ, _moveSetting.DistanceLength, t);

				Vector3 locPos = _camTransform.transform.localPosition;
				locPos.z = -offsetZ;
				_camTransform.transform.localPosition = locPos;
			}
			else
			{
				offsetY = 0f;
				offsetZ = _moveSetting.DistanceLength;
			}

			Vector3 direction = -_camTransform.forward;
			Vector3 targetPos = Vector3.SmoothDamp (transform.position, _camTargetTransform.Position + (offsetY * Vector3.up), ref _camVelocity, _moveSetting.MoveSpeed);
			float distance = Vector3.Distance (targetPos, _camTargetTransform.Position + (direction * -offsetZ));
			if (distance < _moveSetting.MinTargetDistance)
				targetPos += ((_moveSetting.MinTargetDistance - distance) * direction);
			transform.position = targetPos;
		}

		private void RotateCamera ()
		{
			Vector3 eul;
			Quaternion targetRot;

			if (_timer.IsTicking)
			{
				float t = EaseCalculator.GetCalculatedAlpha (_timer.TickNormalized, _transitionSetting.InterpolationType);
				Quaternion from = Quaternion.Euler (_transitionPitchAngle, _transitionYawAngle, 0f);
				Quaternion to = Quaternion.Euler (_camTargetTransform.Pitch, _transitionTargetYawAngle, 0f);
				Vector3 transitionEul = Quaternion.Slerp (from, to, t).eulerAngles;
				_pitchAngle = transitionEul.x;
				_yawAngle = transitionEul.y;
			}
			else
			{
				float dirV = _moveSetting.InvertY ? -1f : 1f;
				_pitchAngle = Mathf.Clamp (_pitchAngle + (_input.LookV * _moveSetting.LookSpeed * dirV), _moveSetting.MinPitchAngle, _moveSetting.MaxPitchAngle);
				_yawAngle += (_input.LookH * _moveSetting.LookSpeed);
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

		private void HandleCollision ()
		{
			float targetCamLength = -_moveSetting.DistanceLength;
			Vector3 direction = -_camTransform.forward;

			int hitsCount = Physics.SphereCastNonAlloc (_pitchTransform.position, _moveSetting.CamCollisionRadius, direction, _hits, Mathf.Abs (targetCamLength), _moveSetting.CamCollisionLayer, QueryTriggerInteraction.Collide);
			if (hitsCount > 1)
				targetCamLength = -(_hits [0].distance - _moveSetting.CamCollisionOffset);


			if (Mathf.Abs (targetCamLength) < _moveSetting.CamMinCollisionOffset)
				targetCamLength = -Mathf.Abs (_moveSetting.CamMinCollisionOffset);

			_currentCamLength = Mathf.Lerp (_currentCamLength, targetCamLength, _moveSetting.CamCollisionJumpSmoothSpeed);

			Vector3 camLocPos = _camTransform.localPosition;
			camLocPos.z = _currentCamLength;
			_camTransform.localPosition = camLocPos;
		}
	}
}
