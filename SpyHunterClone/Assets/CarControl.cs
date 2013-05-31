using UnityEngine;
using System.Collections;

public class CarControl : MonoBehaviour {
	
	public WheelCollider rearWheel1;
	public WheelCollider rearWheel2;
	public WheelCollider frontWheel1;
	public WheelCollider frontWheel2;
	public Transform car;
	public int torque;
	public int stuckCount;
	public Vector3 lastPosition;
	public bool CapWheels;
	public float Speed;
	public float MaxSpeed;
	public float PressureMod = 1;
	
	void OnStart()
	{		
		car.rigidbody.centerOfMass = new Vector3(0f, -1f, 0f);
	}
 
	void FixedUpdate () {
		
	Speed = car.rigidbody.velocity.sqrMagnitude;	
	car.rigidbody.AddForce (0, -Speed * PressureMod, 0);
		
	rearWheel1.motorTorque = Input.GetAxis ("Vertical") * torque;
	rearWheel2.motorTorque = Input.GetAxis ("Vertical") * torque;
	frontWheel1.steerAngle = Input.GetAxis ("Horizontal") * 10;
	frontWheel2.steerAngle = Input.GetAxis ("Horizontal") * 10;
	
	if (Speed > MaxSpeed)
		{
			torque = 0;	
		}
	else
		{
			torque = 100;
		}
		
	
	if (Stuck())
		{
			stuckCount++;
		}
		else
		{			
			stuckCount = 0;
		}
		
	
		
	if (stuckCount > 200)
		{			
			
//			car.rotation.x = 0;
//			car.rotation.y = 180;
			car.position = new Vector3(295f,100.5f,273f);
		}				
	}			
			
	private bool Stuck()
	{
		bool isStuck = false;
		Vector3 c = new Vector3(Round(car.position.x), Round(car.position.y), Round(car.position.z));
		Vector3 lc = new Vector3(Round(lastPosition.x), Round(lastPosition.y), Round(lastPosition.z));
		
		if (Vector3.Distance (lc, c) == 0)
		{
			isStuck = true;
		}
							
		lastPosition = c;
		
		return isStuck;
	}
	
	private float Round(float f)
		{
			return Mathf.RoundToInt (f * 100) / 100;
		}
		
}
