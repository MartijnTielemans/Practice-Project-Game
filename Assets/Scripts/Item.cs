using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    //Properties
    string name;
    int weightValue;

    //Constructor
    public Item(string name, int weightValue)
    {
        this.name = name;
        this.weightValue = weightValue;
    }


    public Item(int weightValue)
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
