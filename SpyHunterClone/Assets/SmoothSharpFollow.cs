using UnityEngine;
using System.Collections;

public class SmoothSharpFollow : MonoBehaviour {
	
	public Transform Target;
	public float Distance = 10.0f;
	public float Height = 5.0f;
	public float HeightDamping = 2.0f;
	public float RotationDamping = 3.0f;
	public float CurrentHeight = 1.0f;
	public float HeightDiff = 1.0f;
	public float MinHeight = 3.0f;
	
	private float wantedRotationAngle;
	private float wantedHeight;
	private float currentRotationAngle;
	private float rotationDamping;
	private float heightDamping;
	private float currentHeight;
	private UnityEngine.Quaternion currentRotation;
	
	
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void LateUpdate () {
		if (!Target)
			return;
		
		// Calculate the current rotation angles
		wantedRotationAngle = Target.eulerAngles.y;
		wantedHeight = Target.position.y + Height;
		
		currentRotationAngle = transform.eulerAngles.y;
		CurrentHeight = transform.position.y;
	
		// Damp the rotation around the y-axis
		currentRotationAngle = Mathf.LerpAngle (currentRotationAngle, wantedRotationAngle, rotationDamping * Time.deltaTime);

		// Damp the height
		CurrentHeight = Mathf.Lerp (CurrentHeight, wantedHeight, heightDamping * Time.deltaTime);

		// Convert the angle into a rotation
		currentRotation = Quaternion.Euler (0, currentRotationAngle, 0);
	
		// Set the position of the camera on the x-z plane to:
		// distance meters behind the target
		transform.position = Target.position;
		transform.position -= currentRotation * Vector3.forward * Distance;			
		
		Vector3 pos = transform.position;
		pos.y = CurrentHeight;		
		transform.position = pos;
		
		// Always look at the target
		transform.LookAt (Target);
	}
}


//		HeightDiff = Target.transform.position.y - CurrentHeight;
//	
//		if (HeightDiff <= 0)
//		{
//			// Set the height of the camera
//			transform.position = new Vector3(transform.position.x, CurrentHeight, transform.position.z);			
//		}
//		else
//		{
//				transform.position = new Vector3(transform.position.x, CurrentHeight + HeightDiff, transform.position.z);
//		}
//		
//		Debug.Log("Diff : " + HeightDiff);