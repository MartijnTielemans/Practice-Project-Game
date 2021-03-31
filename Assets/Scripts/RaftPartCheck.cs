using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaftPartCheck : MonoBehaviour
{
    public int raftPartsNeeded;
    public int raftParts;

    public AudioSource correctSound;

    public float endingTimer = 1f;

    private void Update()
    {
        if (raftParts >= raftPartsNeeded)
        {
            Debug.Log("Raft Parts collected");
            GameManager.Instance.StartEnding(endingTimer);
        }
    }

    // If a raft part is placed in the trigger, disable that log's trigger
    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Interactable"))
        {
            GameObject part = col.gameObject;
            int ID = part.GetComponent<RaftPart>().GetID();

            // Raft Parts' IDs are between 200 and 299
            if (ID >= 200 && ID <= 299)
            {
                Debug.Log("Added Raft Part.");
                correctSound.Play();
                raftParts++;

                part.GetComponent<BoxCollider>().enabled = false;
            }
        }
    }
}
