using Z.SensorEye.Runtime;

namespace Kaigo.Runtime.Character.AI.Stat
{
	internal interface IAIStat
	{
		ISensorEyeStat EyeStat { get; }
		float IdleTime { get; }
	}
}
