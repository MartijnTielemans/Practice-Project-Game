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
    int maximumSlots = 6;

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

    public bool AddToSlot(Sprite image, string name)
    {
        for (int i = 0; i < maximumSlots; i++)
        {
            if (!inventorySlots[i].filled)
            {
                inventorySlots[i].AddToSlot(image, name);
                return true;
            }
        }

        return false;
    }

    public void ClearSlots()
    {
        for (int i = 0; i < maximumSlots; i++)
        {
            if (inventorySlots[i].filled)
            {
                inventorySlots[i].RemoveFromSlot();
            }
        }
    }

    public void UpdateSlots()
    {
        ClearSlots();

        for (int i = 0; i < player.GetInventory().GetInventory().Count; i++)
        {
            int itemId = player.GetInventory().GetInventory()[i].GetItemID();
            Pickup item = worldItems[itemId];

            inventorySlots[i].AddToSlot(GetItemSprite(item.id), item.itemName);
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
