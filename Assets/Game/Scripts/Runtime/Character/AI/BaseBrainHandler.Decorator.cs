using CleverCrow.Fluid.BTs.Tasks;

namespace Kaigo.Runtime.Character.AI
{
	internal abstract partial class BaseBrainHandler
	{
		protected TaskStatus MustHasNoTarget (ITask childTask)
		{
			if (HasTarget ())
				return TaskStatus.Failure;

			childTask.Update ();
			return TaskStatus.Success;
		}

		protected TaskStatus MustInTargetRadius (ITask childTask)
		{
			if (InDestArea (Blackboard.Target.transform.position))
				return TaskStatus.Failure;

			childTask.Update ();
			return TaskStatus.Success;
		}
	}
}
