using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    Dictionary<int, Pickup> worldItems = new Dictionary<int, Pickup>();

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

    public void DropItem(int id, Vector3 position)
    {
        worldItems[id].Respawn(position);
    }
}
