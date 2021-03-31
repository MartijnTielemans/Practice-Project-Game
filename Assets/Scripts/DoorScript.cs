using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour, IInteractable
{
    public int doorID = 0;
    public bool noKey = false;

    public AudioSource openSound;
    public AudioSource lockSound;

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
        if (player.GetInventory().CanOpenDoor(doorID, noKey))
        {
            anim.SetBool("Open", true);
            triggerBox.enabled = false;
            openSound.Play();
        }
        else
        {
            Debug.Log("Cannot open this door, it's ID is: " + doorID);
            lockSound.Play();
        }
    }
}
