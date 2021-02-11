﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<int, Pickup> worldItems = new Dictionary<int, Pickup>();
    Dictionary<int, InventorySlot> inventorySlots = new Dictionary<int, InventorySlot>();

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
            Debug.Log("Added a slot with ID: " + slot.id);
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

    public void AddToSlot(int id, Sprite i, string name)
    {
        inventorySlots[id].AddToSlot(i, name);
    }
}
