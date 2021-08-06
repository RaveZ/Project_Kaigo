using CleverCrow.Fluid.BTs.Trees;
using System.Diagnostics;

namespace Kaigo.Runtime.Character.AI
{
	internal abstract partial class BaseBrainHandler
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		internal BehaviorTree DebugBTree { get; private set; } = null;

		[Conditional ("UNITY_EDITOR"), Conditional ("DEVELOPMENT_BUILD")]
		private void DebugInitBrain ()
		{
			DebugBTree = BTree;
		}
#endif
	}
}
