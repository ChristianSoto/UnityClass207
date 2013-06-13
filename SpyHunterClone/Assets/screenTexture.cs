using UnityEngine;
using System.Collections;

[ExecuteInEditMode()] 
public class screenTexture : MonoBehaviour {
	
	public Texture aTexture;
	public float PosX;
	public float PosY;
	public float WidthAdj;
	public float HeightAdj;
	public float ratioX = 3;
	public float ratioY = 3;
	public float defaultAngle = 0;
	public float screenRatioX = 1;
	public float screenRatioY = 1;
	
    public float angle = 0;
    public Vector2 size = new Vector2(128, 128);
    Vector2 pos = new Vector2(128, 128);
    Rect rect;
    Vector2 pivot;	
	public bool FullScreen = false;
	public float EditorWindowX;
	public float EditorWindowY;
	
	// Use this for initialization
	void Start () {		
		UpdateSettings();
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Clamp (defaultAngle, 0f, 359f);
	}
	
	void UpdateSettings() {
		if (Application.isEditor)
		{
			Debug.Log ("Setting editor");
			EditorWindowX = Screen.width;
			EditorWindowY = Screen.height;
		}		
		
		float adjX;
		float adjY;
		if (!FullScreen)
		{
			adjX = aTexture.width / ratioX + WidthAdj;
			adjY = aTexture.height / ratioY + HeightAdj;
		}
		else
		{
			PosX = 0;
			PosY =0;
			adjX = Screen.width;
			adjY = Screen.height;
		}
        rect = new Rect(PosX, PosY, adjX, adjY);
        pivot = new Vector2(rect.xMin + rect.width * 0.5f, rect.yMin + rect.height * 0.5f);
    }
	
    void OnGUI() {
		if (Application.isEditor) { UpdateSettings(); }
        Matrix4x4 matrixBackup = GUI.matrix;
        GUIUtility.RotateAroundPivot(angle, pivot);		
        GUI.matrix = matrixBackup;
		GUI.DrawTexture(rect, aTexture, ScaleMode.StretchToFill, true, 5.0F);		
        if (!aTexture) {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }        
    }
}