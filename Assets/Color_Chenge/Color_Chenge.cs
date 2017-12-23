using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Chenge : MonoBehaviour
{
    //public GameObject[] color_chenge_prefab = new GameObject[3];
    //public Sprite[] sprite_color = new Sprite[3];
    public Color[] color = new Color[3]; 
    private bool color_chenge_flag = false;
    public int number = 0;

    // Use this for initialization
    void Start ()
    {
        GetComponent<SpriteRenderer>().color = color[0];
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            number += 1;
            color_chenge_flag = true;

            if (number == 3)
            {
                number = 0;
            }

            GetComponent<SpriteRenderer>().color = color[number];
        }

    }
}
