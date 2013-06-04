using UnityEngine;
using System.Collections;

public class EnemyAI : MonoBehaviour {
	public float Turn = 0;
	public float Acceleration = 0;
	public WheelCollider Wheel_LF;
	public WheelCollider Wheel_RF;
	public WheelCollider Wheel_RR;
	public WheelCollider Wheel_LR;
	public float torque;
	public float Speed;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void FixedUpdate() {
		Speed = this.rigidbody.velocity.sqrMagnitude;
		
		if (Speed > 120)
		{
			torque = 0;
		}
		else
		{
			torque = 100;
		}
		
		Wheel_LR.motorTorque = Acceleration * torque * Time.deltaTime;
		Wheel_RR.motorTorque = Acceleration * torque * Time.deltaTime;			
		
		Wheel_RF.steerAngle = Turn * 15;
		Wheel_LF.steerAngle = Turn * 15;
	}
}
