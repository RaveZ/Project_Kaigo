using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Z.CameraDungeonCrawler.Runtime
{
	public interface IMovementHandlerInitialPayload : IDisposable
	{
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IInputAxis InputAxis { get; }
		IMovementSetting MoveSetting { get; }
		ITransitionSetting TransitionSetting { get; }
		ITimer TimerCamTransition { get; }
	}
}
