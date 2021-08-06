using Z.Ease;

namespace Z.CameraThirdPerson.Runtime
{
	public interface ITransitionSetting
	{
		float TimeCamTransition { get; }
		EaseType InterpolationType{ get; }
	}
}
