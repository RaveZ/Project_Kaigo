namespace Kaigo.Runtime.Character.Movement.Locomotion
{
	public interface ILocomotionSetting
	{
		float MoveSmoothSpeed { get; }
		float TurnSmoothTime { get; }
		float GravityScale { get; }
		bool IsCamRelative { get; }
	}
}
