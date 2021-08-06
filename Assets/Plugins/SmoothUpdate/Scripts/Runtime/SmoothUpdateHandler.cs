using UnityEngine;

namespace Z.SmoothUpdate.Runtime
{
	[DisallowMultipleComponent]
	public class SmoothUpdateHandler : MonoBehaviour
	{
		internal delegate void DestroyedAction (SmoothUpdateHandler smoothUpdateHandler);

		internal event DestroyedAction OnDestroyedTriggered = null;

		private TransformData[] _transformDatas;
		private int _index;

		internal void Init ()
		{
			ResetTransforms ();
		}

		private void OnDestroy ()
		{
			OnDestroyedTriggered?.Invoke (this);
		}

		internal void BeforeFixedUpdate ()
		{
			// Restoring actual transform for the FixedUpdate() cal where it could be change by the user.
			TransformData latestTransformData = _transformDatas [_index];
			transform.localPosition = latestTransformData.Position;
			transform.localScale = latestTransformData.Scale;
			transform.localRotation = latestTransformData.Rotation;
		}

		internal void AfterFixedUpdate ()
		{
			// Saving actual transform for being restored in the BeforeFixedUpdate() method.
			_index = NextIndex ();
			_transformDatas [_index] = CurrentTransformData ();
		}

		internal void HandleUpdate (float factor)
		{
			// Set interpolated transform for being rendered.
			TransformData prevTransformData = _transformDatas [NextIndex ()];
			transform.localPosition = Vector3.Lerp (prevTransformData.Position, transform.localPosition, factor);
			transform.localRotation = Quaternion.Slerp (prevTransformData.Rotation, transform.localRotation, factor);
			transform.localScale = Vector3.Lerp (prevTransformData.Scale, transform.localScale, factor);
		}

		private void ResetTransforms ()
		{
			_index = 0;
			TransformData td = CurrentTransformData ();
			_transformDatas = new TransformData [2] { td, td };
		}

		private TransformData CurrentTransformData ()
		{
			return new TransformData (transform.localPosition, transform.localRotation, transform.localScale);
		}

		private int NextIndex ()
		{
			return (_index == 0) ? 1 : 0;
		}
	}
}
