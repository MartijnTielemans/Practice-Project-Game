using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestCreateAccessItem();
        TestCreateBonusItem();
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
