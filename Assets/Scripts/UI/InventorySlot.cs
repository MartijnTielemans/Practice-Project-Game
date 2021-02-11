using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InventorySlot : MonoBehaviour
{
    public int id = 0;

    public Image itemImage;
    public TextMeshProUGUI itemName;

    // Start is called before the first frame update
    void Start()
    {
        itemImage = GetComponentInChildren<Image>();
        itemName = GetComponentInChildren<TextMeshProUGUI>();

        GameManager.Instance.InventorySlotRegistry(this);
    }

    // Called when adding an item to the inventory, add the name and image to the slot
    public void AddToSlot(Sprite image, string name)
    {
        itemImage.sprite = image;
        itemName.text = name;
    }

    public void RemoveFromSlot()
    {
        itemImage.sprite = null;
        itemName.text = null;
    }
}
