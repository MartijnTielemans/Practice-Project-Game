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

        if (Input.GetButtonDown("Drop"))
        {
            DropItem(10);
        }
    }

    public void DropItem(int id)
    {
        Item i = inventory.GetItemWithID(id);

        if (i != null)
        {
            if (inventory.RemoveItem(i))
            {
                UpdateWeightText(weightText);
            }
            GameManager.Instance.DropItem(id, transform.position + transform.forward * 2);
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
