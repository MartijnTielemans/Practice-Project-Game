using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public int doorID = 0;

    Animator anim;
    BoxCollider triggerBox;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Interactable";
        anim = GetComponent<Animator>();
        triggerBox = GetComponent<BoxCollider>();
    }

    public void Action(PlayerManager player)
    {
        if (player.GetInventory().CanOpenDoor(doorID))
        {
            anim.SetBool("Open", true);
            triggerBox.enabled = false;
        }
        else
        {
            Debug.Log("Cannot open this door, it's ID is: " + doorID);

            // TODO: Add a little sound to indicate the door is not opening
        }
    }
}
