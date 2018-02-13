using UnityEngine;
using System.Collections;

public class bomb : MonoBehaviour {

	Collision2D coll;
	public Item item;
	public bool armed = false;
	Animator anim;
	public PlatformerCharacter2D character;
	public bool inInventory;


	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			item = new Item ("Bomb", 2, "Blows stuff up; especially squishy things.", Item.ItemType.Permanent);
			inInventory = true;
			if(character.hasBomb == false)
				GameObject.Destroy(gameObject);
			character.hasBomb = true;

		}

	}
	
	void Update(){
		if (armed) {
			anim.SetBool ("Armed", armed);
		}	
			
	}

}
