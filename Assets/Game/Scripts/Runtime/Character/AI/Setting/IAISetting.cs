using Z.SensorEye.Runtime;
using Z.UnityHelper.AI;

namespace Kaigo.Runtime.Character.AI.Setting
{
	internal interface IAISetting : IBaseAISetting
	{
		ISensorEyeSetting EyeSetting { get; }
		float WaitTimeForRecalculatePath { get; }
	}
}
