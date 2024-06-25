using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class CardScript : MonoBehaviour
{
    SpriteRenderer art;
    TextMeshPro nameDisplay;
    TextMeshPro hpDisplay;
    TextMeshPro speedDisplay;
    TextMeshPro dmgDisplay;
    TextMeshPro costDisplay;
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

    private void Start()
    {
        art = transform.Find("Art").GetComponent<SpriteRenderer>();
        nameDisplay = transform.Find("Name (TMP)").GetComponent<TextMeshPro>();
        hpDisplay = transform.Find("Health (TMP)").GetComponent<TextMeshPro>();
        speedDisplay = transform.Find("Speed (TMP)").GetComponent<TextMeshPro>();
        dmgDisplay = transform.Find("Attack (TMP)").GetComponent<TextMeshPro>();
        costDisplay = transform.Find("Cost (TMP)").GetComponent<TextMeshPro>();
    }

    private void Update()
    {
        hpDisplay.text = hp.ToString();
        speedDisplay.text = speed.ToString();
        dmgDisplay.text = dmg.ToString();
        costDisplay.text = cost.ToString();
    }

    public CardScript(Sprite cardArt, string cardName, int cardHp, int cardSpeed, int cardDmg, int cardCost, int cardLimit, int cardRange, int cardArmor, bool cardCharge, bool cardStealth, bool cardHeroic)
    {
        art.sprite = cardArt;
        name = cardName;
        nameDisplay.text = name;
        hp = cardHp;
        speed = cardSpeed;
        dmg = cardDmg;
        cost = cardCost;
        limit = cardLimit;
    }

    
}
