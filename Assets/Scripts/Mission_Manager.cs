﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mission_Manager : MonoBehaviour {
    public GameObject Playerobj;
    public int mission_state = 0;
    public bool clear_flag = false;
    private int clear_state = 0;
    public Text clear_text;
    private float clear_time = 0.0f;
    public Image fade;
    enum MISSION_STATE
    {
        STAGE_1_1 = 0,
        STAGE_1_2,
        STAGE_1_3
    };
	public GameObject clear_pop;
	public List<string> mission_text = new List<string> ();
	MainCameraScr mainSource;
	bool[] once_flag = new bool[3];
	int clear_number = 0;
	float stage_select_count = 0.0f;
	// Use this for initialization
	void Start () 
    {
		mainSource = Camera.main.gameObject.GetComponent<MainCameraScr> ();
		for(int i=0;i<3;i++)
		{
			once_flag [i] = false;
		}
	}

	
	// Update is called once per frame
	void Update () 
    {
        //if (mission_state == (int)MISSION_STATE.STAGE_1_1)
        //{
        //    clear_flag = Resin_GetNumber(4);
        //}
//		clear_flag = true;
        //クリア条件を満たしたらカラーをいじっている
        if(clear_flag)
        {
			if (clear_state == 0) {
				clear_text.enabled = true;
				Color c = clear_text.GetComponent<Text> ().color;
				c.a += 0.05f;
				if (c.a >= 1.0f) {
					c.a = 1.0f;
					clear_state = 1;
				}
				clear_text.GetComponent<Text> ().color = c;
			} else if (clear_state == 1) {
				clear_text.enabled = false;
				clear_pop.SetActive (true);
				GameObject.Find ("Mission_1/Context").gameObject.GetComponent<Text> ().text
				= mission_text [0];
				GameObject.Find ("Mission_2/Context").gameObject.GetComponent<Text> ().text
				= mission_text [1];
				GameObject.Find ("Mission_3/Context").gameObject.GetComponent<Text> ().text
				= mission_text [2];
				GameObject.Find ("Score_Number").gameObject.GetComponent<Text> ().text = 
					(Camera.main.GetComponent<Manager> ().shot_state - 1).ToString ();
				if (Mission_1 (2)) {
					GameObject.Find ("Mission_1/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 1);
					if (once_flag [0] == false) {
						clear_number += 1;
					}
				} else {
					GameObject.Find ("Mission_1/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 0.3f);
				}
				if (Mission_2 (10)) {
					GameObject.Find ("Mission_2/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 1);
					if (once_flag [1] == false) {
						clear_number += 1;
					}
				} else {
					GameObject.Find ("Mission_2/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 0.3f);
				}
				if (Mission_3 ()) {
					GameObject.Find ("Mission_3/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 1);
					if (once_flag [2] == false) {
						clear_number += 1;
					}
				} else {
					GameObject.Find ("Mission_3/Context").gameObject.GetComponent<Text> ().color
					= new Color (0, 0, 0, 0.3f);
				}
				PlayerPrefs.SetInt (StageSelectManager.ST_OWNER_NUMBER + "star", clear_number);
				stage_select_count += Time.deltaTime;
				if (stage_select_count > 5) {
					clear_state = 2;
				}
			} else if (clear_state == 2) 
			{
				GameObject.Find ("Touch").gameObject.GetComponent<Text> ().color = 
					new Color (0, 0, 0, 1);
				TouchInfo info = AppUtil.GetTouch();
				if (info == TouchInfo.Began) {
					clear_state = 3;
				}
			}
            if (clear_state == 3)
            {
                Color c = fade.color;
                c.a += 0.02f;
                if(c.a > 1.0f)
                {
                    c.a = 1.0f;

                    if (PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER) == 0)
                    {
                        PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER, 1);
                    }
                    SceneManager.LoadScene("StageSelect_Scene");
                }
                fade.color = c;
            }
        }
	}

    //ランプの点灯数がマックスになったらステージ遷移
    bool Lamp_Lighting_Number(int max_lighting)
    {
        int light_count = Playerobj.GetComponent<Player_Collision>().item_count;

        if (light_count > max_lighting)
        {
            return true;
        }
        return false;
    }

	bool Mission_1(int clear)
	{
		bool _flag = false;
		for (int i = 0; i < mainSource.right_count; i++)
		{
			if (mainSource.right_obj[i].GetComponent<Wall_Gimic>().clear_count <= clear)
			{
				_flag = true;
			}
		}
		if (_flag == false)
		{
			return true;
		}
		return false;
	}

	bool Mission_2(int n)
	{
		int temp =Camera.main.GetComponent<Manager> ().shot_state -1;
		if(temp <= n)
		{
			return true;
		}
		return false;
	}

	bool Mission_3()
	{
		GameObject[] obj = GameObject.FindGameObjectsWithTag ("Small_Block");
		if (obj.Length == 0) 
		{
			return true;
		}
		return false;
	}
}
