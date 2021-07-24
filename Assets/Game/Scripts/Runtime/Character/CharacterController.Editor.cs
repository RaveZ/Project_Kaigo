using UnityEngine;

namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController : MonoBehaviour
	{
#if UNITY_EDITOR
		[Header ("Editor Only")]
		[SerializeField]
		private bool _useAwakeToInit = false;

		private void Awake ()
		{
			if (_useAwakeToInit)
				Init ();
		}
#endif
	}
}
