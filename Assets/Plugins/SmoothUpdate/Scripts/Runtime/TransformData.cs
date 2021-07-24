using UnityEngine;

namespace Z.SmoothUpdate.Runtime
{
	internal struct TransformData
	{
		internal Vector3 Position;
		internal Quaternion Rotation;
		internal Vector3 Scale;

		internal TransformData (Vector3 position, Quaternion rotation, Vector3 scale)
		{
			Position = position;
			Rotation = rotation;
			Scale = scale;
		}
	}
}
