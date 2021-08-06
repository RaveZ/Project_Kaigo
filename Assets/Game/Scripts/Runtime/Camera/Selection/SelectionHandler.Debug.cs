using UnityEngine;

namespace Kaigo.Runtime.Camera.Selection
{
	internal partial class SelectionHandler : MonoBehaviour
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		internal void DebugSelectNextCamera ()
		{
			int camTypeIdx = (int) CamType;
			camTypeIdx = (camTypeIdx + 1) % (int) CameraType.Length;
			SelectCamera ((CameraType) camTypeIdx);
		}
#endif
	}
}
