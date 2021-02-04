using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Access : Pickup
{
    public int doorID = 0;

    public override Item CreateItem()
    {
        return new AccessItem(itemName, weightValue, doorID);
    }
}
