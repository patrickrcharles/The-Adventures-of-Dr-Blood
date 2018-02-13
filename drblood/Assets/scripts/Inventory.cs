using UnityEngine;
using System.Collections;
using System.Collections.Generic;


public class Inventory : MonoBehaviour {

	public int SlotsX, SlotsY;
	public GUISkin skin;
	public List<Item> inventory = new List<Item> ();
	public bool showInventory = false;
	private ItemDatabase database;
	private bool showTooltip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int prevIndex;

	PlatformerCharacter2D character;

	// Use this for initialization
	void Start () {
		character = GetComponent<PlatformerCharacter2D> ();
		database = GameObject.FindGameObjectWithTag("Item Database").GetComponent<ItemDatabase>();                                             
		for (int i = 0; i < (SlotsX * SlotsY); i++) 
		{
			inventory.Add (new Item());
				
		}

		AddItem (0);
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetButtonDown ("Inventory")) 
		{
			showInventory = !showInventory;	
		}
	
	}

	void OnGUI()
	{
		tooltip = " ";
		GUI.skin = skin;
		if(showInventory)
		{
			DrawInventory();
			if (showTooltip)
			{
				GUI.Box (new Rect(Event.current.mousePosition.x + 15, Event.current.mousePosition.y + 10,200,200), tooltip, skin.GetStyle("Tooltip"));

			}
	    }
        if (draggingItem)
		{
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x, Event.current.mousePosition.y, 50, 50), draggedItem.itemIcon);
		}
	}

	void DrawInventory()
	{
		Event e = Event.current;
		int i = 0;
		for (int y = 0; y < SlotsY; y++)
		{
			for (int x = 0; x < SlotsX; x++)
			{
				Rect slotRect = new Rect(x * 60, y * 60,50,50);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
				Item item = inventory[i];
				if (item.itemName != null)
				{
					if (item.itemIcon != null) GUI.DrawTexture(slotRect, inventory[i].itemIcon);
					if (slotRect.Contains(e.mousePosition))
					{
						tooltip = CreateTooltip(inventory[i]);
						showTooltip = true;
						if (e.button == 0 && e.type == EventType.mouseDrag && !draggingItem)
						{
							draggingItem = true;
							prevIndex = i;
							draggedItem = inventory[i];
							inventory[i] = new Item();
						}
						if (e.type == EventType.mouseUp && draggingItem)
						{
							inventory[prevIndex] = inventory[i];
							inventory[i] = draggedItem;
							draggingItem = false;
							draggedItem = null;
						}
						if (e.isMouse && e.type == EventType.mouseDown && Input.GetButtonDown ("Fire1"))
						{
							if (item.itemType == Item.ItemType.OneTime){
								UseOneTime(item,i,true);
								character.equipped = item.itemID;
							}
						}
					}
				}
				else
				{
					if (slotRect.Contains(e.mousePosition))
					{
						inventory[i] = draggedItem;
						draggingItem = false;
						draggedItem = null;
					}
				}
				if (tooltip == "")
				{
					showTooltip = false;
				}
				i++;
			}
		
		}
	
	}

	string CreateTooltip(Item item)
	{
		tooltip = "<color=#002952><b>" + item.itemName + "</b></color>\n" + "<color=#41A383>" + item.itemDescription + "</color>";
		return tooltip;
	}

	void RemoveItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory[i].itemID == id)
			{
				inventory[i] = new Item();
				break;
			}
		}
	}

	void AddItem(int id)
	{
		for (int i = 0; i < inventory.Count; i++) 
		{
			if (inventory[i].itemName == null)
			{
				if (id < 0)
				{
					print ("Yes, in inventory");
					inventory[i] = new Item();
					break;
				}
				for (int j = 0; j < database.items.Count; j++)
				{
					if (database.items[j].itemID == id)
						inventory[i] = database.items[j];
				}
				break;
			}
		}
	}


	public bool InventoryContains(int id)
	{
		foreach (Item item in inventory)
			if (item.itemID == id)
				return true;
		return false;
	}

	private void UseOneTime(Item item, int slot, bool delete)
	{
		switch (item.itemID)
		{
		case 2:
		{
			print ("Used " + item.itemName);
			break;
		}
		}

	
	}

}











