using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public DeckHand deckHand;

    // Start is called before the first frame update
    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (deckHand.select)
        {
            deckHand.select = false;
            deckHand.tile = gameObject;
        }
    }
}
