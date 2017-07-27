﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using System.Reflection;
using System;

namespace MixerData{
		
	public class FetchMixerData : MonoBehaviour {
		public AudioMixer AudMix;
		public AudioMixerGroup[] AudioMixerGroups;
		public AudioMixerSnapshot[] AudioSnapshots;
		public List<string> ExposedParams;
		public List<string>[] GroupEffects;


		// Use this for initialization
		void Start () {

			AudMix = Resources.Load ("MainMixer") as AudioMixer;
			SyncToMixer ();
		}

		// Update is called once per frame
		void Update () {

		}

		public void SyncToMixer()
		{
			Debug.Log("----Syncing to Mixer---------------------------------------------------------------------");
			//Fetch all audio groups under MASTER
			AudioMixerGroups = AudMix.FindMatchingGroups ("Master");

			Debug.Log("----AudioGroups----------------------------------------------------");
			for (int x = 0; x < AudioMixerGroups.Length; x++) {
				//Debug.Log(AudioMixerGroups[x].name);
			}

			//PropertyInfo[] groupPropInf = AudioMixerGroups.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			//MemberInfo[] groupMemberInf = AudioMixerGroups.GetType().GetMembers(BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
			//FieldInfo[] groupFieldInf = AudioMixerGroups.GetType ().GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);


			GroupEffects = new List<string>[AudioMixerGroups.Length];
			for (int x = 0; x < AudioMixerGroups.Length; x++) {
				Debug.Log("AudioGroup " + AudioMixerGroups[x].name + "---------------------------");
				Debug.Log("----Effects----");
				GroupEffects[x] = new List<string>();
				Array effects = (Array)AudioMixerGroups[x].GetType().GetProperty("effects").GetValue(AudioMixerGroups[x], null);
				for(int i = 0; i< effects.Length; i++)
				{
					var o = effects.GetValue(i);
					string effect = (string)o.GetType().GetProperty("effectName").GetValue(o, null);
					GroupEffects[x].Add(effect);
					Debug.Log(effect);
				}
			}

			//PropertyInfo[] PropInf = AudMix.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			//MemberInfo[] MemberInf = AudMix.GetType().GetMembers(BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
			//FieldInfo[] FieldInf = AudMix.GetType ().GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);

			//Exposed Params
			Array parameters = (Array)AudMix.GetType().GetProperty("exposedParameters").GetValue(AudMix, null);

			Debug.Log("----ExposedParams----------------------------------------------------");
			for(int i = 0; i< parameters.Length; i++)
			{
				var o = parameters.GetValue(i);
				string Param = (string)o.GetType().GetField("name").GetValue(o);
				ExposedParams.Add(Param);
				Debug.Log(Param);
			}

			//Snapshots
			AudioSnapshots = (AudioMixerSnapshot[])AudMix.GetType().GetProperty("snapshots").GetValue(AudMix, null);

			Debug.Log("----Snapshots----------------------------------------------------");
			for(int i = 0; i< AudioSnapshots.Length; i++)
			{
				Debug.Log(AudioSnapshots[i].name);
			}

			//PropertyInfo[] snapPropInf = Snapshots.GetType().GetProperties(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);
			//MemberInfo[] snapMemberInf = Snapshots.GetType().GetMembers(BindingFlags.Public|BindingFlags.Static|BindingFlags.Instance);
			//FieldInfo[] snapFieldInf = Snapshots.GetType ().GetFields (BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Static | BindingFlags.Instance | BindingFlags.FlattenHierarchy);


		}
	}
}