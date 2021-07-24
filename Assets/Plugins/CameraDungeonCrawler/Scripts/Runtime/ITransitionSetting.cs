using Z.Ease;

namespace Z.CameraDungeonCrawler.Runtime
{
	public interface ITransitionSetting
	{
		float Time { get; }
		EaseType InterpolationType{ get; }
	}
}
