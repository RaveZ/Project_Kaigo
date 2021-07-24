using UnityEngine;
using Z.UnityHelper.Input;
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
		private ILocomotionStat _stat = null;
		private ILocomotionSetting _locoSetting = null;

		private bool _isSnappingDir = false;
		private float _targetAngle = 0f;
		private float _turnSmoothVelocity = 0f;

		internal bool CanMove { get; set; } = true;
		internal bool CanTurn { get; set; } = true;

		public Vector3 MoveDir { get; private set; } = default;
		public float MoveSpeed { get; private set; } = 0f;

		public void Init (ILocomotionHandlerInitialPayload initialPayload)
		{
			_ucharController = initialPayload.UCharController;
			_camTransform = initialPayload.CamTransform;
			_inputAxis = initialPayload.InputAxis;
			_stat = initialPayload.Stat;
			_locoSetting = initialPayload.LocoSetting;

			initialPayload.Dispose ();
		}

		public void OnFixedUpdate ()
		{
			UpdateLocomotion ();
			LookAtMovementDirection ();
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
				MoveSpeed = Mathf.Lerp (moveMagnitude * _stat.MoveSpeed, MoveSpeed, _locoSetting.MoveSmoothSpeed);
			}

			_ucharController.Move (((MoveDir * MoveSpeed) + (Physics.gravity * _locoSetting.GravityScale)) * Time.fixedDeltaTime);
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
	}
}
