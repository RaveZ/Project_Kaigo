using Kaigo.Runtime.Character.Attribute;
using Kaigo.Runtime.Character.Movement.Locomotion;
using UnityEngine;

namespace Kaigo.Runtime.Character.Animation
{
	internal class AnimationHandler : MonoBehaviour
	{
		private readonly int _paramVelocityXID = Animator.StringToHash ("VelocityX");
		private readonly int _paramVelocityZID = Animator.StringToHash ("VelocityZ");

		private Animator _anim = null;
		private ILocomotion _loco = null;
		private IStatAttribute _statAttribute = null;

		internal void Init (Animator anim, ILocomotion loco, IStatAttribute statAttribute)
		{
			_anim = anim;
			_loco = loco;
			_statAttribute = statAttribute;
		}

		internal void OnUpdate ()
		{
			_anim.SetFloat (_paramVelocityZID, _loco.MoveSpeed / _statAttribute.MoveSpeed);
		}
	}
}
