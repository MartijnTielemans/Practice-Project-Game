using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : Pickup
{
    public int doorID = 0;
    public bool oneUse = true;

    public override Item CreateItem()
    {
        return new AccessItem(id, itemName, weightValue, doorID, oneUse);
    }
}
