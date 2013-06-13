using UnityEngine;
using System.Collections;

public class GameStatePersistence : MonoBehaviour {
	public int gamelevel = 0;
	
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad (gameObject);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
