using Kaigo.Runtime.Character.Animation;
using Kaigo.Runtime.Character.Attribute;
using Kaigo.Runtime.Character.Movement.Locomotion;
using UnityEngine;

namespace Kaigo.Runtime.Character
{
	using UCharacterController = UnityEngine.CharacterController;

	internal partial class CharacterController : MonoBehaviour
	{
#if UNITY_EDITOR
		private void OnValidate ()
		{
			if (_ucharController == null)
				_ucharController = GetComponent<UCharacterController> ();
			if (_anim == null)
				_anim = GetComponentInChildren<Animator> ();
			if (_statAttribute == null)
				_statAttribute = GetComponent<StatAttribute> ();
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
