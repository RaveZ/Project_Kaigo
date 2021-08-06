using CleverCrow.Fluid.BTs.Trees;

namespace Kaigo.Runtime.Character.Input
{
	internal partial class AIInputHandler
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		internal BehaviorTree DebugBTree => _brainHandler.DebugBTree;
#endif
	}
}
