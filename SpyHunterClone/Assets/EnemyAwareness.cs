using UnityEngine;
using System.Collections;

public class EnemyAwareness : MonoBehaviour {
	public Transform ThisEnemy;
	public bool Front;
	public bool facingFront;
	public float LeftOrRight;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerStay(Collider other )		
	{				
		if (other.name == "PlayerTop")		
		{
			Vector3 playerPos = GameObject.FindGameObjectWithTag ("Player").transform.position;	
			Vector3 heading = playerPos - ThisEnemy.transform.position;	
			
							
			InFront (playerPos);
			
			if (Front == true)
			{
				this.GetComponent <EnemyAI>().Turn = LeftOrRight;	
				Debug.Log ("Turning " + LeftOrRight);
			}
			else
			{
				this.GetComponent <EnemyAI>().Turn = 1f;	
			}
			
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
}
