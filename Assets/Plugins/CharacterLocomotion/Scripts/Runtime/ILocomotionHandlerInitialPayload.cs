using System;
using Z.UnityHelper.Input;
using Z.UnityHelper.TransformUtil;

namespace Z.CharacterLocomotion.Runtime
{
	using UCharacterController = UnityEngine.CharacterController;

	public interface ILocomotionHandlerInitialPayload : IDisposable
	{
		UCharacterController UCharController { get; }
		ICameraTransform CamTransform { get; }
		IInputAxis InputAxis { get; }
		ILocomotionStat Stat { get; }
		ILocomotionSetting LocoSetting { get; }
		bool IsCamRelative { get; }
	}
}
