using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public int doorID = 0;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
        anim = GetComponent<Animator>();
    }

    public void Action(PlayerManager player)
    {
        if (player.GetInventory().CanOpenDoor(doorID))
        {
            anim.SetBool("Open", true);
        }
        else
        {
            Debug.Log("Cannot open this door, it's ID is: " + doorID);
        }
    }
}
