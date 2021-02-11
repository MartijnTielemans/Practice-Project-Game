using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    InventoryScript inventory;

    [SerializeField]
    TextMeshProUGUI weightText;

    [SerializeField]
    int initialMaxWeight = 120;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new InventoryScript(initialMaxWeight);
        UpdateWeightText(weightText);
    }

    // Update is called once per frame
    void Update()
    {
        // Shoots a raycast that picks up item when hit
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.5f, transform.forward, out hit, 2))
            {
                IInteractable i = hit.collider.gameObject.GetComponent<IInteractable>();
                if (i != null)
                {
                    i.Action(this);
                }
            }
        }

        // Drop the item in the selected slot
        if (Input.GetButtonDown("Drop"))
        {
            Debug.Log("Dropped Item");
            DropItem(GameManager.Instance.selectedSlotID);
        }

        // For switching selected inventory slots
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.selectedSlotID = 0;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.selectedSlotID = 1;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.selectedSlotID = 2;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.selectedSlotID = 3;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameManager.Instance.selectedSlotID = 4;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameManager.Instance.selectedSlotID = 5;
            GameManager.Instance.CheckSlotId();
        }
    }

    public void DropItem(int id)
    {
        Item i = inventory.GetItemFromSlot(id);

        // Search the inventory list for the specific id

        if (i != null)
        {
            if (inventory.RemoveItem(i))
            {
                UpdateWeightText(weightText);
                GameManager.Instance.DropItem(i.GetItemID(), transform.position + transform.forward * 2);
            }
        }
        else
        {
            Debug.LogError("Could not the item at: " + id);
        }
    }

    public bool AddItem (Item item)
    {
        bool success = false;

        if (inventory.AddItem(item))
        {
            UpdateWeightText(weightText);
            success = true;
        }

        return success;
    }

    public InventoryScript GetInventory()
    {
        return inventory;
    }

    public void UpdateWeightText(TextMeshProUGUI text)
    {
        text.text = "" + inventory.GetCurrentWeight() + " / " + inventory.GetMaxWeight();
    }
}
