using UnityEngine;
using Z.Timer.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Camera
{
	internal partial class CameraController : MonoBehaviour, ICameraTransform, ITimerLimit
	{
		public float TimeLimit => _camSetting.TransitionTime;
	}
}
