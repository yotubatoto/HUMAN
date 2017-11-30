using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Manager : MonoBehaviour
{
    public GameObject player;
    public float rimit_time = 60;
    private int itemCount = 0;
    private int clearCount = 0;
    public Text time_text;
    public Text result_text; 
    public GameObject filterWhite;
    private float al;
    public GameObject goal;
    public Text wave;
    public Text shot;
    public Text score;
    public float speed = 0.01f;
    private float startTime;
    Color color;
    private int camera_state = 0;
    private float journeyLength;
    int shot_state = 1;
    public Vector2 start_pos;
    public bool wave_flag = false;
    int temp_state = 0;
    private float count = 0.0f;
    private float a_value = 0.02f;
    enum MAIN_STATE
    {
        SHOT_1 = 1,
        SHOT_2,
        SHOT_3,
        SHOT_4,
        SHOT_5,
        SHOT_6,
        SHOT_7,
        SHOT_8,
        SHOT_9,
        SHOT_10,
        SHOT_11,
        SHOT_12,
        SHOT_13,
        SHOT_14,
        SHOT_15,
        SHOT_16,
        SHOT_17,
        SHOT_18,
        SHOT_19,
        SHOT_20,
        SHOT_21,
        SHOT_22,
        SHOT_23,
        SHOT_24,
        SHOT_25,
        SHOT_26,
        SHOT_27,
        SHOT_28,
        SHOT_29,
        SHOT_30,
        SHOT_31,
        SHOT_32,
        SHOT_33,
        SHOT_34,
        SHOT_35,
        SHOT_36,
        SHOT_37,
        SHOT_38,
        SHOT_39,
        SHOT_40,
        SHOT_41,
        SHOT_42,
        SHOT_43,
        SHOT_44




    };
    bool once_flag = false;


    // Use this for initialization
    void Start()
    {
        start_pos = transform.position;
        startTime = Time.time;
        journeyLength = Vector2.Distance(transform.position,goal.transform.position);
        itemCount = PlayerPrefs.GetInt("item", 0);
        clearCount = PlayerPrefs.GetInt("clear", 0);
    }
    
    // Update is called once per frame
    void Update()
    {
        Count_Such();

        // Wave1
        if (shot_state ==(int) MAIN_STATE.SHOT_1)
        {
           Color c =  wave.color;
           
          
           c.a -= a_value;
           wave.color = c;
           Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if(c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_2;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_2)
        {
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_3;
            }
        }
        // Wave2
        else if (shot_state == (int)MAIN_STATE.SHOT_3)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 2";
                shot.text = "2/15";
                score.text= " 140";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_4;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_4)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_5;
            }
        }
        // Wave3
        else if (shot_state == (int)MAIN_STATE.SHOT_5)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 3";
                shot.text = "3/15";
                score.text = " 130";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
				Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_6;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_6)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_7;
            }
        }
        // Wave4
        else if (shot_state == (int)MAIN_STATE.SHOT_7)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 4";
                shot.text = "4/15";
                score.text = " 120";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_8;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_8)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_9;
            }
        }
        // Wave5
        else if (shot_state == (int)MAIN_STATE.SHOT_9)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 5";
                shot.text = "5/15";
                score.text = " 110";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_10;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_10)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_11;
            }
        }
        // Wave6
        else if (shot_state == (int)MAIN_STATE.SHOT_11)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 6";
                shot.text = "6/15";
                score.text = " 100";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_12;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_12)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_13;
            }
        }
        // Wave7
        else if (shot_state == (int)MAIN_STATE.SHOT_13)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 7";
                shot.text = "7/15";
                score.text = " 90";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_14;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_14)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_15;
            }
        }
        // Wave8
        else if (shot_state == (int)MAIN_STATE.SHOT_15)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 8";
                shot.text = "8/15";
                score.text = " 80";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_16;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_16)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_17;
            }
        }
        // Wave9
        else if (shot_state == (int)MAIN_STATE.SHOT_17)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 9";
                shot.text = "9/15";
                score.text = " 70";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_18;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_18)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_19;
            }
        }
        // Wave10
        else if (shot_state == (int)MAIN_STATE.SHOT_19)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 10";
                shot.text = "10/15";
                score.text = " 60";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_20;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_20)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_21;
            }
        }
        // Wave11
        else if (shot_state == (int)MAIN_STATE.SHOT_21)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 11";
                shot.text = "11/15";
                score.text = " 50";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_22;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_22)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_23;
            }
        }
        // Wave12
        else if (shot_state == (int)MAIN_STATE.SHOT_23)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 12";
                shot.text = "12/15";
                score.text = " 40";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_24;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_24)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_25;
            }
        }
        // Wave13
        else if (shot_state == (int)MAIN_STATE.SHOT_25)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 13";
                shot.text = "13/15";
                score.text = " 30";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_26;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_26)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_27;
            }
        }
        // Wave14
        else if (shot_state == (int)MAIN_STATE.SHOT_27)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 14";
                shot.text = "14/15";
                score.text = " 20";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_28;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_28)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_29;
            }
        }
        // Wave15
        else if (shot_state == (int)MAIN_STATE.SHOT_29)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 15";
                shot.text = "15/15";
                score.text = " 10";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_30;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }
        }
        else if (shot_state == (int)MAIN_STATE.SHOT_30)
        {
            once_flag = false;
            if (Camera.main.GetComponent<MainCameraScr>().state_move_flag == true)
            {
                shot_state = (int)MAIN_STATE.SHOT_31;
                score.text = " 0";
                 

            }
        }





        


    }

    void Fade()
    {
        filterWhite.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, al += 0.01f);
        if (al >= 1)
        {
            SceneManager.LoadScene("StageSelect_Scene");
        }
    }
    void Count_Such()
    {
        rimit_time -= Time.deltaTime;
        //一時的にテンプ
        int temp = (int)rimit_time;
        time_text.text = temp.ToString();
        if (rimit_time <= 0)
        {
            rimit_time = 0;

            time_text.text = temp.ToString();
            PlayerPrefs.SetInt("item", itemCount + player.GetComponent<Player_Collision>().item_count);
            //PlayerPrefs.SetInt("clear", clearCount+=1);
            //StageSelectManager.ST_CLEAR_FLAG = true;
            //データ名「CLEARSTAGE」に引数の1を代入しなおす
            //SceneManager.LoadScene("StageSelect_Scene");
            result_text.enabled = true;
            GetComponent<MainCameraScr>().touch_freeze_flag = true;
            Fade();
        }
    }
}