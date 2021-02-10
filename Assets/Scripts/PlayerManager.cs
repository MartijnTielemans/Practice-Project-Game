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
        if (Input.GetButtonDown("Drop"))
        {
            RemoveLastItem();
        }
    }

    public bool AddItem (Item item, GameObject go)
    {
        return (inventory.AddItem(item, go));
    }

    public void RemoveLastItem()
    {
        GameObject go = inventory.DropLastItem();

        // Check if go returns null
        if (go != null)
        {
            // Set the GameObject's position
            go.transform.position = (transform.position + (transform.forward * 2));

            // Set the GameObject to be active again
            go.SetActive(true);
        }
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Interactable"))
        {
            IInteractable i = hit.gameObject.GetComponent<IInteractable>();
            i.Action(this);
        }
    }

    public InventoryScript GetInventory()
    {
        return inventory;
    }
}
