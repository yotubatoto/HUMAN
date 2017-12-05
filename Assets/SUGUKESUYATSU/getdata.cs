using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getdata : MonoBehaviour
{
    public GameObject date;
    public GameObject date_2;

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
        bool display_flag_2 = date_2.GetComponent<Manager>().hit_flower;

        this.GetComponent<Text>().text = "Tohuchflag:" + display_flag + " Vector" + display_pos + "hit_flower:" + display_flag_2;
    }
}
