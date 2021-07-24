using UnityEngine;

namespace Kaigo.Runtime.Camera.Selection
{
	[DisallowMultipleComponent]
	internal partial class SelectionHandler : MonoBehaviour, ICameraSelection
	{
		public CameraType CamType { get; private set; } = CameraType.DungeonCrawler;

		internal delegate void SelectCameraAction (CameraType type);
		internal event SelectCameraAction OnSelectCameraTriggered = null;

		internal void SelectCamera (CameraType type)
		{
			CamType = type;
			OnSelectCameraTriggered.Invoke (type);
		}
	}
}
