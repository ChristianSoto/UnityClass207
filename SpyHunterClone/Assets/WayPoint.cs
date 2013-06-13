using UnityEngine;
using System.Collections;

public class WayPoint : MonoBehaviour {
	
	public Vector3 Position;
	public int Number;
	
	void Awake()
	{
		Position = transform.position;
		name = "waypoint" + Position.z;
	}
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
