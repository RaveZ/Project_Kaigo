using Kaigo.Runtime.Character.AI;
using Kaigo.Runtime.Character.AI.Setting;
using Kaigo.Runtime.Character.AI.Stat;
using System;
using UnityEngine;

namespace Kaigo.Runtime.Character.Input
{
	using UCharacterController = UnityEngine.CharacterController;

	internal interface IAIInputHandlerInitialPayload : IDisposable
	{
		GameObject ControlledObj { get; }
		BaseBrainHandler BrainHandler { get; }
		Vector3 SpawnPos { get; }
		UCharacterController UCharController { get; }
		IAISetting AISetting { get; }
		IAIStat AIStat { get; }
	}
}
