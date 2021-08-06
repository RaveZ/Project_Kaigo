using UnityEngine;

namespace Kaigo.Runtime.Character.AI
{
	internal interface IBlackboard
	{
		GameObject Target { get; }
		Vector3 SpawnPosition { get; }
	}
}
