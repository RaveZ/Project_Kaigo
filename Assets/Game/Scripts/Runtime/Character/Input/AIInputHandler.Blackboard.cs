using Kaigo.Runtime.Character.AI;
using UnityEngine;

namespace Kaigo.Runtime.Character.Input
{
	internal partial class AIInputHandler : BaseInputHandler, IBlackboard
	{
		public GameObject Target { get; set; } = null;
		public Vector3 SpawnPosition { get; set; } = default;
	}
}
