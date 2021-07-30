using CleverCrow.Fluid.BTs.Trees;
using Kaigo.Runtime.Character.AI.Setting;
using Kaigo.Runtime.Character.AI.Stat;
using UnityEngine;
using UnityEngine.AI;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Character.AI
{
	internal abstract partial class BaseBrainHandler : ScriptableObject, ITimerLimit 
	{
		internal delegate void MoveToAction (Vector3 destination);
		internal delegate NavMeshPathStatus GetPathStatusAction ();

		internal event MoveToAction OnMoveToTriggered = null;
		internal event GetPathStatusAction OnGetPathStatusTriggered = null;

#if UNITY_EDITOR
		[SerializeField]
#endif
		protected BehaviorTree BTree = null;

		protected TimerHandler Timer = null;

		protected GameObject ControlledObj = null;
		protected IAISetting Setting = null;
		protected IAIStat Stat = null;
		protected IBlackboard Blackboard = null;

		public float TimeLimit { get; protected set; } = 0f;

		internal void Init (GameObject controlledObj, IAISetting setting, IAIStat stat, IBlackboard blackboard)
		{
			ControlledObj = controlledObj;
			Timer = ControlledObj.AddComponent<TimerHandler> ();
			Timer.Init (this);

			Setting = setting;
			Stat = stat;
			Blackboard = blackboard;

			InitBrain ();
		}

		protected abstract void InitBrain ();

		internal virtual void OnUpdate ()
		{
			Timer.OnUpdate ();
			if (Timer.IsTicking)
				return;

			BTree.Tick ();
		}

		protected void MoveTo (Vector3 destination)
		{
			OnMoveToTriggered.Invoke (destination);
		}

		protected NavMeshPathStatus GetPathStatus ()
		{
			return OnGetPathStatusTriggered.Invoke ();
		}
	}
}
