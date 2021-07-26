using UnityEngine;

namespace Z.UnityHelper.AI
{
	public interface IBaseBlackboard
	{
		GameObject Target { get; }
		Vector3 SpawnPosition { get; }
	}
}
