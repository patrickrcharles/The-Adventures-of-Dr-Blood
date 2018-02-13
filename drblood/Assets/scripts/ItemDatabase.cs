using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();

	public JetPack jetPack;
	public bomb bomb;
	public Gun gun;
	public BurgerSafe burger;
	public timeMachine TM;

	void Start(){
		items.Add(new Item ("Sir Reginald", 0, "Your trustworthy martini that can lend you some advice when you most need it...or just need to get plastered.", Item.ItemType.Permanent));

	}

	void Update(){
		if(jetPack.inInventory)
			items.Add (jetPack.item);
		if (bomb.inInventory)
			items.Add (bomb.item);
		if (gun.inInventory)
			items.Add (gun.item);
		if (burger.inInventory)
			items.Add (burger.item);
		if (TM.inInventory)
			items.Add (TM.item);
	}
}
