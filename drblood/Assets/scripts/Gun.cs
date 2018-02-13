using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {

	Collision2D coll;
	public Item item;
	public PlatformerCharacter2D character;
	public bool inInventory;
	
	
	// Use this for initialization
	void Start () {

	}
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			item = new Item ("Gun", 5, "It appears to be a toy laser gun.  Pew pew!", Item.ItemType.Permanent);
			inInventory = true;
			Destroy(gameObject);
			character.hasGun = true;
			
		}
		
	}
}
