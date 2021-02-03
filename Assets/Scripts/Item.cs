using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    //Properties
    string name;
    int weightValue;

    //Constructor
    protected Item(string name, int weightValue)
    {
        this.name = name;
        this.weightValue = weightValue;
    }

    protected Item(int weightValue)
    {
        this.name = "DefaultName";
        this.weightValue = weightValue;
    }

    //Methods
    public string GetItemName()
    {
        return name;
    }

    public int GetWeightValue()
    {
        return weightValue;
    }
}
