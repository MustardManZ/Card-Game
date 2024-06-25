using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHand : MonoBehaviour
{
    public Sprite[] screwYou;
    public GameObject card;
    public List<GameObject> deck = new List<GameObject>();
    public List<GameObject> hand = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            deck.Add(Instantiate(card, transform.position, transform.rotation));
            deck[i].GetComponent<CardScript>().newCard(screwYou[8], "Person", 2, 2, 2, 1, 4, 1, 0, false, false, false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
