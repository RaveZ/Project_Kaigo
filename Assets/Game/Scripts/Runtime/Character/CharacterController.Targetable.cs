namespace Kaigo.Runtime.Character
{
	internal partial class CharacterController
	{
		public bool CanBeLock
		{
			get
			{
				return _cam.IsRendered (GetBounds ());
			}
		}
	}
}
