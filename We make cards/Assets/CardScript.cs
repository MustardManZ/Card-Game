using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    Sprite art;
    string nameDisplay;
    string hpDisplay;
    string speedDisplay;
    string dmgDisplay;
    string costDisplay;
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

    void Start()
    {
        transform.Find("Art").GetComponent<SpriteRenderer>().sprite = art;
        transform.Find("Name (TMP)").GetComponent<TextMeshPro>().text = nameDisplay;
        transform.Find("Health (TMP)").GetComponent<TextMeshPro>().text = hpDisplay;
        transform.Find("Speed (TMP)").GetComponent<TextMeshPro>().text = speedDisplay;
        transform.Find("Attack (TMP)").GetComponent<TextMeshPro>().text = dmgDisplay;
        transform.Find("Cost (TMP)").GetComponent<TextMeshPro>().text = costDisplay;
    }

    void Update()
    {
        hpDisplay = hp.ToString();
        speedDisplay = speed.ToString();
        dmgDisplay = dmg.ToString();
        costDisplay = cost.ToString();
    }

    public void newCard(Sprite cardArt, string cardName, int cardHp, int cardSpeed, int cardDmg, int cardCost, int cardLimit, int cardRange, int cardArmor, bool cardCharge, bool cardStealth, bool cardHeroic)
    {
        art = cardArt;
        name = cardName;
        nameDisplay = name;
        hp = cardHp;
        speed = cardSpeed;
        dmg = cardDmg;
        cost = cardCost;
        limit = cardLimit;
    }
}
