using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck
{
    Stack<Card> DeckList = new Stack<Card>();

    string deckName;

    public Deck(string deckName, Card[] cardList)
    {
        this.deckName = deckName;

        for (int i = 0; i < cardList.Length; i++)
        {
            DeckList.Push(cardList[i]);
        }
    }

    public string GetDeckName()
    {
        return deckName;
    }

    public Stack<Card> GetDeck()
    {
        return DeckList;
    }

    public Card Draw()
    {
        return DeckList.Pop();
    }

    public void Lay(Card card)
    {
        DeckList.Push(card);
    }

    public void Shuffle()
    {
        // Makes the stack into a List, shuffles it, then adds it back to the stack
        List<Card> cardsToShuffle = new List<Card>();

        // While the deckList isn't 0, keep inserting the cards from the DeckList
        while (DeckList.Count > 0)
        {
            cardsToShuffle.Add(DeckList.Pop());
        }

        // Then keep moving the cards from cardsToShuffle to the DeckList stack
        while (cardsToShuffle.Count > 0)
        {
            int randomCard = Random.Range(0, cardsToShuffle.Count - 1);

            DeckList.Push(cardsToShuffle[randomCard]);
            cardsToShuffle.RemoveAt(randomCard);
        }
    }
}
