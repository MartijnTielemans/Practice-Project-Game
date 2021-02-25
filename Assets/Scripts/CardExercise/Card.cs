using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Card
{
    public enum CardClasses
    {
        Warrior,
        Mage,
        Animal,
    }

    CardClasses CardClass;

    string name;

    string setID;
    int cardNumber;

    public Card (string name, CardClasses classes, string setID, int cardNumber)
    {
        this.name = name;
        this.CardClass = classes;
        this.setID = setID;
        this.cardNumber = cardNumber;
    }

    public string GetName()
    {
        return name;
    }

    public CardClasses GetClass()
    {
        return CardClass;
    }

    public string GetCardSetAndNumber()
    {
        return (setID + "-" + cardNumber);
    }
}
