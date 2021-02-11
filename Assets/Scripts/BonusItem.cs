using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusItem : Item
{
    int pointValue;

    public BonusItem(int id, string name, int weightValue, Sprite image, int pointValue) : base(id, name, weightValue, image)
    {
        this.pointValue = pointValue;
    }

    public int GetPointValue()
    {
        return pointValue;
    }
}
