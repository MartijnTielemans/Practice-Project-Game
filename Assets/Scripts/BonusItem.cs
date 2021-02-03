using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    int pointValue;

    public BonusItem(string name, int weightValue, int pointValue) : base(name, weightValue)
    {
        this.pointValue = pointValue;
    }

    public int GetPointValue()
    {
        return pointValue;
    }
}
