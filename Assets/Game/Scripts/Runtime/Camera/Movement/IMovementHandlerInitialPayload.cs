using Kaigo.Runtime.Camera.Selection;
using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper.Input;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Camera.Movement
{
	using IDCMovementSetting = Z.CameraDungeonCrawler.Runtime.IMovementSetting;
	using IDCTransitionSetting = Z.CameraDungeonCrawler.Runtime.ITransitionSetting;
	using ITPMovementSetting = Z.CameraThirdPerson.Runtime.IMovementSetting;
	using ITPTransitionSetting = Z.CameraThirdPerson.Runtime.ITransitionSetting;

	internal interface IMovementHandlerInitialPayload : IDisposable
	{
		ICameraSelection CamSelection { get; }
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IInputAxis DCInputAxis { get; }
		IInputAxis TPInputAxis { get; }
		IDCMovementSetting DCMoveSetting { get; }
		ITPMovementSetting TPMoveSetting { get; }
		IDCTransitionSetting DCTransitionSetting { get; }
		ITPTransitionSetting TPTransitionSetting { get; }
		ITimer Timer { get; }
	}
}
