namespace Z.CharacterLocomotion.Runtime
{
	public interface ILocomotionSetting
	{
		float MoveSmoothSpeed { get; }
		float TurnSmoothTime { get; }
		float GravityScale { get; }
		bool IsCamRelative { get; }
	}
}
