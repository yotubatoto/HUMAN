using System.Collections;
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


	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (mission_state == (int)MISSION_STATE.STAGE_1_1)
        //{
        //    clear_flag = Resin_GetNumber(4);
        //}

        //クリア条件を満たしたらカラーをいじっている
        if(clear_flag)
        {
            if (clear_state == 0)
            {
                clear_text.enabled = true;
                clear_time += Time.deltaTime;
                if (clear_time > 2)
                {
                    clear_state = 1;
                }
            }
            if (clear_state == 1)
            {
                Color c = fade.color;
                c.a += 0.02f;
                if(c.a > 1.0f)
                {
                    c.a = 1.0f;
                    SceneManager.LoadScene("StageSelect_Scene");
                }
                fade.color = c;
            }
        }
	}
    //bool Resin_GetNumber(int max_resin)
    //{
    //    int resin_count = Playerobj.GetComponent<Player_Collision>().item_count;

    //    if (resin_count > max_resin)
    //    {
    //        return true;
    //    }
    //    return false;
    //}
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





}
