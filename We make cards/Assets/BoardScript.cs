using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

public class BoardScript : MonoBehaviour
{
    public DeckHand deckHand;
    public int position;
    public CardScript cardScript;
    public GameObject target = null;

    // Start is called before the first frame update
    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    async void OnMouseDown()
    {
        cardScript = deckHand.selectedCard.GetComponent<CardScript>();

        if (deckHand.select && Mathf.Abs(deckHand.cardPos - position) <= 1 && cardScript.tilesMoved < cardScript.speed)
        {
            if (cardScript.position == "hand")
            {
                if (deckHand.circles >= deckHand.cardCost)
                {
                    deckHand.circles -= deckHand.cardCost;
                }
                else
                {
                    return;
                }

                //on cast non target effects can go here

                if (deckHand.cardName == "Cloud")
                {
                    deckHand.draw(1);
                }

                deckHand.cardPlayed = true;
                cardScript.position = "field";
            }
            else
            {
                cardScript.tilesMoved++;
            }

            if (deckHand.selectedCard.GetComponent<CardScript>().hp <= 0 && cardScript.position == "field")
            {
                deckHand.selectedCard.SetActive(false);
            }

            deckHand.hand.Remove(cardScript.gameObject);
            deckHand.selectedCard.transform.position = gameObject.transform.position;
            deckHand.selectedCard.GetComponent<CardScript>().tilePos = position;

            //target oncasts
            if (deckHand.cardName == "Stab")
            {
                Debug.Log("Procced");
                target = null;
                while (!target)
                {
                    if (Input.GetMouseButtonDown(0) && deckHand.select && deckHand.cardHealth != 0)
                    {
                        target = deckHand.selectedCard;
                    }
                    await Task.Delay(1);
                    Debug.Log(target);

                }
                target.GetComponent<CardScript>().hp = target.GetComponent<CardScript>().hp - 1;
                if (target.GetComponent<CardScript>().hp <= 0)
                {
                    deckHand.selectedCard.SetActive(false);
                }
                target = null;
                Debug.Log("Stabbed");
            }
        }

        cardScript.selected = false;
        deckHand.select = false;
        deckHand.selectedCard = null;
    }

}
