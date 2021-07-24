namespace Kaigo.Runtime.Camera.Input
{
	using IDCInput = Z.CameraDungeonCrawler.Runtime.IInput;
	using ITPInput = Z.CameraThirdPerson.Runtime.IInput;

	internal interface IInput : ITPInput, IDCInput { }
}
