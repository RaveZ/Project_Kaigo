using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Z.CameraThirdPerson.Runtime
{
	public interface IMovementHandlerInitialPayload : IDisposable
	{
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IInputAxis InputAxis { get; }
		IFocusedObject FocusedObject { get; }
		IMovementSetting MoveSetting { get; }
		ITransitionSetting TransitionSetting { get; }
		IFocusSetting FocusSetting { get; }
		ITimer TimerCamTransition { get; }
	}
}
