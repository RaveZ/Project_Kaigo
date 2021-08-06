using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using Z.Tasks;
using Z.Timer.Runtime;

namespace Z.SensorEye.Runtime
{
	public class SensorEyeHandler : MonoBehaviour, ITimerLimit
	{
		public delegate void TargetDetectedAction (GameObject targetObj);
		public event TargetDetectedAction OnTargetDetectedTriggered = null;

		private TimerHandler _timerHandler = null;
		private ISensorEyeSetting _sensorSetting = null;
		private ISensorEyeStat _sensorStat = null;

		private readonly Collider [] _inAreaTargets = new Collider [20];
		private int _inAreaTargetCount = 0;
		private readonly GameObject [] _inFrontTargets = new GameObject [10];
		private int _inFrontTargetsCount = 0;
		private readonly GameObject [] _unobstructedTargets = new GameObject [10];
		private int _unobstructedTargetsCount = 0;
		private readonly RaycastHit [] _hits = new RaycastHit [10];
		private readonly float [] _unobstructedDists = new float [10];
		private bool _isSensorInProgress = false;

		private CancellationToken _ct;

		public float TimeLimit => _sensorStat.UpdateInterval;

		private GameObject _target = null;
		internal GameObject Target
		{
			get => _target;
			private set
			{
				if (_target == value)
					return;

				_target = value;
				OnTargetDetectedTriggered?.Invoke (_target);
			}
		}

		public void Init (ISensorEyeSetting sensorSetting, ISensorEyeStat sensorStat, CancellationToken ct)
		{
			_timerHandler = gameObject.AddComponent<TimerHandler> ();
			_timerHandler.Init (this);
			_timerHandler.Restart ();

			_sensorSetting = sensorSetting;
			_sensorStat = sensorStat;

			_ct = ct;
		}

		public void HandleUpdate ()
		{
			if (_timerHandler.IsTicking)
			{
				_timerHandler.HandleUpdate ();
				return;
			}

			_timerHandler.Restart ();
			LineOfSightDetectionAsync ();
		}

		private async void LineOfSightDetectionAsync ()
		{
			if (_isSensorInProgress)
				return;

			if (Target == null)
			{
				_isSensorInProgress = true;
				await TaskUtil.DoTask (OverlapSphereNonAllocTask (), _ct);
				await TaskUtil.DoTask (FilterTargetInFrontTask (), _ct);
				await TaskUtil.DoTask (FilterTargetUnobstructedTask (), _ct);
				await TaskUtil.DoTask (SearchClosestTargetTask (), _ct);
				_isSensorInProgress = false;
			}
			else
				CheckTargetStillInSight ();
		}

		private async Task OverlapSphereNonAllocTask ()
		{
			float startTime = Time.time;

			_inAreaTargetCount = Physics.OverlapSphereNonAlloc (transform.position, _sensorStat.Radius, _inAreaTargets, _sensorSetting.TargetLayer, _sensorSetting.TriggerInteraction);

			startTime = await TaskUtil.YieldIfOverTimeLimit (startTime, _sensorSetting.UpdateMaxTime, _ct);
		}

		private async Task FilterTargetInFrontTask ()
		{
			float startTime = Time.time;

			_inFrontTargetsCount = 0;
			if (_inAreaTargetCount == 0)
				return;

			for (int i = 0; i < _inAreaTargetCount; ++i)
			{
				startTime = await TaskUtil.YieldIfOverTimeLimit (startTime, _sensorSetting.UpdateMaxTime, _ct);
				if (_ct.IsCancellationRequested)
					return;

				if (_inAreaTargets [i].gameObject.GetInstanceID () == gameObject.GetInstanceID ())
					continue;

				Vector3 targetDir = (_inAreaTargets [i].transform.position - transform.position).normalized;
				if (Vector3.Dot (transform.forward, targetDir) < _sensorSetting.FrontDotLimit)
					continue;

				_inFrontTargets [_inFrontTargetsCount++] = _inAreaTargets [i].gameObject;
			}
		}

		private async Task FilterTargetUnobstructedTask ()
		{
			float startTime = Time.time;

			_unobstructedTargetsCount = 0;
			if (_inFrontTargetsCount == 0)
				return;

			for (int i = 0; i < _inFrontTargetsCount; ++i)
			{
				startTime = await TaskUtil.YieldIfOverTimeLimit (startTime, _sensorSetting.UpdateMaxTime, _ct);
				if (_ct.IsCancellationRequested)
					return;

				Vector3 sourcePos = transform.position + (_sensorSetting.LineOfSightHeight * Vector3.up);
				Vector3 targetPos = _inFrontTargets [i].transform.position + (_sensorSetting.LineOfSightHeight * Vector3.up);
				Vector3 dir = targetPos - sourcePos;
				float dist = dir.magnitude;
				dir.Normalize ();

				int hitCount = (Physics.RaycastNonAlloc (sourcePos, dir, _hits, dist, _sensorSetting.ObstructLayer, QueryTriggerInteraction.Collide));
				if (hitCount > 1)
					continue;

				_unobstructedDists [_unobstructedTargetsCount] = dist;
				_unobstructedTargets [_unobstructedTargetsCount++] = _inFrontTargets [i].gameObject;
			}
		}

		private async Task SearchClosestTargetTask ()
		{
			float startTime = Time.time;

			if (_unobstructedTargetsCount == 0)
				return;

			float dist = float.MaxValue;
			int closestIndex = -1;
			for (int i = 0; i < _unobstructedTargetsCount; ++i)
			{
				startTime = await TaskUtil.YieldIfOverTimeLimit (startTime, _sensorSetting.UpdateMaxTime, _ct);
				if (_ct.IsCancellationRequested)
					return;

				if (_unobstructedDists [i] > dist)
					continue;

				dist = _unobstructedDists [i];
				closestIndex = i;
			}

			Target = closestIndex < 0 ? null : _unobstructedTargets [closestIndex];
		}

		private void CheckTargetStillInSight ()
		{
			Vector3 sourcePos = transform.position + (0.5f * Vector3.up);
			Vector3 targetPos = Target.transform.position + (0.5f * Vector3.up);
			Vector3 dir = targetPos - sourcePos;
			float dist = dir.magnitude;
			dir.Normalize ();
			int hitCount = (Physics.RaycastNonAlloc (sourcePos, dir, _hits, dist, _sensorSetting.ObstructLayer, QueryTriggerInteraction.Collide));
			if (hitCount >= 1)
				Target = null;
		}
	}
}
