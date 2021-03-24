using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public GameObject player;

    // Update is called once per frame
    void Update()
    {
        Vector3 lookAtPos = player.transform.position;
        lookAtPos.y = transform.position.y;

        // Has the object constantly look at the player's camera
        transform.LookAt(lookAtPos, Vector3.up);
    }
}
