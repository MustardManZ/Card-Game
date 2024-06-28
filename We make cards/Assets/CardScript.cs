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
    public int tilesMoved = 0;

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
        transform.GetComponent<SpriteRenderer>().sprite = art;
        transform.Find("Name (TMP)").GetComponent<TextMeshPro>().text = name;
        transform.Find("Health (TMP)").GetComponent<TextMeshPro>().text = hp.ToString();
        transform.Find("Speed (TMP)").GetComponent<TextMeshPro>().text = speed.ToString();
        transform.Find("Attack (TMP)").GetComponent<TextMeshPro>().text = dmg.ToString();
        transform.Find("Cost (TMP)").GetComponent<TextMeshPro>().text = cost.ToString();

        selectborder.SetActive(selected);
        if (selected && !deckHand.select)
        {
            selected = false;
        }
    }

    private void OnMouseDown()
    {
        if (!deckHand.select)
        {
            deckHand.select = true;
            selected = true;
            deckHand.cardPos = tilePos;
            deckHand.cardSpeed = speed;
            deckHand.cardCost = cost;
            deckHand.selectedCard = gameObject;
        }
        else if (deckHand.select)
        {
            selected = false;
            deckHand.select = false;
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
