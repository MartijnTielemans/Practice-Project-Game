using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    List<Deck> decks = new List<Deck>();

    // Draws the top card
    public Card Draw(int player)
    {
        return decks[player].Draw();
    }

    // Puts a card back to the top of the deck
    public void Lay(Card card, int player)
    {
        decks[player].Lay(card);
    }

    // Randomize the deck's contents
    public void ShuffleDeck(int player)
    {
        decks[player].Shuffle();
    }

    // Shuffle every players' decks
    public void ShuffleAll()
    {
        for (int i = 0; i < decks.Count; i++)
        {
            decks[i].Shuffle();
        }
    }

    // Creates a new deck from a card list
    public Deck CreateDeck(string name, Card[] cardList)
    {
        Deck createdDeck = new Deck(name, cardList);
        decks.Add(createdDeck);
        return createdDeck;
    }
}
