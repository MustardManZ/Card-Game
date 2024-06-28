using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public DeckHand deckHand;
    public int position;
    public CardScript cardScript;

    // Start is called before the first frame update
    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    // Update is called once per frame
    void OnMouseDown()
    {
        cardScript = deckHand.selectedCard.GetComponent<CardScript>();

        if (deckHand.select && Mathf.Abs(deckHand.cardPos - position) <= 1 && cardScript.tilesMoved < cardScript.speed)
        {
            deckHand.tile = gameObject;
            if (cardScript.position != "hand")
            {
                cardScript.tilesMoved++;
            }

            
            if (deckHand.cardPos == 0)
            {
                if (deckHand.circles >= deckHand.cardCost)
                {
                    deckHand.circles -= deckHand.cardCost;
                }
                else
                {
                    return;
                }
            }

            
                deckHand.select = false;
                deckHand.tile = gameObject;
                deckHand.selectedCard.GetComponent<CardScript>().tilePos = position;
            
            
        }
    }
}
