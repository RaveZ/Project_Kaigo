using Kaigo.Runtime.Character.Stat;
using UnityEngine;
using Z.CharacterLocomotion.Runtime;

namespace Kaigo.Runtime.Character.Animation
{
	[DisallowMultipleComponent]
	internal class AnimationHandler : MonoBehaviour
	{
		private readonly int _paramVelocityXID = Animator.StringToHash ("VelocityX");
		private readonly int _paramVelocityZID = Animator.StringToHash ("VelocityZ");

		private Animator _anim = null;
		private ILocomotion _loco = null;
		private ICharacterStat _stat = null;

		internal void Init (Animator anim, ILocomotion loco, ICharacterStat stat)
		{
			_anim = anim;
			_loco = loco;
			_stat = stat;
		}

		internal void OnUpdate ()
		{
			_anim.SetFloat (_paramVelocityZID, _loco.MoveSpeed / _stat.MoveSpeed);
		}
	}
}
