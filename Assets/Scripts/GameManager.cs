using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<int, Pickup> worldItems = new Dictionary<int, Pickup>();
    Dictionary<int, InventorySlot> inventorySlots = new Dictionary<int, InventorySlot>();

    public int selectedSlotID = 0;
    int maximumSlots = 6;

    // Singleton
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        selectedSlotID = 0;
    }

    public void RegisterPickupItem(Pickup item)
    {
        if (!worldItems.ContainsKey(item.id))
        {
            worldItems.Add(item.id, item);
        }
        else
        {
            Debug.LogError("There is already an object with this ID: " + item.id);
        }
    }

    public void InventorySlotRegistry(InventorySlot slot)
    {
        // Now add the slot to the Dictionary
        if (!inventorySlots.ContainsKey(slot.id))
        {
            inventorySlots.Add(slot.id, slot);
        }
        else
        {
            Debug.LogError("There are multiple inventory slots with the ID: " + slot.id);
        }
    }

    public void DropItem(int id, Vector3 position)
    {
        worldItems[id].Respawn(position);
    }

    public void AddToSlot(Sprite image, string name)
    {
        // Check if the selected slot is full
        if (!inventorySlots[selectedSlotID].filled)
        {
            inventorySlots[selectedSlotID].AddToSlot(image, name);
        }
        // If it is full, go to the next slot, and repeat that process
        else
        {
            int slotId = selectedSlotID;

            do
            {
                slotId++;

                // It cannot be over six
                if (slotId > maximumSlots)
                    slotId = 1;

            } while (inventorySlots[slotId].filled);

            inventorySlots[slotId].AddToSlot(image, name);
        }
    }

    public void RemoveFromSlot(int id)
    {
        inventorySlots[selectedSlotID].RemoveFromSlot();
    }

    // Gets the sprite of the added item
    public Sprite GetItemSprite(int id)
    {
        if (worldItems.ContainsKey(id))
        {
            return worldItems[id].itemImage;
        }
        else
        {
            return null;
        }
    }

    // Checks every slot and changes their sprite
    public void CheckSlotId()
    {
        foreach (KeyValuePair<int, InventorySlot> i in inventorySlots)
        {
            inventorySlots[i.Key].ChangeSprite();
        }
    }
}
