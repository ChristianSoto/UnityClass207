using UnityEngine;
using System.Collections;
using System.IO;

public class UserName : MonoBehaviour {
	
	public Texture image;
	public ScaleMode scale = ScaleMode.StretchToFill;
	string userName = "Enter your username.";
	string filePath {
		get {
			return Application.persistentDataPath + "/username.txt";
		}
	}
	
	void Start() {
		Debug.Log (filePath);
		try 
		{
			userName = 	File.ReadAllText (filePath);
		}
		catch (FileNotFoundException) {
			userName = "Enter your username here.";
		}	
	}	
	
	void OnGUI()
	{				
	
			GUILayout.BeginHorizontal (); {
				
				GUILayout.Label("Username : ");
				GUI.changed = false;
				
				userName = GUILayout.TextField (userName);
				
				if ( GUI.changed) {
					File.WriteAllText(filePath, userName);
					GUI.changed = false;
				}
				GUILayout.Space (Screen.width - 200);
				GUILayout.Label((1f / Time.deltaTime).ToString() + " FPS");
				
			} GUILayout.EndHorizontal ();		
		
		float x = Screen.width - (Screen.width * .25f);
		float y = Screen.height - Screen.height *.25f;		
		GUI.DrawTexture(new Rect(x,y, Screen.width *.25f, Screen.height * .25f), image, scale);			
		Debug.Log (string.Format ("X: {0} Y: {1}" , x,y));
	}	
}
