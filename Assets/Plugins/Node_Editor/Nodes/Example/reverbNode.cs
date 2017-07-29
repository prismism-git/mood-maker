using UnityEngine;
//using System.Object;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Audio Effect/Reverb")]
	public class reverbNode : Node 
	{
		public const string ID = "reverbNode";
		public override string GetID { get { return ID; } }
		
		public override Node Create (Vector2 pos) 
		{
			reverbNode node = CreateInstance<reverbNode> ();
			
			node.rect = new Rect (pos.x, pos.y, 150, 60);


			node.CreateInput ("Value", "Float");
			node.CreateOutput ("Output val", "Float");

			AudioSource[] sources = Object.FindObjectsOfType (typeof(AudioSource)) as AudioSource[];

			sources [0].Play ();

			node.name = sources [0].name;

		//	audioS = GameObject.AddComponent<AudioSource>();
		//	audioS.clip = Resources.Load ("AudioSamples/Hit") as AudioClip; 
		//	audioS.Play ();

			return node;
		}
		
		protected internal override void NodeGUI () 
		{
			//GUILayout.Label ("Reverb");

			GUILayout.BeginHorizontal ();
			GUILayout.BeginVertical ();

			//Inputs [0].DisplayLayout ();

			GUILayout.EndVertical ();
			GUILayout.BeginVertical ();
			
			//Outputs [0].DisplayLayout ();
			
			GUILayout.EndVertical ();
			GUILayout.EndHorizontal ();
			
		}
		
		public override bool Calculate () 
		{
			if (!allInputsReady ())
				return false;
			Outputs[0].SetValue<float> (Inputs[0].GetValue<float> () * 5);
			return true;
		}
	}
}