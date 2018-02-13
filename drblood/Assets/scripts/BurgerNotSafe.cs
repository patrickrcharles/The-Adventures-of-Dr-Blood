using UnityEngine;
using System.Collections;

public class BurgerNotSafe : MonoBehaviour {

	Collision2D coll;
	public SceneFadeInOut fader;

	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			fader.EndScene();
			StartCoroutine(WaitAWhile());
			Application.LoadLevel("scene8");
		}
	}

	private IEnumerator WaitAWhile() {
		yield return new WaitForSeconds (2.0f);
		GetComponent<Rigidbody2D>().gravityScale = 10;
	}
}
