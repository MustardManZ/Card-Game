using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    public DeckHand deckHand;
    public bool selected = false;
    public int tilePos;
    Sprite art;
    new string name;
    public int hp;
    public int speed;
    public int dmg;
    public int cost;
    public int limit;
    public int range;
    public int armor;
    public bool stealth;
    public bool charge;
    public bool heroic;
    public string position;
    public GameObject selectborder;


    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    void Update()
    {
        if (deckHand.selectedCard == gameObject)
        {
            selected = true;
        }
        else 
        {
            selected = false;
        }
        transform.GetComponent<SpriteRenderer>().sprite = art;
        transform.Find("Name (TMP)").GetComponent<TextMeshPro>().text = name;
        transform.Find("Health (TMP)").GetComponent<TextMeshPro>().text = hp.ToString();
        transform.Find("Speed (TMP)").GetComponent<TextMeshPro>().text = speed.ToString();
        transform.Find("Attack (TMP)").GetComponent<TextMeshPro>().text = dmg.ToString();
        transform.Find("Cost (TMP)").GetComponent<TextMeshPro>().text = cost.ToString();

        selectborder.SetActive(selected && gameObject == deckHand.selectedCard);
        if (selected && deckHand.tile != null && position == "hand" && (deckHand.circles >= cost) && deckHand.tile.transform.position.y < -3.7)
        {
            deckHand.circles -= deckHand.cardCost;
            deckHand.hand.Remove(gameObject);
            transform.position = deckHand.tile.transform.position;
            deckHand.tile = null;
            deckHand.selectedCard = null;
            selected = false;
        }

        if (tilePos != 0)
        {
            position = "field";
        }
    }

    private void OnMouseDown()
    {
        if (!deckHand.select)
        {
            deckHand.select = true;
            deckHand.cardPos = tilePos;
            deckHand.cardSpeed = speed;
            deckHand.cardCost = cost;
            deckHand.selectedCard = gameObject;
        }
        else if (deckHand.select && deckHand.selectedCard == gameObject)
        {
            deckHand.select = false;
            deckHand.selectedCard = null;
        }
        else if (deckHand.select && deckHand.selectedCard != gameObject)
        {
            deckHand.cardPos = tilePos;
            deckHand.cardSpeed = speed;
            deckHand.cardCost = cost;
            deckHand.selectedCard = gameObject;
        }
    }

    public void newCard(Sprite cardArt, string location, string cardName, int cardHp, int cardSpeed, int cardDmg, int cardCost, int cardLimit, int cardRange, int cardArmor, bool cardCharge, bool cardStealth, bool cardHeroic)
    {
        art = cardArt;
        position = location;
        name = cardName;
        hp = cardHp;
        speed = cardSpeed;
        dmg = cardDmg;
        cost = cardCost;
        limit = cardLimit;
    }

}
