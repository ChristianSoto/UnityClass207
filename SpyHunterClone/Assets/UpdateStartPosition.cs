using UnityEngine;
using System.Collections;

public class UpdateStartPosition : MonoBehaviour {
	
	// Use this for initialization
	public Transform M0;
	public Transform M1;
	public Transform M2;
	public Transform M3;
	public Transform M4;
	
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider other )		
	{		
		CarControl car = GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent ("CarControl") as CarControl;
		switch(other.name)
		{			
			case "M0Line":
				car.StartPosition = new Vector3(295f,100.5f,273f);
				car.LookAtVector = M0;
				break;
			
			case "M1Line":
				car.StartPosition = this.transform.position;
				car.LookAtVector = M1;
			
				break;
			
			case "M2Line":
				car.StartPosition = this.transform.position;
				car.LookAtVector = M2;
				break;
			
			case "M3Line":
				car.StartPosition = this.transform.position;
				car.LookAtVector = M3;
				break;
			
			case "M4Line":
				car.StartPosition = this.transform.position;
				car.LookAtVector = M4;
				break;		
			
		}
		
		
	}
	
}
