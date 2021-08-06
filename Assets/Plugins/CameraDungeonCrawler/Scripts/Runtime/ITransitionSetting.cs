using Z.Ease;

namespace Z.CameraDungeonCrawler.Runtime
{
	public interface ITransitionSetting
	{
		float TimeCamTransition { get; }
		EaseType InterpolationType{ get; }
	}
}
