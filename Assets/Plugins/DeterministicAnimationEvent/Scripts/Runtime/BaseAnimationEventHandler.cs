using System;
using System.Collections.Generic;
using UnityEngine;

namespace Z.DeterministicAnimationEvent.Runtime
{
	public abstract class BaseAnimationEventHandler : MonoBehaviour
	{
		private class EventData
		{
			internal float NormalizedTime { get; private set; }
			internal AnimEventAction ActionToBeExecute { get; private set; }
			internal int ID { get; private set; }

			internal EventData (float normalizedTime, AnimEventAction actionToBeExecute, int id)
			{
				NormalizedTime = normalizedTime;
				ActionToBeExecute = actionToBeExecute;
				ID = id;
			}

			internal void Dispose ()
			{
				ActionToBeExecute = null;
			}
		}

		private delegate void AnimEventAction (int id);

		[SerializeField]
		private AnimationClip[] _observedClips = null;

		private Animator _anim;
		private Dictionary<AnimationClip, EventData[]> _eventsDict;

		private void OnDestroy ()
		{
			if (_eventsDict == null)
				return;

			foreach (EventData [] eventData in _eventsDict.Values)
				DestroyEventData (eventData);
			_eventsDict.Clear ();
		}

		private void DestroyEventData (EventData [] eventData)
		{
			for (int i = 0; i < eventData.Length; ++i)
				eventData [i].Dispose ();
		}

		public void Init (Animator anim)
		{
			_anim = anim;

			InitAnimEvents ();
		}

		private void InitAnimEvents ()
		{
			_eventsDict = new Dictionary<AnimationClip, EventData []> (10);
			for (int i = 0; i < _observedClips.Length; ++i)
				AddAnimEvents (_observedClips [i]);
		}

		private void AddAnimEvents (AnimationClip clip)
		{
			if (clip == null)
				return;

			EventData [] eventData = new EventData [clip.events.Length];
			for (int j = 0; j < clip.events.Length; ++j)
			{
				AnimEventAction action = (AnimEventAction) Delegate.CreateDelegate (typeof (AnimEventAction), this, GetType ().GetMethod (clip.events [j].functionName));
				eventData [j] = new EventData (clip.events [j].time / clip.length, action, clip.events [j].intParameter);
			}
			_eventsDict.Add (clip, eventData);
		}

		private void RemoveAnimEvents (AnimationClip clip)
		{
			if (clip == null)
				return;

			_eventsDict.Remove (clip);
		}

		internal void ExecuteAllSkippedEventsInAnimatorStateInfo (AnimationClip animationClip, float endTime)
		{
			if (_eventsDict.TryGetValue (animationClip, out EventData [] eventData))
				ExecuteAllSkippedEventsInAnimationClip (eventData, endTime);
		}

		private void ExecuteAllSkippedEventsInAnimationClip (EventData [] eventsData, float endTime)
		{
			for (int i = 0; i < eventsData.Length; ++i)
			{
				if (eventsData [i].NormalizedTime >= endTime)
					eventsData [i].ActionToBeExecute.Invoke (eventsData [i].ID);
			}
		}
	}
}
