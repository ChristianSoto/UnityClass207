using UnityEngine;
using System.Collections;

public class Stick : MonoBehaviour {
	
	public Transform stickyTransform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = stickyTransform.position;
	}
}
