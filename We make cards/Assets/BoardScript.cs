using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public DeckHand deckHand;
    public int position;

    // Start is called before the first frame update
    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        if (deckHand.select && Mathf.Abs(deckHand.cardPos - position) <= deckHand.cardSpeed)
        {
            deckHand.select = false;
            deckHand.tile = gameObject;
            deckHand.selectedCard.GetComponent<CardScript>().tilePos = position;
        }
    }
}