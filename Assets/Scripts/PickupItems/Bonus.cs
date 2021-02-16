using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus : Pickup
{
    public int points = 100;

    public override Item CreateItem()
    {
        return new BonusItem(id, itemName, weightValue, points);
    }
}
