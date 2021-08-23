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

		protected TaskStatus NotInTargetRadius (ITask childTask)
		{
			if (InObserveArea ())
				return TaskStatus.Failure;


			childTask.Update ();
			return TaskStatus.Success;
		}

		protected TaskStatus InTargetRadius(ITask childTask)
		{
			if (InObserveArea())
				childTask.Update();

			
			return TaskStatus.Success;
            
		}
			
	}
}
