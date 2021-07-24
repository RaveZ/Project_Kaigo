using Kaigo.Runtime.Camera.Selection;
using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper;

namespace Kaigo.Runtime.Camera.Movement
{
	using IDCInput = Z.CameraDungeonCrawler.Runtime.IInput;
	using IDCMovementSetting = Z.CameraDungeonCrawler.Runtime.IMovementSetting;
	using IDCTransitionSetting = Z.CameraDungeonCrawler.Runtime.ITransitionSetting;
	using ITPInput = Z.CameraThirdPerson.Runtime.IInput;
	using ITPMovementSetting = Z.CameraThirdPerson.Runtime.IMovementSetting;
	using ITPTransitionSetting = Z.CameraThirdPerson.Runtime.ITransitionSetting;

	internal interface IMovementHandlerInitialPayload : IDisposable
	{
		ICameraSelection CamSelection { get; }
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IDCInput DCInput { get; }
		ITPInput TPInput { get; }
		IDCMovementSetting DCMoveSetting { get; }
		ITPMovementSetting TPMoveSetting { get; }
		IDCTransitionSetting DCTransitionSetting { get; }
		ITPTransitionSetting TPTransitionSetting { get; }
		ITimer Timer { get; }
	}
}
