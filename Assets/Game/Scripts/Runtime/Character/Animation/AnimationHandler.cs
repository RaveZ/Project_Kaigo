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
		private IAnimationSetting _animSetting = null;

		private float _prevVelX = 0f;

		internal void Init (Animator anim, ILocomotion loco, ICharacterStat stat, IAnimationSetting animSetting)
		{
			_anim = anim;
			_loco = loco;
			_stat = stat;
			_animSetting = animSetting;
		}

		internal void HandleUpdate ()
		{
			if (_loco.HasTargetLocked)
			{
				_anim.SetFloat (_paramVelocityXID, _loco.MoveVelocity.x / _stat.MoveForwardSpeed, _animSetting.MoveDampTime, Time.deltaTime);
				_anim.SetFloat (_paramVelocityZID, _loco.MoveVelocity.z / _stat.MoveForwardSpeed, _animSetting.MoveDampTime, Time.deltaTime);
				_prevVelX = _loco.MoveVelocity.x;
			}
			else
			{
				if (_prevVelX != 0f)
					_prevVelX = 0f;

				_anim.SetFloat (_paramVelocityZID, _loco.MoveSpeed / _stat.MoveForwardSpeed, _animSetting.MoveDampTime, Time.deltaTime);
			}
		}
	}
}
