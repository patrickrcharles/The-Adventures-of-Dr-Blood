using UnityEngine;
using System.Collections;

public class loadScene0_cave_past1 : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the player hits the trigger.
		if (collider.gameObject.tag == "Player")
		{
			Application.LoadLevel("scene0_cave_past1");
		}
	}
}
