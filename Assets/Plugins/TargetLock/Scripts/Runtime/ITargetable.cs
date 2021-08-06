using Z.UnityHelper.TransformUtil;

namespace Z.TargetLock.Runtime
{
	public interface ITargetable : ITransform
	{
		bool CanBeLock { get; }
	}
}

