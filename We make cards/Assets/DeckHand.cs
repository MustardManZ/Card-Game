using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHand : MonoBehaviour
{
    public Sprite[] screwYou;
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

        //draw 7
        for (int i = 0; i < 7; i++)
        {
            hand.Add(Instantiate(card, transform.position, transform.rotation));

            if (deck[i] == "Person")
            {
                hand[i].GetComponent<CardScript>().newCard(screwYou[8], "Person", 2, 2, 2, 1, 4, 1, 0, false, false, false);
            }
            else if (deck[i] == "Knife Guy") {
                hand[i].GetComponent<CardScript>().newCard(screwYou[4], "Knife Guy", 3, 2, 3, 3, 4, 1, 0, false, false, false);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
