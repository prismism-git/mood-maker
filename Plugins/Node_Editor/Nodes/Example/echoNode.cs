using UnityEngine;
using NodeEditorFramework;
using NodeEditorFramework.Utilities;

namespace NodeEditorFramework.Standard
{
	[Node (false, "Audio Effect/Echo")]
	public class echoNode : Node 
	{
		public const string ID = "echoNode";
		public override string GetID { get { return ID; } }

		public override Node Create (Vector2 pos) 
		{
			echoNode node = CreateInstance<echoNode> ();

			node.rect = new Rect (pos.x, pos.y, 150, 60);
			node.name = "Echo";

			node.CreateInput ("Value", "Float");
			node.CreateOutput ("Output val", "Float");

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