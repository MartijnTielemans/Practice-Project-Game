using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    int doorID;

    public AccessItem(string name, int weightValue, int doorID) : base(name, weightValue)
    {
        this.doorID = doorID;
    }

    public int GetDoorID()
    {
        return doorID;
    }

    public bool OpensDoor(int ID)
    {
        return doorID == ID;
    }
}
