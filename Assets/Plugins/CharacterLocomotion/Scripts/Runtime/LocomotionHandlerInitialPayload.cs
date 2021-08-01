using System;
using Z.UnityHelper.Input;
using Z.UnityHelper.TransformUtil;

namespace Z.CharacterLocomotion.Runtime
{
	using UCharacterController = UnityEngine.CharacterController;

	public sealed class LocomotionHandlerInitialPayload : ILocomotionHandlerInitialPayload
	{
		public UCharacterController UCharController { get; set; }
		public ICameraTransform CamTransform { get; set; }
		public IInputAxis InputAxis { get; set; }
		public IInputLockOn InputLockOn { get; set; }
		public ILocomotionStat Stat { get; set; }
		public ILocomotionSetting LocoSetting { get; set; }
		public bool IsCamRelative { get; set; }

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

				UCharController = null;
				CamTransform = null;
				InputAxis = null;
				InputLockOn = null;
				Stat = null;
				LocoSetting = null;

				_disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~LocomotionHandlerInitialPayload ()
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
