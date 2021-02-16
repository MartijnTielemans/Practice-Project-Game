using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Item
{
    //Properties
    int id;
    string name;
    int weightValue;

    //Constructor
    protected Item(int id, string name, int weightValue)
    {
        this.id = id;
        this.name = name;
        this.weightValue = weightValue;
    }

    protected Item(int weightValue)
    {
        this.name = "DefaultName";
        this.weightValue = weightValue;
    }

    //Methods
    public int GetItemID()
    {
        return id;
    }

    public string GetItemName()
    {
        return name;
    }

    public int GetWeightValue()
    {
        return weightValue;
    }
}
