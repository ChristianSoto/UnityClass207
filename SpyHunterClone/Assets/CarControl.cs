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
	public int BoosterPower = 120;
	public AudioClip boosterA;
	public AudioClip engine;
	public AudioSource audio;
	public int revEngine = 1;
	public int BoostCounter = -128;
	
	void OnStart()
	{		
		Boost = false;
	}
	
	void Update()
	{		
		Acceleration = Input.GetAxis ("Vertical");
		Turn = Input.GetAxis ("Horizontal");
		Speed = car.rigidbody.velocity.sqrMagnitude;	
		
		if (Input.GetButton ("Jump") & BoostCounter > 1)
		{
			//Acceleration = 1;			
			LeftBooster.enabled = true;
			RightBooster.enabled = true;
			LeftFlame.Emit (1);			
			RightFlame.Emit (1);	
			LeftSmoke.Emit (1);
			RightSmoke.Emit (1);
			Boost = true;	
			if (BoostCounter > 1)
			{
				BoostCounter --;
			}
		}
		else
		{
			LeftBooster.enabled = false;
			RightBooster.enabled = false;			
			torque = 600;
			Boost = false;
		}
		
		if (Speed > MaxSpeed )
		{
			torque = 0;	
		}	
	}
		
 
	void FixedUpdate () {	
	
	WayPointCollection wpc = GameObject.FindGameObjectWithTag("WayPointContainer").GetComponent ("WayPointCollection") as WayPointCollection;	
	//Debug.Log (wpc.GetNearestWayPoint (car.position).Number);
		
	if (Acceleration == 1f)
	{
		if (revEngine < 100)				
		{
			revEngine++;	
		}
	}
	else
	{
		if (revEngine > 1)				
		{
			revEngine--;	
		}
	}		
		
	rearWheel1.motorTorque = Acceleration * torque;
	rearWheel2.motorTorque = Acceleration * torque;			
	frontWheel1.steerAngle = Turn * 20;
	frontWheel2.steerAngle = Turn * 20;
	if (Boost)
	{
		audio.pitch = 1f;
		audio.clip = boosterA;
		car.transform.rigidbody.AddForce (-car.transform.forward * BoosterPower, ForceMode.Acceleration);
	}
	else			
	{
		audio.pitch = 0.03f * float.Parse (revEngine.ToString()) + .75f;
		audio.clip = engine;		
	}
		
	if (!audio.isPlaying)
	{		
		audio.Play();
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
