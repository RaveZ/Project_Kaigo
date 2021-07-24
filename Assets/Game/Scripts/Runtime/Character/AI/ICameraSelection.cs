using UnityEngine;

namespace Kaigo.Runtime.Character.AI
{
	internal interface IBaseAIBlackboard
	{
		GameObject Target { get; }
		Vector3 SpawnPosition { get; }
	}
}
