using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Stat;
using Kaigo.Runtime.Character.Setting;
using UnityEngine;
using Z.CharacterLocomotion.Runtime;
using Z.SmoothUpdate.Runtime;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	using UCharacterController = UnityEngine.CharacterController;

	internal partial class CharacterController : MonoBehaviour, ITransform
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (UnityEditor.EditorApplication.isPlaying)
				return;

			if (_ucharController == null)
				_ucharController = GetComponent<UCharacterController> ();
			if (SmoothUpdtHandler == null)
				SmoothUpdtHandler = GetComponent<SmoothUpdateHandler> ();
			if (_camTTargetransform == null)
				_camTTargetransform = transform.GetChild (0);
			if (_anim == null)
				_anim = GetComponentInChildren<Animator> ();
			if (_stat == null)
				_stat = GetComponent<CharacterStat> ();
			if (_charSetting == null)
				_charSetting = GetComponent<CharacterSetting> ();
			if (_locoHandler == null)
				_locoHandler = GetComponent<LocomotionHandler> ();
			if (_animHandler == null)
				_animHandler = GetComponent<AnimationHandler> ();
			if (_animEventHandler == null)
				_animEventHandler = GetComponentInChildren<AnimationEventHandler> ();
		}
#endif
	}
}
