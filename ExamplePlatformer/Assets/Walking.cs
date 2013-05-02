using UnityEngine;
using System.Collections;

public class Walking : MonoBehaviour {
	public Vector3 movement;
	public CharacterController sphereMonster;
	public bool direction;
	public float distance = 0.2f;
	
	// Use this for initialization
	void Start () {
		sphereMonster = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		if (direction)
		{	
			movement.x = distance;
		}
		else
		{
			movement.x = -distance;
		}	
		
		sphereMonster.Move (movement * Time.deltaTime);
		
		
	}
	
	void OnControllerColliderHit(ControllerColliderHit hit) {
	   direction = !direction;
		Debug.Log ("Changing Direction");
		
		if (hit.gameObject.tag  == "Player")
		{
			Debug.Log ("You were hit");
		}
	}
}
