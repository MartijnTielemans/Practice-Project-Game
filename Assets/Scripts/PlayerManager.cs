using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    InventoryScript inventory;

    [SerializeField]
    int initialMaxWeight = 120;

    // Start is called before the first frame update
    void Start()
    {
        inventory = new InventoryScript(initialMaxWeight);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Interact"))
        {
            RaycastHit hit;

            if (Physics.SphereCast(transform.position, 0.2f, transform.forward, out hit))
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
            DropItem(10, transform.forward * 2);
        }
    }

    public void DropItem(int id, Vector3 position)
    {
        Item i = inventory.GetItemWithID(id);

        if (i != null)
        {
            inventory.RemoveItem(i);
            GameManager.Instance.DropItem(id, position);
        }
    }

    public bool AddItem (Item item)
    {
        return (inventory.AddItem(item));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        
    }

    public InventoryScript GetInventory()
    {
        return inventory;
    }
}
