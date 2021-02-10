using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript
{
    List<Item> Inventory;
    List<GameObject> GameObjects;

    int totalWeight;
    private int maxWeight;

    public InventoryScript()
    {
        Inventory = new List<Item>();
        GameObjects = new List<GameObject>();
        totalWeight = 0;
        maxWeight = 120;
    }

    public InventoryScript(int maxWeight) : this()
    {
        this.maxWeight = maxWeight;
    }

    // For dropping the last item
    public GameObject DropLastItem()
    {
        GameObject go = RemoveItem(Inventory.Count - 1);

        return go;
    }

    public bool AddItem(Item i, GameObject go)
    {
        bool result = AddItem(i);

        if (result)
            GameObjects.Add(go);

        return result;
    }

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

    public GameObject RemoveItem(int i)
    {
        bool success = RemoveItem(Inventory[i]);

        // Removes the item from te gameobjects list as well
        if (success)
        {
            GameObject returnObject = GameObjects[i];
            GameObjects.Remove(returnObject);

            return returnObject;
        }

        return null;
    }

    // Remove an item from the inventory list, if it succeeded in finding it
    public bool RemoveItem(Item i)
    {
        bool success = Inventory.Remove(i);

        if (success)
            totalWeight -= i.GetWeightValue();

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

                    //if (((AccessItem)item).GetOneUse())
                    //{
                    //    RemoveItem(item);
                    //}
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
