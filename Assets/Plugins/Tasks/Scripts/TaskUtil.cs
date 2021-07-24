using System.Runtime.CompilerServices;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace Z.Tasks
{
	public static class TaskUtil
	{
		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static async Task DoTask (Task task, CancellationToken ct)
		{
			if (ct.IsCancellationRequested)
				return;

			await task;
		}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static async Task<T> DoTask<T> (Task<T> task, CancellationToken ct)
		{
			if (ct.IsCancellationRequested)
				return default;

			return await task;
		}

		//[MethodImpl (MethodImplOptions.AggressiveInlining)]
		//public static async Task<T> DoTask<T> (Task<T> task, CancellationToken ct) where T : Object
		//{
		//	if (ct.IsCancellationRequested)
		//		return null;

		//	return await task;
		//}

		//[MethodImpl (MethodImplOptions.AggressiveInlining)]
		//public static async Task<List<T>> DoTask<T> (Task<List<T>> task, CancellationToken ct) where T : struct
		//{
		//	if (ct.IsCancellationRequested)
		//		return null;

		//	return await task;
		//}

		[MethodImpl (MethodImplOptions.AggressiveInlining)]
		public static async Task<float> YieldIfOverTimeLimit (float startTime, float timeLimit, CancellationToken ct)
		{
			if (ct.IsCancellationRequested)
				return startTime;

			if (Time.realtimeSinceStartup - startTime < timeLimit)
				return startTime;

			await Task.Yield ();
			return Time.realtimeSinceStartup;
		}
	}
}
