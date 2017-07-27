using System.Collections;
using UnityEngine;
using UnityEditor;

public class CustomEditor : EditorWindow {

	GUISkin skin;


	Texture2D background;
	Texture2D mainSectionTexture;
	Color headerSectionColor = new Color(13f/255f, 32f/255f, 44f/255f, 1f);

	Rect headerSection;
	Rect mainSection;

	[MenuItem("Window/Example Editor")]
	static void OpenWindow(){

		CustomEditor window = (CustomEditor)GetWindow(typeof(CustomEditor));
		window.minSize = new UnityEngine.Vector2 (900, 600);
		window.maxSize = new UnityEngine.Vector2 (900, 600);
		window.Show ();

	}
		
	void OnEnable(){
		InitTextures();
		skin = Resources.Load<GUISkin>("guiStyles/editorGUISkin");
	}

	void InitTextures(){

		background = new Texture2D (1, 1);
		background.SetPixel (0, 0, headerSectionColor);
		background.Apply();

	}

	void OnGUI(){
		DrawLayouts();
		DrawHeader();
		DrawMainSection();


	}

	void DrawLayouts(){
		headerSection.x = 0;
		headerSection.y = 0;
		headerSection.width = position.width;
		headerSection.height = 50;

		mainSection.x = 0;
		mainSection.y = headerSection.height;
		mainSection.width = position.width;
		mainSection.height = position.height - 50;


		GUI.DrawTexture (headerSection, background);
		GUI.DrawTexture (mainSection, background);
	}

	void DrawHeader(){
		
		GUILayout.BeginArea (headerSection);
		GUILayout.Label("Interface Demo",skin.GetStyle("headerText"));


		GUILayout.EndArea ();
	}

	void DrawMainSection(){

		GUILayout.BeginArea (mainSection);

		GUILayout.Label ("Position Check");



		GUILayout.EndArea ();

	}
}

