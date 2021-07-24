using Kaigo.Runtime.Camera.Selection;
using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper;

namespace Kaigo.Runtime.Camera.Movement
{
	using IDCInput = Z.CameraDungeonCrawler.Runtime.IInput;
	using ITPInput = Z.CameraThirdPerson.Runtime.IInput;
	using IDCTransitionSetting = Z.CameraDungeonCrawler.Runtime.ITransitionSetting;
	using ITPTransitionSetting = Z.CameraThirdPerson.Runtime.ITransitionSetting;
	using IDCMovementSetting = Z.CameraDungeonCrawler.Runtime.IMovementSetting;
	using ITPMovementSetting = Z.CameraThirdPerson.Runtime.IMovementSetting;

	internal class MovementHandlerInitialPayload : IMovementHandlerInitialPayload
	{
		public ICameraSelection CamSelection { get; set;  }
		public Transform CamTransform { get; set;  }
		public Transform PitchTransform { get; set; }
		public ITransform CamTargetTransform { get; set; }
		public IDCInput DCInput { get; set; }
		public ITPInput TPInput { get; set; }
		public IDCMovementSetting DCMoveSetting { get; set; }
		public ITPMovementSetting TPMoveSetting { get; set; }
		public IDCTransitionSetting DCTransitionSetting { get; set; }
		public ITPTransitionSetting TPTransitionSetting { get; set; }
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

				CamSelection = null;
				CamTransform = null;
				PitchTransform = null;
				CamTargetTransform = null;
				DCInput = null;
				TPInput = null;
				DCMoveSetting = null;
				TPMoveSetting = null;
				DCTransitionSetting = null;
				TPTransitionSetting = null;
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
