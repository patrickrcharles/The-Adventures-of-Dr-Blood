using UnityEngine;
using System.Collections;

public class JetPack : MonoBehaviour {
	
	public PlatformerCharacter2D character;
	public bool inInventory = false;
	Collision2D coll;
	public Item item;

	void Start(){
		if (inInventory) {
			GameObject.Destroy (gameObject);
		}
	}


	// Use this for initialization
	void OnCollisionEnter2D(Collision2D coll) {

				if (coll.gameObject.tag == "Player") {
						item = new Item ("JetPack", 1, "It's a jet pack.  Figure it out.", Item.ItemType.Permanent);
						inInventory = true;
						Destroy(gameObject);
						
				}
	}

}
