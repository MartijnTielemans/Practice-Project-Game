using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour
{
    List<Card> deckRecipe = new List<Card>();

    public DeckManager deckMan;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Creates a deck with those cards
        if (Input.GetKeyDown(KeyCode.Space))
        {
            // Makes x amount of random cards
            RandomCards(40);

            // Creates and stores a deck in the playerDeck variable
            Deck playerDeck;
            playerDeck = deckMan.CreateDeck("Space Warrior Deck", deckRecipe.ToArray());

            Debug.Log("================== Cards in deck " + playerDeck.GetDeckName() + " " + playerDeck.GetDeck().Count + ": ==================");

            // Displays every card inside the deck
            DebugDeck(playerDeck);

            // Shuffles the deck
            deckMan.ShuffleDeck(0);
            Debug.Log("================== Shuffling the Deck... Card count: " + playerDeck.GetDeck().Count + " ==================");
            DebugDeck(playerDeck);

            // Draws a card
            Card gottenCard = deckMan.Draw(0);
            Debug.Log("================== Drew a card: Name: " + gottenCard.GetName() + " Card Number: " + gottenCard.GetCardSetAndNumber() + "==================");
            Debug.Log("================== Cards left in deck: " + playerDeck.GetDeck().Count + " ================== ");

            // Displays every card in deck again
            DebugDeck(playerDeck);

            // Lays down that same card
            deckMan.Lay(gottenCard, 0);
            Debug.Log("================== Put down that same card ==================");

            // Displays every card in deck once again
            Debug.Log("================== Cards left in deck: " + playerDeck.GetDeck().Count + " ================== ");
            DebugDeck(playerDeck);
        }
    }

    // This displays every card that is currently in the deck
    void DebugDeck(Deck playerDeck)
    {
        foreach (Card c in playerDeck.GetDeck())
        {
            Debug.Log("Card Name: " + c.GetName() + ", Class: " + c.GetClass() + ", Number: " + c.GetCardSetAndNumber());
        }
    }

    void RandomCards(int deckSize)
    {
        // Makes the cards and adds those to a 'Deck Recipe'
        if (deckSize >= 40 && deckSize <= 60)
        {
            for (int i = 0; i < deckSize; i++)
            {
                // This is to generate a funny ol' random name for each card
                string randomName = "";
                char randomChar;

                for (int j = 0; j < Random.Range(3, 10); j++)
                {
                    randomChar = (char)Random.Range('a', 'z');
                    randomName = (randomName + randomChar);
                }

                // Store the card class enum
                Card.CardClasses cardClass = Card.CardClasses.Warrior;

                // Get a random class to put on the card
                switch (Random.Range(0, 3))
                {
                    case 0:
                        cardClass = Card.CardClasses.Warrior;
                        break;

                    case 1:
                        cardClass = Card.CardClasses.Mage;
                        break;

                    case 2:
                        cardClass = Card.CardClasses.Animal;
                        break;

                    default:
                        break;
                }

                // Create the card with the name, class and set number
                Card card = new Card(randomName, cardClass, "ETCS", (i + 1));

                // Then add it to the list of cards to add to the deck
                deckRecipe.Add(card);
            }
        }
        else
        {
            Debug.Log("Deck must be between 40 and 60 cards!!");
        }
    }
}
