using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Audio Effect/Distortion")]
	public class distortionNode : Node 
	{
		public const string ID = "distortionNode";
		public override string GetID { get { return ID; } }

		public override Node Create (Vector2 pos) 
		{
			distortionNode node = CreateInstance<distortionNode> ();

			node.rect = new Rect (pos.x, pos.y, 150, 60);
			node.name = "Distortion";

			node.CreateInput ("Value", "Float");
			node.CreateOutput ("Output val", "Float");

			return node;
		}

		protected internal override void NodeGUI () 
		{
			//GUILayout.Label ("Distortion");

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