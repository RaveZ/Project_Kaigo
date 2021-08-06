using UnityEngine;

namespace Z.SmoothUpdate.Runtime
{
	[DisallowMultipleComponent]
	internal class FactorHandler : MonoBehaviour
	{
		private float[] _lastFixedUpdates = new float[2];
		private int _lastIndex;

		internal float Factor { get; private set; }

		internal void Init ()
		{
			Factor = 1;
			_lastFixedUpdates = new float [2] { Time.fixedTime, Time.fixedTime };
			_lastIndex = 0;
		}

		internal void HandleFixedUpdate ()
		{
			_lastIndex = NextIndex ();
			_lastFixedUpdates [_lastIndex] = Time.fixedTime;
		}

		internal void HandleUpdate ()
		{
			float lastTime = _lastFixedUpdates [_lastIndex];
			float prevTime = _lastFixedUpdates [NextIndex ()];

			if (lastTime == prevTime)
			{
				Factor = 1;
				return;
			}

			Factor = (Time.time - lastTime) / (lastTime - prevTime);
		}

		private int NextIndex ()
		{
			return (_lastIndex == 0) ? 1 : 0;
		}
	}
}
