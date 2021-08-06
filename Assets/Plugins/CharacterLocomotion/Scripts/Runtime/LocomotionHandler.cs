using UnityEngine;
using Z.UnityHelper.TransformUtil;

namespace Z.CharacterLocomotion.Runtime
{
	using UCharacterController = UnityEngine.CharacterController;

	[DisallowMultipleComponent]
	public class LocomotionHandler : MonoBehaviour, ILocomotion
	{
		private UCharacterController _ucharController = null;
		private ICameraTransform _camTransform = null;
		private IInputAxis _inputAxis = null;
		private IFocusedObject _focusedObject = null;
		private ILocomotionStat _stat = null;
		private ILocomotionSetting _locoSetting = null;

		private bool _isSnappingDir = false;
		private float _targetAngle = 0f;
		private float _turnSmoothVelocity = 0f;

		internal bool CanMove { get; set; } = true;
		internal bool CanTurn { get; set; } = true;

		public Vector3 MoveDir { get; private set; } = default;
		public float MoveSpeed { get; private set; } = 0f;
		public Vector3 MoveVelocity { get; private set; } = default;
		public float TurnInPlaceSpeed { get; private set; } = default;
		public bool HasTargetLocked => _focusedObject.Target != null;

		public Vector3 PrevPos { get; private set; } = default;
		public Vector3 Dir { get; private set; } = default;
		public Vector3 LocalDir { get; private set; } = default;

		public void Init (ILocomotionHandlerInitialPayload initialPayload)
		{
			_ucharController = initialPayload.UCharController;
			_camTransform = initialPayload.CamTransform;
			_inputAxis = initialPayload.InputAxis;
			_focusedObject = initialPayload.FocusedObject;
			_stat = initialPayload.Stat;
			_locoSetting = initialPayload.LocoSetting;

			initialPayload.Dispose ();
		}

		public void HandleFixedUpdate ()
		{
			if (HasTargetLocked)
			{
				UpdateLocomotion ();
				LookAtLockedTarget ();
			}
			else
			{
				UpdateLocomotion ();
				LookAtMovementDirection ();
			}
		}

		private void UpdateLocomotion ()
		{
			Vector3 moveVector = new Vector3 (_inputAxis.Horizontal, 0f, _inputAxis.Vertical);
			Vector3 inputMoveDir = moveVector.normalized;
			float moveMagnitude = Mathf.Min (moveVector.magnitude, inputMoveDir.magnitude);

			if (moveMagnitude <= 0.01f || !CanMove)
				MoveSpeed = Mathf.Lerp (0f, MoveSpeed, _locoSetting.MoveSmoothSpeed);
			else if (CanMove)
			{
				if (_locoSetting.IsCamRelative)
					MoveDir = inputMoveDir.z * _camTransform.Forward + inputMoveDir.x * _camTransform.Right;
				else
					MoveDir = inputMoveDir;

				float moveSpeedStat = _stat.MoveForwardSpeed;
				if (HasTargetLocked)
				{
					Vector3 groundTargetPos = new Vector3 (_focusedObject.Target.Position.x, transform.position.y, _focusedObject.Target.Position.z);
					Vector3 targetDirNorm = (groundTargetPos - transform.position).normalized;
					float dirDot = Vector3.Dot (MoveDir.normalized, targetDirNorm);
					if (dirDot < 0f)
						moveSpeedStat = _stat.MoveBackwardSpeed;
				}

				MoveSpeed = Mathf.Lerp (moveMagnitude * moveSpeedStat, MoveSpeed, _locoSetting.MoveSmoothSpeed);
			}

			MoveVelocity = ((MoveDir * MoveSpeed) + (Physics.gravity * _locoSetting.GravityScale));
			_ucharController.Move (MoveVelocity * Time.fixedDeltaTime);
			MoveVelocity = transform.InverseTransformVector (MoveVelocity);
		}

		private void LookAtMovementDirection ()
		{
			if (_inputAxis.Horizontal == 0f && _inputAxis.Vertical == 0f)
				return;

			Vector3 moveDir = new Vector3 (_inputAxis.Horizontal, 0f, _inputAxis.Vertical).normalized;
			if (_locoSetting.IsCamRelative)
				_targetAngle = Mathf.Atan2 (moveDir.x, moveDir.z) * Mathf.Rad2Deg + _camTransform.Yaw;
			else
				_targetAngle = Mathf.Atan2 (moveDir.x, moveDir.z) * Mathf.Rad2Deg;

			if (CanTurn)
			{
				/// lerp the rotation
				float angle = Mathf.SmoothDampAngle (transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _locoSetting.TurnSmoothTime);
				transform.rotation = Quaternion.Euler (0f, angle, 0f);
			}
			else if (_isSnappingDir)
			{
				_isSnappingDir = false;
				transform.rotation = Quaternion.Euler (0f, _targetAngle, 0f);
			}
		}

		private void LookAtLockedTarget ()
		{
			Vector3 groundTargetPos = new Vector3 (_focusedObject.Target.Position.x, transform.position.y, _focusedObject.Target.Position.z);
			Vector3 targetDir = groundTargetPos - transform.position;
			_targetAngle = Mathf.Atan2 (targetDir.x, targetDir.z) * Mathf.Rad2Deg;

			if (CanTurn)
			{
				/// lerp the rotation
				float angle = Mathf.SmoothDampAngle (transform.eulerAngles.y, _targetAngle, ref _turnSmoothVelocity, _locoSetting.TurnSmoothTime);
				transform.rotation = Quaternion.Euler (0f, angle, 0f);
				if (HasTargetLocked)
					TurnInPlaceSpeed = Mathf.Clamp (_turnSmoothVelocity / 90f, -1f, 1f);
				else
					TurnInPlaceSpeed = 0f;
			}
			else if (_isSnappingDir)
			{
				_isSnappingDir = false;
				transform.rotation = Quaternion.Euler (0f, _targetAngle, 0f);
			}
		}
	}
}
