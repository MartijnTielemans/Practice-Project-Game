using TMPro;
using UnityEngine;

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
            DropItem(GameManager.Instance.selectedSlotIndex);
        }

        // For switching selected inventory slots
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameManager.Instance.selectedSlotIndex = 0;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            GameManager.Instance.selectedSlotIndex = 1;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            GameManager.Instance.selectedSlotIndex = 2;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            GameManager.Instance.selectedSlotIndex = 3;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            GameManager.Instance.selectedSlotIndex = 4;
            GameManager.Instance.CheckSlotId();
        }

        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            GameManager.Instance.selectedSlotIndex = 5;
            GameManager.Instance.CheckSlotId();
        }
    }

    public void DropItem(int slot)
    {
        Item i = inventory.GetItemFromSlot(slot);

        if (i != null)
        {
            if (inventory.RemoveItem(i))
            {
                UpdateWeightText(weightText);
                GameManager.Instance.DropItem(i.GetItemID(), transform.position + transform.forward * 2);
                Debug.Log("Dropped Item");
            }
        }
        else
        {
            Debug.LogError("Could not the item at: " + slot);
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
