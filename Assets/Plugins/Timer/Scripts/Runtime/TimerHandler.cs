using UnityEngine;

namespace Z.Timer.Runtime
{
	public class TimerHandler : MonoBehaviour, ITimer
	{
		private ITimerLimit _limit = null;

		public bool IsTicking => Tick < _limit.TimeLimit;
		public float Tick { get; private set; } = 0f;
		public float TickNormalized { get; private set; } = 0f;

		public void Init (ITimerLimit limit)
		{
			_limit = limit;
			Tick = 0f;
		}

		public void Restart ()
		{
			Tick = 0f;
			TickNormalized = 0f;
		}

		public void HandleUpdate ()
		{
			if (Tick >= _limit.TimeLimit)
				return;

			Tick += Time.deltaTime;
			TickNormalized = Tick / _limit.TimeLimit;
		}
	}
}
