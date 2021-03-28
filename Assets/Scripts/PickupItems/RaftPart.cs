using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPart : Pickup
{
    public override Item CreateItem()
    {
        return new RaftItem(id, itemName, weightValue);
    }

    public int GetID()
    {
        return id;
    }
}
