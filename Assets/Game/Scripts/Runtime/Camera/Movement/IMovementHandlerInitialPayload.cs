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

	internal interface IMovementHandlerInitialPayload : IDisposable
	{
		ICameraSelection CamSelection { get; }
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IDInputAxis DCInputAxis { get; }
		ITPInputAxis TPInputAxis { get; }
		IFocusedObject FocusedObject { get; }
		IDCMovementSetting DCMoveSetting { get; }
		ITPMovementSetting TPMoveSetting { get; }
		IDCTransitionSetting DCTransitionSetting { get; }
		ITPTransitionSetting TPTransitionSetting { get; }
		IFocusSetting FocusSetting { get; }
		ITimer TimerCamTransition { get; }
	}
}
