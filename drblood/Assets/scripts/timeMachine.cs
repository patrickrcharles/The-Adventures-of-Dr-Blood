using UnityEngine;
using System.Collections;

public class timeMachine : MonoBehaviour {

	Collision2D coll;
	public Item item;
	public PlatformerCharacter2D character;
	public bool inInventory;
	
	void OnCollisionEnter2D(Collision2D collider)
	{

		// If the player hits the trigger.
		if (collider.gameObject.tag == "Player")
		{
			item = new Item ("Time Machine", 4, "Wouldn't it be cool to meet yourself in the future?", Item.ItemType.Permanent);
			inInventory = true;
			Destroy(gameObject);
			character.hasTM = true;

		}
	}


}
