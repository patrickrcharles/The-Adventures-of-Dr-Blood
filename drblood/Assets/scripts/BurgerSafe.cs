using UnityEngine;
using System.Collections;

public class BurgerSafe : MonoBehaviour {

	Collision2D coll;
	public Item item;
	public bool inInventory;
	public PlatformerCharacter2D character;
	
	void OnCollisionEnter2D(Collision2D coll) {
		
		if (coll.gameObject.tag == "Player") {
			item = new Item ("Hamburger", 3, "It's been on the ground! Feed it to someone else.", Item.ItemType.Permanent);
			inInventory = true;
			if(character.hasBurger == false)
				GameObject.Destroy(gameObject);
			character.hasBurger = true;
		}
	}
}
