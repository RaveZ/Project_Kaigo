using System;
using Z.UnityHelper.TransformUtil;
using Z.CharacterDefense.Runtime;

namespace Z.CharacterLocomotion.Runtime
{
	using UCharacterController = UnityEngine.CharacterController;

	public interface ILocomotionHandlerInitialPayload : IDisposable
	{
		UCharacterController UCharController { get; }
		ICameraTransform CamTransform { get; }
		IInputAxis InputAxis { get; }
		IDefenseInput defenseInput { get; }
		IFocusedObject FocusedObject { get; }
		ILocomotionStat Stat { get; }
		ILocomotionSetting LocoSetting { get; }
		bool IsCamRelative { get; }
	}
}
