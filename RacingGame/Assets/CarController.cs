using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {
	
	public WheelCollider rearWheel1;
	public WheelCollider rearWheel2;
	public WheelCollider frontWheel1;
	public WheelCollider frontWheel2;
	public Rigidbody rigidbody;
	public Camera camera;
	public int torque;

	void OnStart()
	{
		rigidbody.centerOfMass = new Vector3(0f, -1, 0f);
	}
 
	void FixedUpdate () {
	
	rearWheel1.motorTorque = -Input.GetAxis ("Vertical") * torque;
	rearWheel2.motorTorque = -Input.GetAxis ("Vertical") * torque;
	frontWheel1.steerAngle = Input.GetAxis ("Horizontal") * 10;
	frontWheel2.steerAngle = Input.GetAxis ("Horizontal") * 10;
		
	Debug.Log (string.Format ("H: {0} V: {1}" ,frontWheel2.steerAngle, rearWheel1.motorTorque ));
	
			

	}			
}
