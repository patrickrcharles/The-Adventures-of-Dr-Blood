using UnityEngine;
using System.Collections;

public class loadScene0left : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the player hits the trigger.
		if (collider.gameObject.tag == "Player")
		{
			Application.LoadLevel("scene0left");
		}
	}
}
