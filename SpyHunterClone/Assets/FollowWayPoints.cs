using UnityEngine;
using System.Collections;

public class FollowWayPoints : MonoBehaviour {
	SortedList list = new SortedList();
	GameObject current;
	
	
	// Use this for initialization
	void Start () {
		foreach (GameObject waypoint in GameObject.FindGameObjectsWithTag ("WayPoints"))
		{
			Debug.Log (waypoint.name);
		}				
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
