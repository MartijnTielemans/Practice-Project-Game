using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    public InventoryScript inventory;

    string answer;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("============ Testing Item Creation ===============");
        //TestCreateAccessItem();
        //TestCreateBonusItem();


        //Debug.Log("============ Testing Inventory functions ===============");
        //TestInventoryFunction();


        Debug.Log("============ Testing Riddle Puzzle ===============");
        TestRiddlePuzzle();
    }

    public void TestCreateAccessItem()
    {
        // Make an Item, not accessitem, because then is the same type as the rest of the items
        Item key = new AccessItem("Gold Key", 10, 0);
        DebugLogItem(key);
    }

    public void TestCreateBonusItem()
    {
        Item candy = new BonusItem("Chocolate Bar", 2, 250);
        DebugLogItem(candy);
    }

    public void TestInventoryFunction()
    {
        Item key = new AccessItem("Gold Key", 20, 0);
        Item chocolateBar = new BonusItem("Chocolate Bar", 60, 250);
        Item popsicle = new BonusItem("Popsicle", 50, 100);

        if (inventory.AddItem(key))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        if (inventory.AddItem(chocolateBar))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        if (inventory.AddItem(popsicle))
        {
            Debug.Log("Added " + key.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log(" Failed to add " + key.GetItemName() + " to the inventory.");
        }

        inventory.DebugInventory();

        for (int i = 0; i < 2; i++)
        {
            if (inventory.CanOpenDoor(i))
            {
                Debug.Log("opened door with the ID: " + i);
            }
            else
            {
                Debug.Log("Failed to open door with the ID: " + i);
            }
        }
    }

    void TestRiddlePuzzle()
    {
        // Create 2 riddles
        Item knightRiddle = new PuzzleItem("The knight's riddle", 10, "There once was a cow who lived in a barn, How many spots did it have?", "6");
        Item kingRiddle = new PuzzleItem("The king's riddle", 30, "If I had 20 grains of rice, and I ate 4, how many do I have left?", "16");

        // Add the riddles to the inventory
        if (inventory.AddItem(knightRiddle))
        {
            Debug.Log("Added " + knightRiddle.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log("Failed to add " + knightRiddle.GetItemName() + " to the inventory.");
        }

        if (inventory.AddItem(kingRiddle))
        {
            Debug.Log("Added " + kingRiddle.GetItemName() + " to the inventory.");
        }
        else
        {
            Debug.Log("Failed to add " + kingRiddle.GetItemName() + " to the inventory.");
        }

        // Check the inventory
        inventory.DebugInventory();

        // set the answer value
        answer = "6";
        Debug.Log("Your answer is: " + answer);

        // Check if the answer is correct for both riddles
        CheckRiddleAnswer(knightRiddle);

        CheckRiddleAnswer(kingRiddle);
    }

    void CheckRiddleAnswer(Item riddle)
    {
        if (riddle is PuzzleItem)
        {
            PuzzleItem puzzleRiddle = (PuzzleItem)riddle;

            if (puzzleRiddle.RiddleSolved(answer))
            {
                Debug.Log("You solved the " + puzzleRiddle.GetItemName() + "!");
            }
            else
            {
                Debug.Log("You did not solve the " + puzzleRiddle.GetItemName() + "..");
            }

            Debug.Log("The answer was: " + (puzzleRiddle.GetAnswer()));
        }
    }

    void DebugLogItem(Item item)
    {
        string itemInfo = "Item: " + item.GetItemName() + ", weighs: " + item.GetWeightValue();
        string extraInfo = "";

        if (item is AccessItem)
        {
            AccessItem aItem = (AccessItem)item;
            extraInfo = ", weighs: " + aItem.GetWeightValue() + " and opens door: " + aItem.GetDoorID();
        }
        else if (item is BonusItem)
        {
            BonusItem aItem = (BonusItem)item;
            extraInfo = ", weighs: " + aItem.GetWeightValue() + " and counts for: " + aItem.GetPointValue() + " points.";
        }
        
        Debug.Log(itemInfo + extraInfo);
    }
}
