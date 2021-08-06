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

		private float _prevVelX = 0f;

		internal void Init (Animator anim, ILocomotion loco, ICharacterStat stat)
		{
			_anim = anim;
			_loco = loco;
			_stat = stat;
		}

		internal void HandleUpdate ()
		{
			if (_loco.HasTargetLocked)
			{
				_anim.SetFloat (_paramVelocityXID, _loco.MoveVelocity.x / _stat.MoveForwardSpeed);
				_anim.SetFloat (_paramVelocityZID, _loco.MoveVelocity.z / _stat.MoveForwardSpeed);
				_prevVelX = _loco.MoveVelocity.x;
			}
			else
			{
				if (_prevVelX != 0f)
					_prevVelX = 0f;

				_anim.SetFloat (_paramVelocityZID, _loco.MoveSpeed / _stat.MoveForwardSpeed);
			}
		}
	}
}
