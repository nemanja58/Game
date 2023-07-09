using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
[System.Serializable]
public class Inventory 
{
[System.Serializable]
public class Slot
{

	public Collectable.CollectableType type;
	public int count;
	public int maxAmount;
	public Slot()
	{
		type = Collectable.CollectableType.NONE;
		count = 0;
		maxAmount = 99;
	}
	public bool CanAddItem()
	{
		if (count < maxAmount)
		{
			return true;
		}
		else
		{
			return false;
		}
	}
		public void AddItem(Collectable.CollectableType type)
		{
			this.type = type;
		}



}



public List<Slot> slots = new List<Slot>();

public Inventory(int numSlots)
{
	for(int i = 0; i < numSlots; i++)
	{
		Slot slot = new Slot();
		slots.Add(slot);
	}
}

public void Add(type typeToAdd)
{
	foreach(Slot slot in slots)
	{
		if(slot.type == typeToAdd && slot.CanAddItem)
		{
			slot.AddItem(typeToAdd);
			return;
		}
	}

	foreach(Slot slot in slots)
	{
		if(slot.type == CollectableType.NONE)
		{
			slot.AddItem(typeToAdd);
			return;
		}
	}
}

}
*/