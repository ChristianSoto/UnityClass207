using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	
	public WheelCollider rearWheel1;
	public WheelCollider rearWheel2;
	public WheelCollider frontWheel1;
	public WheelCollider frontWheel2;
	public Rigidbody rigidbody;
	public Camera camera;
 
	void OnStart()
	{
		rigidbody.centerOfMass = new Vector3(0f, -0.05f, 0f);
	}
 
	void FixedUpdate () {
	
	rearWheel1.motorTorque = Input.GetAxis ("Vertical") * 1;
	rearWheel2.motorTorque = Input.GetAxis ("Vertical") * 1;
	frontWheel1.steerAngle = Input.GetAxis ("Horizontal") * 50;
	frontWheel2.steerAngle = Input.GetAxis ("Horizontal") * 50;
		
	Debug.Log (string.Format ("H: {0} V: {1}" ,frontWheel2.steerAngle, rearWheel1.motorTorque ));
	
			

	}			
}
