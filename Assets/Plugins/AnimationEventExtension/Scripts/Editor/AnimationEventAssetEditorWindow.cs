using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using UnityEditor;
using UnityEngine;

namespace Z.DeterministicAnimationEvent.Editor
{
	public class AnimationEventAssetEditorWindow : EditorWindow
	{
		[MenuItem ("Z/AnimationEventWindow (Asset)", false, 0)]
		private static void AnimationEventAssetEditorWindowMenu ()
		{
			GetWindow (typeof (AnimationEventAssetEditorWindow), false, "Animation Event Editor (Asset)");
		}

		private class AnimationEventItem
		{
			internal AnimationEventItem (AnimationEvent e)
			{
				Event = e;
			}

			internal int SelectedIndex = -1;
			internal AnimationEvent Event;
		}

		private Vector2 _scrollPos;
		private int _selectedIndex;

		private bool _isRefreshModel = false;
		private bool _isRefreshAnimator = false;
		private bool _isRefreshClip = false;
		private GameObject _model;
		private ModelImporter _modelImporter;
		private ModelImporterClipAnimation[] _clips;
		private Animator _animator;
		private List<MethodInfo> _eventMethodList = new List<MethodInfo> ();
		private string[] _eventMethodNames;
		private List<AnimationEventItem> _animEventItemList = new List<AnimationEventItem>();

		private void OnFocus ()
		{
			_isRefreshModel = true;
			_isRefreshAnimator = true;
			_isRefreshClip = true;
		}

		private void OnGUI ()
		{
			if (GUILayout.Button ("Refresh"))
			{
				_isRefreshModel = true;
				_isRefreshAnimator = true;
				_isRefreshClip = true;
			}

			EditorGUI.BeginChangeCheck ();
			_model = EditorGUILayout.ObjectField ("Model Object", _model, typeof (GameObject), false) as GameObject;
			if (_model == null)
			{
				ResetAll ();
				return;
			}

			if (EditorGUI.EndChangeCheck () || _isRefreshModel)
			{
				_isRefreshModel = false;
				_modelImporter = AssetImporter.GetAtPath (AssetDatabase.GetAssetPath (_model)) as ModelImporter;
				_clips = _modelImporter.clipAnimations;
			}

			EditorGUI.BeginChangeCheck ();
			_animator = EditorGUILayout.ObjectField ("Animator Object", _animator, typeof (Animator), true) as Animator;
			if (_animator == null)
			{
				ResetAnimator ();
				return;
			}

			if (EditorGUI.EndChangeCheck () || _isRefreshAnimator)
			{
				if (!_isRefreshAnimator)
					_selectedIndex = 0;
				_isRefreshAnimator = false;

				MonoBehaviour [] monoBehaviours = _animator.GetComponents<MonoBehaviour> ();
				_eventMethodList.Clear ();
				List<string> tmpNameList = new List<string> ();

				foreach (MonoBehaviour mono in monoBehaviours)
				{
					Type type = mono.GetType ();
					MethodInfo [] methodInfos = type.GetMethods ();

					IEnumerable<MethodInfo> tmpInfos = methodInfos.Where
					(
						p =>
						p.IsPublic &&
						p.ReturnType == typeof (void) &&
						(p.GetParameters ().Select (q => q.ParameterType).SequenceEqual (new Type [] { }) ||
						p.GetParameters ().Select (q => q.ParameterType).SequenceEqual (new Type [] { typeof (int) }) ||
						p.GetParameters ().Select (q => q.ParameterType.BaseType).SequenceEqual (new Type [] { typeof (Enum) }) ||
						p.GetParameters ().Select (q => q.ParameterType).SequenceEqual (new Type [] { typeof (float) }) ||
						p.GetParameters ().Select (q => q.ParameterType).SequenceEqual (new Type [] { typeof (string) }) ||
						p.GetParameters ().Select (q => q.ParameterType).SequenceEqual (new Type [] { typeof (UnityEngine.Object) }))
					);
					_eventMethodList.AddRange (tmpInfos);

					foreach (MethodInfo info in tmpInfos)
					{
						ParameterInfo [] paramInfos = info.GetParameters ();
						if (paramInfos.Length == 0)
							tmpNameList.Add (type + "." + info.Name + " ( )");
						else
							tmpNameList.Add (type + "." + info.Name + " ( " + paramInfos [0].ParameterType + " )");
					}
				}
				_eventMethodNames = tmpNameList.ToArray ();
			}

			if (_modelImporter == null)
			{
				EditorGUILayout.HelpBox ("Not a model!", MessageType.Warning);
				return;
			}

			List<string> clipNameList = new List<string> ();
			foreach (ModelImporterClipAnimation clip in _clips)
				clipNameList.Add (clip.name);

			EditorGUI.BeginChangeCheck ();
			_selectedIndex = EditorGUILayout.Popup (_selectedIndex, clipNameList.ToArray ());
			if (EditorGUI.EndChangeCheck () || _isRefreshClip)
			{
				_isRefreshClip = false;
				if (_selectedIndex >= _clips.Length)
				{
					_selectedIndex = 0;
					EditorGUILayout.HelpBox ("No animation found!", MessageType.Warning);
					return;
				}

				Debug.Log ("currentClip.name=" + _clips [_selectedIndex].name + ", currentClip.events.Length=" + _clips [_selectedIndex].events.Length);
				// create list for editor UI display
				_animEventItemList.Clear ();
				foreach (AnimationEvent animEvent in _clips [_selectedIndex].events)
					_animEventItemList.Add (new AnimationEventItem (animEvent));
				_animEventItemList.Sort ((i1, i2) => i1.Event.time.CompareTo (i2.Event.time));
			}

			if (_animEventItemList.Count == 0 || _eventMethodList.Count == 0)
			{
				_isRefreshModel = true;
				_isRefreshAnimator = true;
				_isRefreshClip = true;

				return;
			}

			_scrollPos = EditorGUILayout.BeginScrollView (_scrollPos);

			foreach (AnimationEventItem item in _animEventItemList)
			{
				AnimationEvent animEvent = item.Event;
				int frame = (int) decimal.Round (new decimal (animEvent.time * (_clips [_selectedIndex].lastFrame - _clips [_selectedIndex].firstFrame)));

				EditorGUILayout.LabelField (item.Event.functionName + " (event at frame " + frame + ")", EditorStyles.boldLabel);

				//
				if (item.SelectedIndex == -1)
					item.SelectedIndex = _eventMethodList.FindIndex ((MethodInfo x) => (x.Name == animEvent.functionName));
				item.SelectedIndex = EditorGUILayout.Popup ("Function", item.SelectedIndex, _eventMethodNames);
				if (item.SelectedIndex == -1)
				{
					Debug.LogError ("functionName=" + animEvent.functionName + ", is not found in Animator scripts!");
					continue;
				}
				else
					animEvent.functionName = _eventMethodList [item.SelectedIndex].Name;

				//
				EditorGUI.indentLevel++;

				//
				frame = EditorGUILayout.IntSlider ("Frame " + frame, frame, 0, Mathf.RoundToInt (_clips [_selectedIndex].lastFrame - _clips [_selectedIndex].firstFrame));
				animEvent.time = frame / (_clips [_selectedIndex].lastFrame - _clips [_selectedIndex].firstFrame);

				//
				MethodInfo info = _eventMethodList [item.SelectedIndex];
				ParameterInfo [] paramInfos = info.GetParameters ();
				if (paramInfos.Length == 1)
				{
					Type paramType = paramInfos [0].ParameterType;
					if (paramType == typeof (int) || paramType.BaseType == typeof (Enum))
						animEvent.intParameter = EditorGUILayout.IntField ("Param Int", animEvent.intParameter);
					else if (paramType == typeof (float))
						animEvent.floatParameter = EditorGUILayout.FloatField ("Param Float", animEvent.floatParameter);
					else if (paramType == typeof (string))
						animEvent.stringParameter = EditorGUILayout.TextField ("Param String", animEvent.stringParameter);
					else if (paramType == typeof (UnityEngine.Object))
						animEvent.objectReferenceParameter = EditorGUILayout.ObjectField ("Param Object Ref", animEvent.objectReferenceParameter, typeof (UnityEngine.Object), true);
				}

				//
				EditorGUI.indentLevel--;

				EditorGUILayout.Space ();
			}

			EditorGUILayout.EndScrollView ();

			// add new event button
			/*if (GUILayout.Button("Add Event"))
			{
				_animEventItemList.Add(new AnimationEvent());
			}*/

			GUI.color = Color.green;
			if (GUILayout.Button ("Save"))
			{
				SaveAnimation ();
				_modelImporter.SaveAndReimport ();
				Debug.Log ("Save: currentClip.name=" + _clips [_selectedIndex].name);
			}
			GUI.color = Color.white;
		}

		private void SaveAnimation ()
		{
			if (_selectedIndex < _clips.Length && _clips != null && _animEventItemList.Count > 0)
			{
				List<AnimationEvent> tmpList = new List<AnimationEvent> ();
				foreach (AnimationEventItem item in _animEventItemList)
					tmpList.Add (item.Event);
				_modelImporter.clipAnimations = _clips;
			}
		}

		private void ResetAll ()
		{
			_selectedIndex = 0;
			_model = null;
			_animator = null;
			_modelImporter = null;
			_clips = null;
			_eventMethodNames = null;
			_eventMethodList.Clear ();
			_animEventItemList.Clear ();
		}

		private void ResetAnimator ()
		{
			_selectedIndex = 0;
			_animator = null;
			_eventMethodNames = null;
			_eventMethodList.Clear ();
			_animEventItemList.Clear ();
		}
	}
}
