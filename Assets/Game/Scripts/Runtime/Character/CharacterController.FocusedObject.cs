using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController
	{
		public ITransform Target => _lockHandler.Target;
	}
}
