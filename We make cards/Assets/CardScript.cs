using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardScript : MonoBehaviour
{
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

    void Update()
    {
        transform.Find("Art").GetComponent<SpriteRenderer>().sprite = art;
        transform.Find("Name (TMP)").GetComponent<TextMeshPro>().text = name;
        transform.Find("Health (TMP)").GetComponent<TextMeshPro>().text = hp.ToString();
        transform.Find("Speed (TMP)").GetComponent<TextMeshPro>().text = speed.ToString();
        transform.Find("Attack (TMP)").GetComponent<TextMeshPro>().text = dmg.ToString();
        transform.Find("Cost (TMP)").GetComponent<TextMeshPro>().text = cost.ToString();
        if (position == "hand")
        {
            
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
