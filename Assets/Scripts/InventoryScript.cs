using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour
{
    List<Item> Inventory = new List<Item>();

    int totalWeight = 0;
    public int maxWeight = 120;

    // Add an item to the inventory list, if it succeeded in finding it and it wouldn't exceed the maxWeight
    public bool AddItem(Item i)
    {
        if ((totalWeight + i.GetWeightValue()) <= maxWeight)
        {
            Inventory.Add(i);
            totalWeight += i.GetWeightValue();
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
            totalWeight += i.GetWeightValue();

        return success;
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
                if (((AccessItem)item).OpensDoor(ID))
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
