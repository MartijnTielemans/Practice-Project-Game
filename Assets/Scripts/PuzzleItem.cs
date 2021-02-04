using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleItem : Item
{
    string riddle;
    string riddleAnswer;

    bool solved;

    public PuzzleItem (string name, int weightValue, string riddle, string riddleAnswer) : base (name, weightValue)
    {
        this.riddle = riddle;
        this.riddleAnswer = riddleAnswer;
        this.solved = false;
    }

    public bool RiddleSolved (string answer)
    {
        if (solved = (answer == this.riddleAnswer))
        {
            Debug.Log("You solved the " + GetItemName() + "!");
        }
        else
        {
            Debug.Log("You did not solve the " + GetItemName() + "..");
        }

        Debug.Log("The answer was: " + (GetAnswer()));
        return solved;
    }

    public string GetAnswer()
    {
        return riddleAnswer;
    }
}
