using System;
using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper;

namespace Z.CameraDungeonCrawler.Runtime
{
	public interface IMovementHandlerInitialPayload : IDisposable 
	{
		Transform CamTransform { get; }
		Transform PitchTransform { get; }
		ITransform CamTargetTransform { get; }
		IInput Input { get; }
		IMovementSetting MoveSetting { get; }
		ITransitionSetting TransitionSetting { get; }
		ITimer Timer { get; }
	}
}
