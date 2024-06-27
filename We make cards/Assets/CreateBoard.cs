using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateBoard : MonoBehaviour
{

    public GameObject tile;
    public int width;
    public int height;
    public float spacingX;
    public float spacingY;  

    // Start is called before the first frame update
    void Start()
    {
        float gridY = transform.position.y;

        for (int i = 0; i < width; i++)
        {
            for (int j = 0; j < height; j++)
            {
                GameObject NewClone = Instantiate(tile, new Vector3(transform.position.x, transform.position.y, 0), transform.rotation);
                transform.position += Vector3.down * spacingY;
                NewClone.GetComponent<BoardScript>().position = 5 - j;

            }
            transform.position += Vector3.right * spacingX;
            transform.position = new Vector3(transform.position.x, gridY, 1);

        }
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
