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
    }

    public bool RiddleSolved (string answer)
    {
        return (answer == this.riddleAnswer);
    }

    public string GetAnswer()
    {
        return riddleAnswer;
    }
}
