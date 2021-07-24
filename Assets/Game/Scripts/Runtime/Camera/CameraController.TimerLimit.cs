using UnityEngine;
using Z.Timer.Runtime;

namespace Kaigo.Runtime.Camera
{
	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
		public float TimeLimit => _camSetting.TransitionTime;
	}
}
