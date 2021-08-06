using UnityEngine;
using Z.CameraThirdPerson.Runtime;
using Z.Ease;

namespace Kaigo.Runtime.Camera.Setting
{
	using IDCTransitionSetting = Z.CameraDungeonCrawler.Runtime.ITransitionSetting;
	using ITPTransitionSetting = Z.CameraThirdPerson.Runtime.ITransitionSetting;

	[CreateAssetMenu (fileName = "CameraSetting", menuName = "Kaigo/Camera/Camera Setting")]
	internal partial class CameraSetting : ScriptableObject, IDCTransitionSetting, ITPTransitionSetting, IFocusSetting
	{
		[field: Header ("Transition")]
		[field: SerializeField]
		[field: Min (0f)]
		public float TimeCamTransition { get; private set; } = 0.2f;
		[field: SerializeField]
		[field: Range (0f, 1f)]
		public float TimeLockTransition { get; private set; } = 0.2f;
		[field: SerializeField]
		public EaseType InterpolationType { get; private set; } = EaseType.Linear;

		[field: Header ("Focus Smooth")]
		[field: SerializeField]
		[field: Range (0f, 1f)]
		public float FocusSmooth { get; private set; } = 0.5f;
		[field: SerializeField]
		[field: Min (0f)]
		public float DiffLimitToSmooth { get; private set; } = 2f;

		[field: Header ("Movement")]
		[field: SerializeField]
		internal DungeonCrawlerSetting DungeonCrawler { get; private set; } = null;
		[field: SerializeField]
		internal ThirdPersonSetting ThirdPerson { get; private set; } = null;

		float IDCTransitionSetting.TimeCamTransition => TimeCamTransition;
		EaseType IDCTransitionSetting.InterpolationType => InterpolationType;

		float ITPTransitionSetting.TimeCamTransition => TimeCamTransition;
		EaseType ITPTransitionSetting.InterpolationType => InterpolationType;
	}
}
