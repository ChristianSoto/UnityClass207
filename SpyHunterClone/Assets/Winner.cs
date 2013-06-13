using UnityEngine;
using System.Collections;

public class Winner : MonoBehaviour {
	public Texture win;
	public Texture lose;
	
	private bool gameWinner = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter(Collider other)
	{
		if (!gameWinner)
		{
			switch (other.name)
				{
				case "PlayerTop":
				{
					GetComponent<screenTexture>().aTexture = win;
					GetComponent<screenTexture>().enabled = true;
					gameWinner = true;
					Pause();
					Application.LoadLevel ("StartMenuScene");
					break;
				}
				case "CarTopEnemy":
				{			
					GetComponent<screenTexture>().aTexture = lose;
					GetComponent<screenTexture>().enabled = true;
					gameWinner = true;
					Pause ();
					Application.LoadLevel ("StartMenuScene");
					break;
				}
			}
		}
	}
	
	IEnumerator Pause() {
        yield return new WaitForSeconds(5);
    }
}

