using UnityEngine;
using System.Collections;

public class Executioner : MonoBehaviour {

	Collision2D coll;
	public PlatformerCharacter2D character;


	private IEnumerator WaitXTime() {
		character.isAlive = false;
		yield return new WaitForSeconds (3.0f);
		Application.LoadLevel ("scene1");
	}

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Burger") {
			Destroy(gameObject);
		}
		if (coll.gameObject.tag == "Player")
			StartCoroutine (WaitXTime ());

	}

}
