using Kaigo.Runtime.Character.Stat;
using UnityEngine;
using Z.CharacterLocomotion.Runtime;
using Z.CharacterDefense.Runtime;

namespace Kaigo.Runtime.Character.Animation
{
	[DisallowMultipleComponent]
	internal class AnimationHandler : MonoBehaviour
	{
		private readonly int _paramVelocityXID = Animator.StringToHash ("VelocityX");
		private readonly int _paramVelocityZID = Animator.StringToHash ("VelocityZ");
		private readonly int _paramIsDefenseID = Animator.StringToHash("IsDefense");

		private Animator _anim = null;
		private ILocomotion _loco = null;
		private IDefenseInput _def = null;
		private ICharacterStat _stat = null;
		private IAnimationSetting _animSetting = null;

		private float _prevVelX = 0f;

		internal void Init (Animator anim, ILocomotion loco, ICharacterStat stat, IDefenseInput def, IAnimationSetting animSetting)
		{
			_anim = anim;
			_loco = loco;
			_def = def;
			_stat = stat;
			_animSetting = animSetting;
		}

		internal void HandleUpdate ()
		{
			_anim.SetBool(_paramIsDefenseID, _def.isDefense);

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
