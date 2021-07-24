using Kaigo.Runtime.Camera;
using Kaigo.Runtime.Character.Attribute;
using Kaigo.Runtime.Character.Input;
using System;

namespace Kaigo.Runtime.Character.Movement.Locomotion
{
	using UCharacterController = UnityEngine.CharacterController;

	internal interface ILocomotionHandlerInitialPayload : IDisposable
	{
		UCharacterController UCharController { get; }
		ICameraTransform CamTransform { get; }
		IInput Input { get; }
		IStatAttribute StatAttribute { get; }
		ILocomotionSetting LocoSetting { get; }
		bool IsCamRelative { get; }
	}
}
