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
    //ターンとターンの間にオブジェクトを動かす                              
    public bool move_flag = false;
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
        SHOT_30



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
            move_flag = false;
            Color c =  wave.color;
           
          
           c.a -= a_value;
           wave.color = c;
           Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if(c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_2;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 2";
                shot.text = "2/10";
                score.text= " 90";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_4;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 3";
                shot.text = "3/10";
                score.text = " 80";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
				Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_6;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 4";
                shot.text = "4/10";
                score.text = " 70";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_8;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 5";
                shot.text = "5/10";
                score.text = " 60";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_10;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;

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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 6";
                shot.text = "6/10";
                score.text = " 50";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_12;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 7";
                shot.text = "7/10";
                score.text = " 40";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_14;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 8";
                shot.text = "8/10";
                score.text = " 30";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_16;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 9";
                shot.text = "9/10";
                score.text = " 20";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;

            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_18;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 10";
                shot.text = "10/10";
                score.text = " 10";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;

            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_20;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                //wave.text = "WAVE 11";
                shot.text = "10/10";
                score.text = " 0";

                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;

            }
            Color c = wave.color;
            c.a -= a_value;
            wave.color = c;
            Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
            if (c.a <= 0.0f)
            {
                shot_state = (int)MAIN_STATE.SHOT_22;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;
                move_flag = true;
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

        //GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text =
        //    GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString();




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