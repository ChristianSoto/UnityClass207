using UnityEngine;
using System.Collections;

[ExecuteInEditMode()] 
public class StartMenu : MonoBehaviour {
	public Texture easyBtn;
	public Texture normalBtn;
	public Texture hardBtn;
	
	public GameStatePersistence gsp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
		
    void OnGUI() {        
  
		GUI.depth = -1;
        if (GUI.Button(new Rect(300, 100, 260, 40), easyBtn))
		{
			gsp.gamelevel = 1;	
			Application.LoadLevel ("Level1");
		}

		if (GUI.Button(new Rect(300, 160, 260, 40), normalBtn))           
		{
			gsp.gamelevel = 2;
			Application.LoadLevel ("Level1");
		}
		
		if (GUI.Button(new Rect(300, 220, 260, 40), hardBtn))
        {
			gsp.gamelevel = 3;
			Application.LoadLevel ("Level1");
		}
    }
}
