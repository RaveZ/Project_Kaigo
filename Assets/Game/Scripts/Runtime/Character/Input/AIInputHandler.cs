using Kaigo.Runtime.Character.AI;
using UnityEngine;
using UnityEngine.AI;
using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.Input
{
	using UCharacterController = UnityEngine.CharacterController;

	[CreateAssetMenu (fileName = "AIInput", menuName = "Kaigo/Character/Input Handler/AI")]
	internal partial class AIInputHandler : BaseInputHandler, IBlackboard
	{
		private SensorEyeHandler _sensEyeHandler = null;
		private BaseBrainHandler _brainHandler = null;

		private GameObject _controlledObj = null;
		private NavMeshAgent _navAgent = null;
		private UCharacterController _ucharController = null;

		internal void Init (IAIInputHandlerInitialPayload initialPayload)
		{
			_controlledObj = initialPayload.ControlledObj;
			_sensEyeHandler = _controlledObj.AddComponent<SensorEyeHandler> ();
			_brainHandler = initialPayload.BrainHandler;
			_navAgent = _controlledObj.AddComponent<NavMeshAgent> ();

			SpawnPosition = initialPayload.SpawnPos;
			_ucharController = initialPayload.UCharController;

			_navAgent.height = _ucharController.height + _ucharController.skinWidth;
			_navAgent.radius = _ucharController.radius;
			_navAgent.stoppingDistance = initialPayload.AISetting.StoppingDistance * 0.5f;
			_navAgent.updatePosition = false;
			_navAgent.updateRotation = false;
			_navAgent.destination = _controlledObj.transform.position;

			_sensEyeHandler.Init (initialPayload.AISetting.EyeSetting, initialPayload.AIStat.EyeStat, AppController.CT);
			_brainHandler.Init (_controlledObj, initialPayload.AISetting, initialPayload.AIStat, this);

			_sensEyeHandler.OnTargetDetectedTriggered += HandleTargetDetected;
			_brainHandler.OnMoveToTriggered += HandleMoveTo;
			_brainHandler.OnGetPathStatusTriggered += HandleGetPathStatus;

			initialPayload.Dispose ();
		}

		internal override void HandleUpdate ()
		{
			_sensEyeHandler.HandleUpdate ();
			_brainHandler.HandleUpdate ();
			CalculateInputAxisFromNavAgent ();
		}

		private void CalculateInputAxisFromNavAgent ()
		{
			Vector3 dv = _navAgent.desiredVelocity.normalized;
			Horizontal = dv.x;
			Vertical = dv.z;

			_navAgent.nextPosition = _controlledObj.transform.position;
			_navAgent.velocity = _ucharController.velocity;
		}

		private void HandleTargetDetected (GameObject targetObj)
		{
			Target = targetObj;
		}

		private void HandleMoveTo (Vector3 destination)
		{
			_navAgent.SetDestination (destination);

			if (_navAgent.pathStatus == NavMeshPathStatus.PathInvalid || _navAgent.pathStatus == NavMeshPathStatus.PathPartial)
				Target = null;
		}


		private NavMeshPathStatus HandleGetPathStatus ()
		{
			return _navAgent.pathStatus;
		}

	}
}
