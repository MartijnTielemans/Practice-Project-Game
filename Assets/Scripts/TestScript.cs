using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public InventoryScript inventory;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("============ Testing Item Creation ===============");
        TestCreateAccessItem();
        TestCreateBonusItem();


        Debug.Log("============ Testing Inventory functions ===============");
        TestInventoryFunction();
    }

    public void TestCreateAccessItem()
    {
        // Make an Item, not accessitem, because then is the same type as the rest of the items
        Item key = new AccessItem("Gold Key", 10, 0);
        DebugLogItem(key);
    }

    public void TestCreateBonusItem()
    {
        Item candy = new BonusItem("Chocolate Bar", 2, 250);
        DebugLogItem(candy);
    }

    public void TestInventoryFunction()
    {
        Item key = new AccessItem("Gold Key", 20, 0);
        Item chocolateBar = new BonusItem("Chocolate Bar", 60, 250);
        Item popsicle = new BonusItem("Popsicle", 50, 100);

        if (inventory.AddItem(key))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        if (inventory.AddItem(chocolateBar))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        if (inventory.AddItem(popsicle))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        inventory.DebugInventory();

        for (int i = 0; i < 2; i++)
        {
            if (inventory.CanOpenDoor(i))
            {
                Debug.Log("opened door with the ID: " + i);
            }
            else
            {
                Debug.Log("Failed to open door with the ID: " + i);
            }
        }
    }

    void DebugLogItem(Item item)
    {
        string itemInfo = "Item: " + item.GetItemName() + ", weighs: " + item.GetWeightValue();
        string extraInfo = "";

        if (item is AccessItem)
        {
            AccessItem aItem = (AccessItem)item;
            extraInfo = ", weighs: " + aItem.GetWeightValue() + " and opens door: " + aItem.GetDoorID();
        }
        else if (item is BonusItem)
        {
            BonusItem aItem = (BonusItem)item;
            extraInfo = ", weighs: " + aItem.GetWeightValue() + " and counts for: " + aItem.GetPointValue() + " points.";
        }
        
        Debug.Log(itemInfo + extraInfo);
    }
}
