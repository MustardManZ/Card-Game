using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHand : MonoBehaviour
{
    //please don't fool around thanks :D
    public Sprite[] Sprites;
    public GameObject card;
    public List<string> deck = new List<string>();
    public List<GameObject> hand = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        //build deck
        for (int i = 0; i < 20; i++)
        {
            deck.Add("Person");
        }

        for (int i = 0; i < 20; i++)
        {
            deck.Add("Knife Guy");
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

    }

    [ContextMenu("Draw")]
    public void draw(int amount)
    {
        for (int i = 0; i < amount; i++)
        {
            hand.Add(Instantiate(card, transform.position, transform.rotation));
            if (deck[1] == "Person")
            {
                hand[i].GetComponent<CardScript>().newCard(Sprites[9], "hand", "Person", 2, 2, 2, 1, 4, 1, 0, false, false, false);
            }
            else if (deck[1] == "Knife Guy")
            {
                hand[i].GetComponent<CardScript>().newCard(Sprites[5], "hand", "Knife Guy", 3, 2, 3, 3, 4, 1, 0, false, false, false);
            }
            deck.RemoveAt(1);
        }
    }
}
