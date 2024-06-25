using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckHand : MonoBehaviour
{
    public GameObject card;
    public List<object> deck = new List<object>();
    public List<object> hand = new List<object>();

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            deck[i] = card;
        }

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
