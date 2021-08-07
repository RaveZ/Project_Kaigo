using CleverCrow.Fluid.BTs.Trees;
using Kaigo.Runtime.Character.Input;
using System.Diagnostics;
using UnityEngine;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		[Header ("Editor Only")]
		[SerializeField]
		private bool _useAwakeToInit = false;
		[SerializeField]
		private bool _drawBounds = false;

		[SerializeField]
		private BehaviorTree _debugBTree = null;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			if (_useAwakeToInit)
				Init ();
		}

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInitInput (bool isInputFromUser)
		{
			if (!isInputFromUser)
				_debugBTree = ((AIInputHandler) _inputHandler).DebugBTree;
		}
#endif
	}
}
