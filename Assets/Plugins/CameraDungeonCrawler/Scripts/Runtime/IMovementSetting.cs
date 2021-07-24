namespace Z.CameraDungeonCrawler.Runtime
{
	public interface IMovementSetting
	{
		float MoveSpeed { get; }
		float LookSpeed { get; }
		float CamOffsetY { get; }
		float CamOffsetZ { get; }
		float CamPitchAngle { get; }
	}
}
