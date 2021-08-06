using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Setting
{
	internal interface IAISetting
	{
		ISensorEyeSetting EyeSetting { get; }
		float StoppingDistance { get; }
		float WaitTimeForRecalculatePath { get; }
	}
}
