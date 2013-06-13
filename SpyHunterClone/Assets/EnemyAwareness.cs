using UnityEngine;
using System.Collections;

public class EnemyAwareness : MonoBehaviour {
	public Transform ThisEnemy;
	public bool EnemyFound;
	public bool Front;
	public bool facingFront;
	public float LeftOrRight;
	public bool Crash = false;
	public bool Far = false;
	public WayPointCollection wpc;
	public WayPoint wp = new WayPoint();
	public WayPoint nextWP;
	public ArrayList wpl = new ArrayList();
	
	// Use this for initialization
	void Start () {	
		wpc = GameObject.FindGameObjectWithTag("WayPointContainer").GetComponent ("WayPointCollection") as WayPointCollection;		
		wp = wpc.GetNearestWayPoint (transform.position, wpl);
	}
	
	// Update is called once per frame
	void Update () {	
		wp = wpc.GetNearestWayPoint (transform.position, wpl);
		if (EnemyFound & Vector3.Distance (wp.Position, ThisEnemy.transform.position) < 70)
		{
			PlotDirection (GameObject.FindGameObjectWithTag ("Player").transform.position);		
		}
		else
		{			
			if (Vector3.Distance (wp.Position, ThisEnemy.transform.position) < 40)
			{
				wpl.Add (wp);				
				Debug.Log ("Forgetting about WP " + wp.name);								
			}			
			
			PlotDirection (wp.Position);		
		}		
	}
	
	void OnTriggerStay(Collider other )		
	{			
		if (other.name == "PlayerTop")		
		{
			EnemyFound = true;			
		}
	}	
	
	void OnTriggerEnter(Collider other)
	{
		if (other.name == "PlayerTop")		
		{
			EnemyFound = true;			
		}
		
		if (other.name == "PlayerCar")
		{
			Debug.Log ("Hit");
		}
	}
	
	void OnTriggerExit(Collider other)
	{
		if (other.name == "PlayerTop")		
		{
			EnemyFound = false;			
		}		
	}
	
	void InFront(Vector3 target)
	{
		Vector3 revPoint = this.transform.InverseTransformPoint (target);

		
		if (revPoint.z < 0.0f)
		{
			Front = true;
		}
		else
		{
			Front = false;
		}
		
		if (revPoint.x > 0.0f)
		{
			LeftOrRight = -1f;
		}
		else
		{
			LeftOrRight = 1f;
		}		
	}	
	
	public void PlotDirection(Vector3 target)
	{

		Vector3 heading = target - ThisEnemy.transform.position;	
		
		if (Vector3.Distance(this.transform.position, target) > 5)
		{
			Far = true;
		}
		else
		{
			Far = false;
		}
						
		this.GetComponent <EnemyAI>().Far = Far;
		
		InFront (target);
		
		this.GetComponent <EnemyAI>().Front = Front;
		
		if (Front == true)
		{
			this.GetComponent <EnemyAI>().Turn = LeftOrRight;					
			//Debug.Log ("Turning " + LeftOrRight);
		}		
	}	
}
