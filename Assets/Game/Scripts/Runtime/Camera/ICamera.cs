using UnityEngine;

namespace Kaigo.Runtime.Camera
{
	internal interface ICamera
	{
		bool IsRendered (Renderer renderer);
		bool IsRendered (Bounds bounds);
	}
}
