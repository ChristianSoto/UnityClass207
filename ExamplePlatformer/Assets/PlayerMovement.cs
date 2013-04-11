using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public CharacterController characterController;
	public float horizontalMovementSpeed = 5f;
	public float gravity = 0.1f;
	public Vector3 movement;
	public float aboveGround = 0;
	public bool landed;
	
	// Use this for initialization
	void Start () {
	characterController = GetComponent<CharacterController>();
		
	}
	
	// Update is called once per frame
	void Update () {
	  if(Input.GetKeyDown("space") & landed == true)
		  {
		     aboveGround = 4f;
			 landed = false;
		  }
	  else
		  {
			aboveGround -= gravity * Time.deltaTime;
	      }
			
	  movement.x = Input.GetAxis("Horizontal") * gravity;  
	  movement.y = aboveGround;
	  movement.z = 0;
	  movement = movement * Time.deltaTime;
	  characterController.Move (movement);
	}
	
	 void OnControllerColliderHit(ControllerColliderHit hit) {
		    if (hit.normal.y == 1.0)
				{
		       		landed = true;
				}
	}      
}

