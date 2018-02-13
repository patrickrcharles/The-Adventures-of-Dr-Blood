using UnityEngine;
using System.Collections;

public class dblood_ifshot_fall : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D collider)
	{
		// If the player hits the trigger.
		if (collider.gameObject.tag == "shot" || collider.gameObject.tag == "Player")
		{
			GetComponent<Rigidbody2D>().gravityScale = 10;
		}
	}

	private IEnumerator FallAfterTime() {
		yield return new WaitForSeconds (5.0f);
		GetComponent<Rigidbody2D>().gravityScale = 10;
		yield return new WaitForSeconds (2.0f);
		Application.LoadLevel("scene1");
	}

	void Update(){
		StartCoroutine(FallAfterTime());

	}
	
}
