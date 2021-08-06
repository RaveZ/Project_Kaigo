using Z.Ease;

namespace Z.CameraThirdPerson.Runtime
{
	public interface IFocusSetting
	{
		float FocusSmooth { get; }
		float DiffLimitToSmooth { get; }
	}
}
