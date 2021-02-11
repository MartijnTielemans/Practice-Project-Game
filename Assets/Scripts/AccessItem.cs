using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AccessItem : Item
{
    int doorID;
    bool oneUse;

    public AccessItem(int id, string name, int weightValue, Sprite image, int doorID, bool oneUse) : base(id, name, weightValue, image)
    {
        this.doorID = doorID;
        this.oneUse = oneUse;
    }

    public int GetDoorID()
    {
        return doorID;
    }

    public bool GetOneUse()
    {
        return oneUse;
    }

    public bool OpensDoor(int ID)
    {
        return doorID == ID;
    }
}
