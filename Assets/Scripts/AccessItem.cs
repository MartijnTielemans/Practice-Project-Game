using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    int doorID;
    bool oneUse;

    public AccessItem(string name, int weightValue, int doorID, bool oneUse) : base(name, weightValue)
    {
        this.doorID = doorID;
        this.oneUse = oneUse;
    }

    public int GetDoorID()
    {
        return doorID;
    }

    public bool OpensDoor(int ID)
    {
        return doorID == ID;
    }

    public bool GetOneUse()
    {
        return oneUse;
    }
}
