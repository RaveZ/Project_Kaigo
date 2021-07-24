using Z.Ease;

namespace Z.CameraThirdPerson.Runtime
{
	public interface ITransitionSetting
	{
		float Time { get; }
		EaseType InterpolationType{ get; }
	}
}
