using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    List<Item> Inventory;

    int totalWeight;
    private int maxWeight;
    int filledSlots;
    private int maxSlots = 6;

    public InventoryScript()
    {
        Inventory = new List<Item>();
        totalWeight = 0;
        maxWeight = 120;
    }

    public InventoryScript(int maxWeight) : this()
    {
        this.maxWeight = maxWeight;
    }

    // Add an item to the inventory list, if it succeeded in finding it and it wouldn't exceed the maxWeight
    public bool AddItem(Item i)
    {
        if ((totalWeight + i.GetWeightValue()) <= maxWeight && filledSlots < maxSlots)
        {
            Inventory.Add(i);
            totalWeight += i.GetWeightValue();
            filledSlots++;

            Debug.Log("Current slots filled: " + filledSlots);

            return true;
        }
        else
        {
            return false;
        }
    }

    // Remove an item from the inventory list, if it succeeded in finding it
    public bool RemoveItem(Item i)
    {
        bool success = Inventory.Remove(i);

        if (success)
        {
            totalWeight -= i.GetWeightValue();
            filledSlots--;

            Debug.Log("Current slots filled: " + filledSlots);
        }

        return success;
    }

    public Item GetItemWithID(int id)
    {
        for (int i = 0; i < Inventory.Count; i++)
        {
            if (Inventory[i].GetItemID() == id)
            {
                return Inventory[i];
            }
        }

        return null;
    }

    public bool HasItem(Item i)
    {
        return Inventory.Contains(i);
    }

    public bool CanOpenDoor(int ID)
    {
        bool result = false;

        foreach (Item item in Inventory)
        {
            if (item is AccessItem)
            {
                AccessItem i = ((AccessItem)item);

                if (i.OpensDoor(ID))
                {
                    result = true;
                }
            }
        }

        return result;
    }

    public int CountItems()
    {
        return Inventory.Count;
    }

    public int GetCurrentWeight()
    {
        return totalWeight;
    }

    public int GetMaxWeight()
    {
        return maxWeight;
    }

    public void DebugInventory()
    {
        Debug.Log("Inventory has: " + Inventory.Count + " items.");
        Debug.Log("Total weight: " + GetCurrentWeight());

        foreach (Item item in Inventory)
        {
            Debug.Log(item.GetItemName() + " - " + item.GetWeightValue());
        }
    }
}
