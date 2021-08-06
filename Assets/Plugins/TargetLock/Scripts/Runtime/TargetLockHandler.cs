using UnityEngine;
using UnityEngine.Assertions;
using Z.UnityHelper.TransformUtil;

namespace Z.TargetLock.Runtime
{
	public class TargetLockHandler : MonoBehaviour, ITargetedObject
	{
		private ITargetLockSetting _lockSetting = null;
		private ITransform _ownerTransform = null;

		private Collider [] _colliders = null;

		public bool IsInitialized { get; private set; } = false;

		public ITransform Target { get; private set; } = null;

		public void Init (ITargetLockSetting lockSetting, ITransform ownerTransform)
		{
			_lockSetting = lockSetting;
			_ownerTransform = ownerTransform;

			_colliders = new Collider [_lockSetting.AllocationCount];

			IsInitialized = true;
		}

		public void ActivateTargetLock ()
		{
			Assert.IsTrue (IsInitialized);
			HandleTargetLock ();
		}

		public void DeactivateTargetLock ()
		{
			Assert.IsTrue (IsInitialized);
			Target = null;
		}

		private void HandleTargetLock ()
		{
			if (Target != null)
				return;

			int overlappedCount = Physics.OverlapSphereNonAlloc (
				_ownerTransform.Position,
				_lockSetting.Radius,
				_colliders,
				_lockSetting.Layer,
				_lockSetting.TriggerInteraction);

			if (overlappedCount == 0)
				return;

			for (int i = 0; i < overlappedCount; ++i)
			{
				// ignore self
				if (_colliders [i].gameObject.GetInstanceID () == gameObject.GetInstanceID ())
					continue;

				if (_colliders [i].TryGetComponent (out ITargetable target))
				{
					Target = target;
					break;
				}
			}
		}
	}
}
