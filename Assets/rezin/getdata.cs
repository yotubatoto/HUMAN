using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getdata : MonoBehaviour
{
    public GameObject date;

    private Component obj_comp;
    private Vector3 display_pos;

	// Use this for initialization
	void Start ()
    {

        display_pos = new Vector3(0.0f, 0.0f, 0.0f);


    }
	
	// Update is called once per frame
	void Update ()
    {
        display_pos = date.GetComponent<Player_Collision>().hit_coordinate;
        bool display_flag = date.GetComponent<Player_Collision>().touch_flag;

        this.GetComponent<Text>().text =  " Vector" + display_pos;
    }
}
