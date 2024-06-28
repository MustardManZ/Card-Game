using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.VisualScripting;
using TMPro;

public class CircleTexter : MonoBehaviour
{
    public DeckHand deckHand;

    // Start is called before the first frame update
    void Start()
    {
        deckHand = GameObject.FindGameObjectWithTag("DeckHand").GetComponent<DeckHand>();
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.GetComponent<TextMeshPro>().text = deckHand.circles.ToString();
    }
}
