using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public int id = 0;
    public bool filled = false;

    public Image itemImage;
    public TextMeshProUGUI itemName;

    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponentInChildren<Image>();
        itemName = GetComponentInChildren<TextMeshProUGUI>();

        // Set the item name to nothing if the slot is empty at Start
        if (!filled)
            itemName.text = "";

        anim = GetComponent<Animator>();

        GameManager.Instance.InventorySlotRegistry(this);
    }

    // Called when adding an item to the inventory, add the name and image to the slot
    public void AddToSlot(Sprite image, string name)
    {
        itemImage.sprite = image;
        itemName.text = name;
        filled = true;
    }

    public void RemoveFromSlot()
    {
        itemImage.sprite = null;
        itemName.text = "";
        filled = false;
    }

    public void ChangeSprite()
    {
        // Check if the currently selected slot id the same as this one
        if (GameManager.Instance.selectedSlotIndex == id)
        {
            // Change to active
            anim.SetBool("Selected", true);
            //Debug.Log("Slot: " + id + " is now active.");
        }
        else
        {
            // Change to idle
            anim.SetBool("Selected", false);
        }
    }
}
