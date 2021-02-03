using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TestCreateItem();
    }

    public void TestCreateItem()
    {
        Item key = new Item("Gold Key", 10);

        Debug.Log("Item: " + key.GetItemName() + ", Weight: " + key.GetWeightValue());
    }
}
