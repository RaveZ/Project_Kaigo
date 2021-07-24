namespace Z.Timer.Runtime
{
	public interface ITimer
	{
		bool IsTicking { get; }
		float Tick { get; }
		float TickNormalized { get; }
		void Restart ();
	}
}
