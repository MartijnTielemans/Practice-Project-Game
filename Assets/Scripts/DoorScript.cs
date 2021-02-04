using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public int doorID = 0;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        if (player.GetInventory().CanOpenDoor(doorID))
        {
            Destroy(gameObject);
        }
        else
        {
            Debug.Log("Cannot open this door, it's ID is: " + doorID);
        }
    }
}
