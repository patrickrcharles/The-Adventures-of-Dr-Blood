using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item {
	public string itemName;
	public int itemID;
	public string itemDescription;
	public Texture2D itemIcon;
	public ItemType itemType;

	public enum ItemType
	{
		Permanent,
		OneTime
	}

	public Item(string name, int id, string description, ItemType type){
		itemName = name;
		itemID = id;
		itemIcon = Resources.Load<Texture2D>("Item Icons/" + name);
		itemDescription = description;
		itemType = type;
	}

	public Item()
	{
		//Constructor
	}
}
