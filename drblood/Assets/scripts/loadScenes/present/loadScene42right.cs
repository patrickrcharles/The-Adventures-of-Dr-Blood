using UnityEngine;
using System.Collections;

public class loadScene42right : MonoBehaviour {

	
		void OnTriggerEnter2D(Collider2D collider)
		{
			// If the player hits the trigger.
			if (collider.gameObject.tag == "Player")
			{
				Application.LoadLevel("scene42right");
			}
		}
}
