using UnityEngine;
using System.Collections;

public class AntiRollBar : MonoBehaviour {
	
	public WheelCollider WheelLeft;
	public WheelCollider WheelRight;
	public float AntiRoll = 5000.0f;
	public WheelHit hit;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		float travelLeft = 1.0f;
		float travelRight = 1.0f;
		
		bool groundedLeft = WheelLeft.GetGroundHit(out hit);
		if (groundedLeft)
			travelLeft = (-WheelLeft.transform.InverseTransformPoint (hit.point).y - WheelLeft.radius) / WheelLeft.suspensionDistance;
		
		bool groundedRight = WheelRight.GetGroundHit (out hit);
		if (groundedRight)
			travelRight = (-WheelRight.transform.InverseTransformPoint (hit.point).y - WheelRight.radius) / WheelRight.suspensionDistance;
		
		float antiRollForce = (travelLeft - travelRight) * AntiRoll;
		
		if (groundedLeft)
			rigidbody.AddForceAtPosition (WheelLeft.transform.up * -antiRollForce, WheelLeft.transform.position);
		
		if (groundedRight)
			rigidbody.AddForceAtPosition (WheelRight.transform.up * -antiRollForce, WheelRight.transform.position);
			
	}
}
