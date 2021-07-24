using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper.Input;
using Z.UnityHelper.TransformUtil;

namespace Z.CameraDungeonCrawler.Runtime
{
	public class MovementHandlerInitialPayload : IMovementHandlerInitialPayload
	{
		public Transform CamTransform { get; set; }
		public Transform PitchTransform { get; set; }
		public ITransform CamTargetTransform { get; set; }
		public IInputAxis InputAxis { get; set; }
		public IMovementSetting MoveSetting { get; set; }
		public ITransitionSetting TransitionSetting { get; set; }
		public ITimer Timer { get; set; }

		#region IDisposable Support
		private bool _disposedValue = false; // To detect redundant calls

		private void Dispose (bool disposing)
		{
			if (!_disposedValue)
			{
				if (disposing)
				{
					// TODO: dispose managed state (managed objects).
				}

				// TODO: free unmanaged resources (unmanaged objects) and override a finalizer below.
				// TODO: set large fields to null.

				CamTransform = null;
				PitchTransform = null;
				CamTargetTransform = null;
				InputAxis = null;
				MoveSetting = null;
				TransitionSetting = null;
				Timer = null;

				_disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~MovementHandlerInitialPayload ()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose (false);
		}

		// This code added to correctly implement the disposable pattern.
		public void Dispose ()
		{
			// Do not change this code. Put cleanup code in Dispose(bool disposing) above.
			Dispose (true);
			// TODO: uncomment the following line if the finalizer is overridden above.
			GC.SuppressFinalize (this);
		}
		#endregion
	}
}
