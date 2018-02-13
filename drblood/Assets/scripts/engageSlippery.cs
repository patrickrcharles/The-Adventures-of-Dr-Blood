using UnityEngine;
using System.Collections;

public class engageSlippery : MonoBehaviour {

	public PlatformerCharacter2D character;
	bool startSlippery;
	bool isSliding = false;

	// Use this for initialization
	void Start () {
		startSlippery = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (character.hasJetPack) {
			character.GetComponent<Rigidbody2D>().gravityScale = 1;
			isSliding = false;
			character.anim.SetBool("isSliding", isSliding);
		}
		if (character.hasJetPack == false && startSlippery)
			character.GetComponent<Rigidbody2D>().gravityScale = 50;
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.tag == "Player") {
			startSlippery = true;
			character.GetComponent<Rigidbody2D>().gravityScale = 50;
			isSliding = true;
			character.anim.SetBool("isSliding", isSliding);
		}

	}



}
