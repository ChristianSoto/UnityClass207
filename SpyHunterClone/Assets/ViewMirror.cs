using UnityEngine;
using System.Collections;

public class ViewMirror : MonoBehaviour {
	public Camera rearCam;
	//public Camera frontCam;
	public Rect mirror;
	
	// Use this for initialization
	void Start () {
		rearCam.rect = new Rect(0,0,1,1);
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
