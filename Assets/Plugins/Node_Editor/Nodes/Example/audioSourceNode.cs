using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;
using UnityEditor;
using System.IO;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Audio Source")]
	public class audioSourceNode : Node 
	{
		public const string ID = "audioSourceNode";
		public override string GetID { get { return ID; } }
		public string filename = "";

		public override Node Create (Vector2 pos) 
		{
			audioSourceNode node = CreateInstance<audioSourceNode> ();

			node.rect = new Rect (pos.x, pos.y, 150, 60);
			node.name = "Audio Source";

			node.CreateInput ("Value", "Float");
			node.CreateOutput ("Output val", "Float");

			return node;
		}

	

		protected internal override void NodeGUI () 
		{
			if (GUILayout.Button ("Select Audio File")) {

				filename = EditorUtility.OpenFilePanel ("Select Audio File", "", "");

			}

			if (filename.Length != 0) {
				GUILayout.Label (Path.GetFileName(filename));
			}



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