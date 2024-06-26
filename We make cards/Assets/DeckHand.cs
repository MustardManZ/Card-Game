using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeckHand : MonoBehaviour
{
    //please don't fool around thanks :D
    public bool select = false;
    public int cardPos;
    public int cardSpeed;
    public int cardCost;
    public GameObject selectedCard;

    public int circles = 1;
    public int turn = 1;
    public bool cardPlayed = false;

    public Sprite[] sprites;
    public GameObject card;
    public List<string> deck = new List<string>();
    public List<GameObject> hand = new List<GameObject>();
    public List<string> graveyard = new List<string>();

    public void endTurn()
    {
        turn++;
        circles = turn;
        draw(1);
        if (!cardPlayed)
        {
            draw(1);
        }
        cardPlayed = false;
        GameObject[] cards = GameObject.FindGameObjectsWithTag("CardScript");
        for (int i = 0; i < cards.Length; i++)
        {
            cards[i].GetComponent<CardScript>().tilesMoved = 0;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        //build deck
        for (int i = 0; i < 13; i++)
        {
            deck.Add("Person");
        }

        for (int i = 0; i < 14; i++)
        {
            deck.Add("Knife Guy");
        }
        for (int i = 0; i < 13; i++)
        {
            deck.Add("Almost Invisible Person");
        }

        //shuffle
        for (int i = 0; i < 40; i++)
        {
            string value = deck[i];
            int a = Random.Range(0, 40);
            deck[i] = deck[a];
            deck[a] = value;
        }

        //starting hand
        draw(7);
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            if (i <= 4)
            {
                hand[i].transform.position = new Vector3(1.6f * i - 9, -3.8f, 0);
            }
            else
            {
                hand[i].transform.position = new Vector3(1.6f * (i - 5) - 9, -1.9f, 0);
            }
        }
    }

    [ContextMenu("Draw")]
    public void draw(int amount)
    {
        int currHandLength = hand.Count;
        for (int i = currHandLength; i < currHandLength + amount; i++)
        {
            if (hand.Count != 10)
            {
                hand.Add(Instantiate(card, transform.position, transform.rotation));
                hand[i].name = deck[1];

                //first bool is charge, second bool is stealth, third bool is heroic

                if (deck[1] == "Almost Invisible Person")
                {
                    hand[i].GetComponent<CardScript>().newCard(sprites[1], "hand", "Almost Invisible Person", 1, 3, 2, 2, 4, 1, 0, false, true, false);
                }
                if (deck[1] == "Person")
                {
                    hand[i].GetComponent<CardScript>().newCard(sprites[9], "hand", "Person", 2, 2, 2, 1, 4, 1, 0, false, false, false);
                }
                else if (deck[1] == "Knife Guy")
                {
                    hand[i].GetComponent<CardScript>().newCard(sprites[5], "hand", "Knife Guy", 3, 2, 3, 3, 4, 1, 0, false, false, false);
                }
                deck.RemoveAt(1);
            }
        }
    }
}
