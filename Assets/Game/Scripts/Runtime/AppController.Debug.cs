using System.Diagnostics;
using UnityEngine;

namespace Kaigo.Runtime
{
	internal partial class AppController : MonoBehaviour
	{
		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInit ()
		{
			Development.Level.DevCharacter.DevCharacterController.OnAwakeTriggered += HandleDevCharControllerAwake;
		}

#if UNITY_EDITOR || DEVELOPMENT_BUILD
		private void HandleDevCharControllerAwake (Development.Level.DevCharacter.DevCharacterController devCharController)
		{
			devCharController.Init ();
		}
#endif
	}
}
