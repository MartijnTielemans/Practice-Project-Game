using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public string itemName;
    public int weightValue;

    void Start()
    {
        gameObject.tag = "Interactable";
    }

    public void Action(PlayerManager player)
    {
        if (player.AddItem(CreateItem(), gameObject))
            gameObject.SetActive(false);
    }

    public abstract Item CreateItem();
}
