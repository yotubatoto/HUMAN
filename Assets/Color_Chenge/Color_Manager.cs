using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Color_Manager : MonoBehaviour
{
    public GameObject[] color_chenge_prefab = new GameObject[3];
    public Sprite[] sprite_color = new Sprite[3];

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        color_chenge_prefab[0].GetComponent<SpriteRenderer>().sprite = sprite_color[1];
	}
}
