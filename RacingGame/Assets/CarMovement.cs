using UnityEngine;
using System.Collections;

public class CarMovement : MonoBehaviour {
	
	public Vector3 movement; 
	CharacterController car = new CharacterController();
	// Use this for initialization
	void Start () {
		car = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update () {
		
		movement.x = 0; //Input.GetAxis("Horizontal") * 1;
		movement.y = 0;
		movement.z = 0;
		
		movement = transform.TransformDirection(movement);
		car.Move (movement * Time.deltaTime);
	}
}
