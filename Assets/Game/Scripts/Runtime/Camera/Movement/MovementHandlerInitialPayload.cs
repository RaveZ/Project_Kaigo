using Kaigo.Runtime.Camera.Selection;
using System;
using UnityEngine;
using Z.CameraThirdPerson.Runtime;
using Z.Timer.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Camera.Movement
{
	using IDCMovementSetting = Z.CameraDungeonCrawler.Runtime.IMovementSetting;
	using IDCTransitionSetting = Z.CameraDungeonCrawler.Runtime.ITransitionSetting;
	using IDInputAxis = Z.CameraDungeonCrawler.Runtime.IInputAxis;
	using ITPInputAxis = Z.CameraThirdPerson.Runtime.IInputAxis;
	using ITPMovementSetting = Z.CameraThirdPerson.Runtime.IMovementSetting;
	using ITPTransitionSetting = Z.CameraThirdPerson.Runtime.ITransitionSetting;

	internal class MovementHandlerInitialPayload : IMovementHandlerInitialPayload
	{
		public ICameraSelection CamSelection { get; set; }
		public Transform CamTransform { get; set; }
		public Transform PitchTransform { get; set; }
		public ITransform CamTargetTransform { get; set; }
		public IDInputAxis DCInputAxis { get; set; }
		public ITPInputAxis TPInputAxis { get; set; }
		public IFocusedObject FocusedObject { get; set; }
		public IDCMovementSetting DCMoveSetting { get; set; }
		public ITPMovementSetting TPMoveSetting { get; set; }
		public IDCTransitionSetting DCTransitionSetting { get; set; }
		public ITPTransitionSetting TPTransitionSetting { get; set; }
		public IFocusSetting FocusSetting { get; set; }
		public ITimer TimerCamTransition { get; set; }

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
				DCInputAxis = null;
				TPInputAxis = null;
				FocusedObject = null;
				DCMoveSetting = null;
				TPMoveSetting = null;
				DCTransitionSetting = null;
				TPTransitionSetting = null;
				FocusSetting = null;
				TimerCamTransition = null;

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
