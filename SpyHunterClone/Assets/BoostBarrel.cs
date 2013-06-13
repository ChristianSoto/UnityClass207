using UnityEngine;
using System.Collections;

public class BoostBarrel : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "PlayerTop")
		{
			int boostValue = GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent<CarControl>().BoostCounter;
			if (boostValue + 100 > 256)
			{
			  GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent<CarControl>().BoostCounter = 256;
			}
			else
			{
				GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent<CarControl>().BoostCounter += 100;
			}
			Debug.Log (this.name);
			DestroyObject(gameObject);
		}
	}
}
