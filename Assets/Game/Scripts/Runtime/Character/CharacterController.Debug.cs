using UnityEngine;
using Z.UnityHelper.TransformUtil;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController : MonoBehaviour, ITransform
	{
#if UNITY_EDITOR || DEVELOPMENT_BUILD
		[Header ("Editor Only")]
		[SerializeField]
		private bool _useAwakeToInit = false;

		private async void Awake ()
		{
			await AppController.WaitTillReady ();

			if (_useAwakeToInit)
				Init ();
		}
#endif
	}
}
