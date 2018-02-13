using UnityEngine;
using System.Collections;

public class timeMachine_planet1 : MonoBehaviour {

	
	void OnTriggerEnter2D(Collider2D collider)
	{

		// If the player hits the trigger.
		if (collider.gameObject.tag == "Player")
		{
			GetComponent<AudioSource>().Play();
			Application.LoadLevel ("scene1_planet1");

		}
	}


}
