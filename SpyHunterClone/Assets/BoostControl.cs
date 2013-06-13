using UnityEngine;
using System.Collections;

public class BoostControl : MonoBehaviour {
	
	public CarControl car;
	public screenTexture srnTexture;
	// Use this for initialization
	void Start () {
		car = GameObject.FindGameObjectWithTag ("PlayerGameController").GetComponent<CarControl>();
		srnTexture = GetComponent<screenTexture>();
	}
	
	// Update is called once per frame
	void Update () {
		if (car.BoostCounter > 0)
		{
				
			srnTexture.WidthAdj = car.BoostCounter / 2;
		}
	}
}
