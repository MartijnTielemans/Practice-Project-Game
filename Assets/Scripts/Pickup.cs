using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Pickup : MonoBehaviour, IInteractable
{
    public int id;
    public string itemName;
    public int weightValue;
    public Sprite itemImage;

    void Start()
    {
        gameObject.tag = "Interactable";
        GameManager.Instance.RegisterPickupItem(this);
    }

    public void Action(PlayerManager player)
    {
        if (player.AddItem(CreateItem()))
            Remove();
    }

    public void Remove()
    {
        gameObject.SetActive(false);
    }

    public void Respawn(Vector3 position)
    {
        gameObject.transform.position = new Vector3 (position.x, position.y, position.z);
        gameObject.SetActive(true);
    }

    public abstract Item CreateItem();
}
