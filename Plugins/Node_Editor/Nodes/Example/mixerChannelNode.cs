using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Mixer Channel Input")]
	public class mixerChannelNode : Node 
	{
		public const string ID = "mixerChannelNode";
		public override string GetID { get { return ID; } }

		public override Node Create (Vector2 pos) 
		{
			mixerChannelNode node = CreateInstance<mixerChannelNode> ();

			node.rect = new Rect (pos.x, pos.y, 150, 60);
			node.name = "Mixer Channel";

			node.CreateInput ("Value", "Float");
			node.CreateOutput ("Output val", "Float");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			//GUILayout.Label ("Reverb");

			string[] channels = {"Master", "Voice", "Music", "FX"};

			EditorGUILayout.Popup (0,channels);

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