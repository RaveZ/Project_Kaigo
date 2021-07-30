using Kaigo.Runtime.Character.AI;
using Kaigo.Runtime.Character.AI.Setting;
using Kaigo.Runtime.Character.AI.Stat;
using System;
using UnityEngine;

namespace Kaigo.Runtime.Character.Input
{
	using UCharacterController = UnityEngine.CharacterController;

	internal class AIInputHandlerInitialPayload : IAIInputHandlerInitialPayload, IDisposable
	{
		public GameObject ControlledObj { get; set; }
		public BaseBrainHandler BrainHandler { get; set; }
		public Vector3 SpawnPos { get; set; }
		public UCharacterController UCharController { get; set; }
		public IAISetting AISetting { get; set; }
		public IAIStat AIStat { get; set; }

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

				ControlledObj = null;
				BrainHandler = null;
				UCharController = null;
				AISetting = null;
				AIStat = null;

				_disposedValue = true;
			}
		}

		// TODO: override a finalizer only if Dispose(bool disposing) above has code to free unmanaged resources.
		~AIInputHandlerInitialPayload ()
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
