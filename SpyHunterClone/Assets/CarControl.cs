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
	public bool Boost = false;
	public float Acceleration;
	public float Turn;
	public Light LeftBooster;
	public Light RightBooster;
	public Vector3 StartPosition = new Vector3(295f,100.5f,273f);
	public Transform LookAtVector;
	public ParticleSystem LeftFlame;
	public ParticleSystem LeftSmoke;
	public ParticleSystem RightFlame;
	public ParticleSystem RightSmoke;
	
	void OnStart()
	{		
		//car.rigidbody.centerOfMass = new Vector3(0f, -1f, 0f);
	}
	
	void Update()
	{		
		Acceleration = Input.GetAxis ("Vertical");
		Turn = Input.GetAxis ("Horizontal");
		Speed = car.rigidbody.velocity.sqrMagnitude;	
		
		if (Input.GetButton ("Jump"))
		{
			Acceleration = 1;			
			LeftBooster.enabled = true;
			RightBooster.enabled = true;
			LeftFlame.Emit (1);			
			RightFlame.Emit (1);	
			LeftSmoke.Emit (1);
			RightSmoke.Emit (1);
			Boost = true;			
		}
		else
		{
			LeftBooster.enabled = false;
			RightBooster.enabled = false;			
			torque = 200;
			Boost = false;
		}
		
		if (Speed > MaxSpeed )
		{
			torque = 0;	
		}	
	}
		
 
	void FixedUpdate () {	
			
	rearWheel1.motorTorque = Acceleration * torque;
	rearWheel2.motorTorque = Acceleration * torque;			
	frontWheel1.steerAngle = Turn * 20;
	frontWheel2.steerAngle = Turn * 20;
	if (Boost)
		{
			car.transform.rigidbody.AddForce (-car.transform.forward * 12, ForceMode.Acceleration);
		}
	
	if (Stuck())
		{
			stuckCount++;
		}
		else
		{			
			stuckCount = 0;
		}
		
	
		
	if (stuckCount > 150)
		{						
			car.position = StartPosition;	
			car.rotation = new Quaternion(0.0f,1.0f,0.0f,0.0f);
			car.LookAt (LookAtVector);
			car.Rotate(new Vector3(0f,180f,0f));
			
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
