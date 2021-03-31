using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<int, Pickup> worldItems = new Dictionary<int, Pickup>();
    Dictionary<int, InventorySlot> inventorySlots = new Dictionary<int, InventorySlot>();

    public PlayerManager player;

    public int selectedSlotIndex = 0;
    int maximumSlots = 5;

    public AudioSource dropSound;

    [Header("For Ending Sequence")]
    public GameObject fade;
    public TextMeshProUGUI text1;
    public TextMeshProUGUI text2;

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
        selectedSlotIndex = 0;
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

        // Play a funny sound
        dropSound.Play();
    }

    public void AddToSlot(Sprite image, string name)
    {
        // Check if the first slot is full
        if (!inventorySlots[0].filled)
        {
            inventorySlots[0].AddToSlot(image, name);
        }
        // If it is full, go to the next slot, and repeat that process
        else
        {
            int slotId = 0;

            do
            {
                slotId++;

                // It cannot be over six
                if (slotId > maximumSlots)
                    slotId = 0;

            } while (inventorySlots[slotId].filled);

            inventorySlots[slotId].AddToSlot(image, name);
        }
    }

    // Removes the selected item from its slot, then updates the rest of the slots
    public void RemoveFromSlot()
    {
        for (int i = selectedSlotIndex; i < maximumSlots; i++)
        {
            // If the next slot is filled, add that item to this slot, if not, remove the items from this slot
            if (i < player.GetInventory().GetInventory().Count)
            {
                int itemId = player.GetInventory().GetInventory()[i].GetItemID();
                Pickup item = worldItems[itemId];

                inventorySlots[i].AddToSlot(GetItemSprite(item.id), item.itemName);
                Debug.Log("1");
            }
            else
            {
                Debug.Log("2");

                inventorySlots[i].RemoveFromSlot();
            }
        }

        Debug.Log("3");

        for (int i = 0; i < player.GetInventory().GetInventory().Count; i++)
        {
            Debug.Log("inventory " + i + " = " + player.GetInventory().GetInventory()[i].GetItemName());
        }
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

    // For starting the coroutine
    public void StartEnding(float timer)
    {
        StartCoroutine(EndingSequence(timer));
    }

    // Handles setting the fade and text for the ending
    public IEnumerator EndingSequence(float timer)
    {
        yield return new WaitForSeconds(timer);

        fade.GetComponent<Animator>().SetBool("FadeIn", true);

        yield return new WaitForSeconds(timer);

        text1.GetComponent<Animator>().SetBool("Show", true);

        yield return new WaitForSeconds(timer);

        text2.GetComponent<Animator>().SetBool("Show", true);
    }
}
