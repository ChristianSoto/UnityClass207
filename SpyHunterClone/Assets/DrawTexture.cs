using UnityEngine;
using System.Collections;

[ExecuteInEditMode()] 
public class DrawTexture : MonoBehaviour {
	
	public Texture aTexture;
	public Texture bTexture;
	public CarControl car;
	public int ratio = 3;
		
    public float angle = 0;
    public Vector2 size = new Vector2(128, 128);
    Vector2 pos = new Vector2(0, 0);
    Rect rect;
    Vector2 pivot;
	
	// Use this for initialization
	void Start () {
		car = GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent<CarControl>();
		UpdateSettings();
	}
	
	// Update is called once per frame
	void Update () {
		angle = Mathf.Clamp (car.Speed * 2.26f, 0f, 359f);
	}
	
	void UpdateSettings() {
        pos = new Vector2(transform.localPosition.x, transform.localPosition.y);
        rect = new Rect(Screen.width - bTexture.width / ratio, 0, bTexture.width / ratio, bTexture.height / ratio);
        pivot = new Vector2(rect.xMin + rect.width * 0.5f, rect.yMin + rect.height * 0.5f);
    }
	
    void OnGUI() {
		if (Application.isEditor) { UpdateSettings(); }
        Matrix4x4 matrixBackup = GUI.matrix;
        GUIUtility.RotateAroundPivot(angle, pivot);
		GUI.DrawTexture(rect, bTexture, ScaleMode.StretchToFill, true, 5.0F);
        GUI.matrix = matrixBackup;
		
        if (!aTexture) {
            Debug.LogError("Assign a Texture in the inspector.");
            return;
        }
        GUI.DrawTexture(new Rect(Screen.width - aTexture.width / ratio, 0, aTexture.width / ratio, aTexture.height / ratio), aTexture, ScaleMode.StretchToFill, true, 5.0F);		
    }
}