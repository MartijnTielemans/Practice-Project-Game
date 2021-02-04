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
        
    }

    public bool AddItem (Item item)
    {
        return (inventory.AddItem(item));
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if (hit.gameObject.CompareTag("Interactable"))
        {
            IInteractable i = hit.gameObject.GetComponent<IInteractable>();
            i.Action(this);
        }
    }
}
