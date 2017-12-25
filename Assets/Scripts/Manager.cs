using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

enum MAIN_STATE
{
    SHOT_0 = 0,
	SHOT_1,
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
    public int shot_state = 0;
    public Vector2 start_pos;
    public bool wave_flag = false;
    int temp_state = 0;
    private float count = 0.0f;
    //ターンとターンの間にオブジェクトを動かす                              
    public bool move_flag = false;
    float a_value = 0.0f;
    private bool al_flag = false;
    public bool hit_flower = false;  //光の種とランタンが当たったを調べる

    //public GameObject turn;
    public float trun_alfa = 0.0f;
    private int trun_state = 0;
    bool once_flag = false;
    private int turn_keep_state = 0;
   

    // Use this for initialization
    void Start()
    {
        start_pos = transform.position;
        startTime = Time.time;
        //journeyLength = Vector2.Distance(transform.position, goal.transform.position);
        itemCount = PlayerPrefs.GetInt("item", 0);
        clearCount = PlayerPrefs.GetInt("clear", 0);
        shot.text = GetComponent<Mission_Manager>().LIMIT_TURN.ToString();
        
    }
    
    // Update is called once per frame
    void Update()
    {

        //Count_Such();
        //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag);
        if(shot_state == (int) MAIN_STATE.SHOT_0)
        {
            if(Camera.main.GetComponent<MainCameraScr>().main_move_state >= 0)
            {
                shot_state = (int)MAIN_STATE.SHOT_1;
                //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "1";
                GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);

                Debug.Log("ddd");
            }
        }
        // Wave1
        if (shot_state ==(int) MAIN_STATE.SHOT_1)
        {
            move_flag = false;
            GameObject.Find("turn_flame").GetComponent<Image>().enabled = true;
            GameObject.Find("Turn_Number").GetComponent<Text>().enabled = true;
            //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
            Color c =  wave.color;
            Color trun_color = GameObject.Find("turn_flame").GetComponent<Image>().color;
            //ターンは画像なのでターン開始時アルファをいじる

            //　
            if (turn_keep_state == 0)
            {
                
               //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }
              
           
            }

           wave.color = c;
            if(c.a <= 0.0f && trun_alfa <= 0.0f)
            {
                //Debug.Log(hit_flower);
                //shot_state = (int)MAIN_STATE.SHOT_2;
                move_flag = true;
                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 1)
                {
                    shot_state = (int)MAIN_STATE.SHOT_2;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "2";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                }
            }

           
        }
        // Wave2
        else if (shot_state == (int)MAIN_STATE.SHOT_2)
        {
           
            if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            {
                al_flag = true;
                //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
            }
            if (al_flag)
            {
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 2";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 1;
                    shot.text = temp.ToString();
                    score.text = " 140";
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    turn_keep_state = 0;
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                  
                }
                Color c = wave.color;
                
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                ////trun_alfa -= 0.05f;

                //c.a -= a_value;
                //wave.color = c;

                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //c.a = trun_alfa;
                    //wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }

                if (trun_alfa <= 0.0f)
                {
                    move_flag = true;

                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 2 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        

                        //Debug.Log("aaa" + hit_flower);
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_3;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "3";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);
                    }
                }
            }
           
        }
        // Wave3
        else if (shot_state == (int)MAIN_STATE.SHOT_3)
        {

            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 3";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 2;
                    shot.text = temp.ToString();
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 130";
                    turn_keep_state = 0;

                   
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;

                //c.a -= a_value;
                wave.color = c;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                if (trun_alfa <= 0.0f)
                {
                    move_flag = true;

                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 3 && 
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_4;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "4";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    Debug.Log(hit_flower);
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                //}
            }
           
        }
        // Wave4
        else if (shot_state == (int)MAIN_STATE.SHOT_4)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
              
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 4";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 3;
                    shot.text = temp.ToString();
                    score.text = " 120";
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;
              
                  

                c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                //ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                //wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                    move_flag = true;
                    
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 4 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_5;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "5";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

        }
        // Wave5
        else if (shot_state == (int)MAIN_STATE.SHOT_5)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 5";
                   int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 4;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 110";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                    
                }
                Color c = wave.color;

                c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                //wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                  
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 5 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                       
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_6;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "6";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

           
        }
        // Wave6
        else if (shot_state == (int)MAIN_STATE.SHOT_6)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 6";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 5;
                    shot.text = temp.ToString();

                    turn_keep_state = 0;

                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 100";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                    
                }
                Color c = wave.color;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;

                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    Debug.Log("ijij");


                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(0.0f, 0.0f, 0.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;

                //c.a -= a_value;
                wave.color = c;
                if (c.a <= 0.0f)
                {
                    move_flag = true;

                    
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 6 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_7;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "7";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

           
        }
        // Wave7
        else if (shot_state == (int)MAIN_STATE.SHOT_7)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 7";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 6;
                    shot.text = temp.ToString();

                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 90";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                    
                }
                Color c = wave.color;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;

                //c.a -= a_value;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                   
                    move_flag = true;
                    
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 7 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                       
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_8;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "8";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

          
        }
        // Wave8
        else if (shot_state == (int)MAIN_STATE.SHOT_8)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 8";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 7;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 80";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }


                c.a -= a_value;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                   
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 8 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_9;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "9";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

           
        }
        // Wave9
        else if (shot_state == (int)MAIN_STATE.SHOT_9)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = " 9";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 8;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 70";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                    
                }
                Color c = wave.color;

                //c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                    
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 9 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                       
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_10;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").gameObject.GetComponent<Text>().text = "10";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

            
        }
        // Wave10
        else if (shot_state == (int)MAIN_STATE.SHOT_10)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "10";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 9;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 60";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

                   
                }
                Color c = wave.color;
                
                //c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                //ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                   
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 10 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_11;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "11";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}
          

        }
        // Wave11
        else if (shot_state == (int)MAIN_STATE.SHOT_11)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "11";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 10;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 50";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;
               
                c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                    
                    move_flag = true;
                  
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 11 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_12;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "12";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

            
        }
        // Wave12
        else if (shot_state == (int)MAIN_STATE.SHOT_12)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "12";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 11;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 40";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                    
                }
                Color c = wave.color;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;

                c.a -= a_value;
                wave.color = c;
                if (c.a <= 0.0f)
                {
                   
                    move_flag = true;
                    
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 12 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_13;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "13";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);

                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}

            
        }
        // Wave13
        else if (shot_state == (int)MAIN_STATE.SHOT_13)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "13";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 12;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 30";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                  
                }
                Color c = wave.color;


                //c.a -= a_value;
                //ターンアルファへらす
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                   
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 13 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                       
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_14;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "14";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);

                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}
           

        }
        // Wave14
        else if (shot_state == (int)MAIN_STATE.SHOT_14)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "14";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 13;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                   
                    score.text = " 20";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;

                //c.a -= a_value;
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                ////ターンアルファへらす
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                    
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 14 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        //Debug.Log(hit_flower);
                        al_flag = false;
                        once_flag = false;
                        shot_state = (int)MAIN_STATE.SHOT_15;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "15";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);

                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                    }
                }
            //}
            

        }
        // Wave15
        else if (shot_state == (int)MAIN_STATE.SHOT_15)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
                move_flag = false;
                if (once_flag == false)
                {
                    once_flag = true;
                    wave.text = "15";
                    int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 14;
                    shot.text = temp.ToString();
                    turn_keep_state = 0;
                    ////ターンのアルファ初期化
                    //GameObject.Find("turn_flame").GetComponent<Image>().color =
                    //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    //trun_alfa = 1.0f;
                    score.text = " 10";
                    Color cc = wave.color;
                    cc.a = 1;
                    wave.color = cc;
                    Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                    Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                    //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                    //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);
                   
                }
                Color c = wave.color;

                //c.a -= a_value;
                //ターンアルファへらす
                if (turn_keep_state == 0)
                {
                    //ターンが現れる時間
                    trun_alfa += 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;
                    wave.color = c;

                    //ターンを表示している時間
                    if (trun_alfa >= 5.0f)
                    {
                        turn_keep_state = 1;
                    }
                }
                else if (turn_keep_state == 1)
                {   //ターンを消す時間
                    trun_alfa -= 5.0f * Time.deltaTime;
                    GameObject.Find("turn_flame").GetComponent<Image>().color =
                                new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                    GameObject.Find("Turn_Number").GetComponent<Text>().color =
                        new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                    c.a = trun_alfa;

                    if (trun_alfa <= 0.0f)
                    {
                        trun_alfa = 0;
                    }

                }
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa -= 0.05f;
                wave.color = c;
                if (trun_alfa <= 0.0f)
                {
                   
                    move_flag = true;
                   
                    if (Camera.main.GetComponent<MainCameraScr>().number_count >= 15 &&
                        Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                    {
                        
                        al_flag = false;
                        once_flag = false;
                        //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                        GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                        shot_state = (int)MAIN_STATE.SHOT_16;

                        GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                        //if (hit_flower == true)
                        //{
                        //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                        //    hit_flower = false;
                        //}
                        //score.text = " 0";

                    }
                }
            //}
            
        }
        // Wave16
        else if (shot_state == (int)MAIN_STATE.SHOT_16)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "16";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 15;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 16 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_17;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }

        //wave17
        else if (shot_state == (int)MAIN_STATE.SHOT_17)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "17";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 16;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 17 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_18;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }

        //wave18
        else if (shot_state == (int)MAIN_STATE.SHOT_18)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "18";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 17;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 18 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_19;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave19
        else if (shot_state == (int)MAIN_STATE.SHOT_19)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "19";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 18;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 19 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_20;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }

        //wave20
        else if (shot_state == (int)MAIN_STATE.SHOT_20)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "20";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 19;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 20 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_21;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }

        //wave21
        else if (shot_state == (int)MAIN_STATE.SHOT_21)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "21";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 20;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 21 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_22;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave22
        else if (shot_state == (int)MAIN_STATE.SHOT_22)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "22";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 21;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 22 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_23;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }

        //wave24
        else if (shot_state == (int)MAIN_STATE.SHOT_24)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "24";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 23;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 24 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_25;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave25
        else if (shot_state == (int)MAIN_STATE.SHOT_25)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "25";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 24;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 25 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_26;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave26
        else if (shot_state == (int)MAIN_STATE.SHOT_26)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "26";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 25;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 26 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_27;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave27
        else if (shot_state == (int)MAIN_STATE.SHOT_27)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "27";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 26;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 27 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_28;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave28
        else if (shot_state == (int)MAIN_STATE.SHOT_28)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "28";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 27;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 28 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_29;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave29
        else if (shot_state == (int)MAIN_STATE.SHOT_29)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "29";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 28;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 29 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_30;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    //score.text = " 0";

                }
            }
            //}

        }
        //wave30
        else if (shot_state == (int)MAIN_STATE.SHOT_30)
        {
            //if (Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
            //{
            //    al_flag = true;
            //    //GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;

            //}
            //if (al_flag)
            //{
            move_flag = false;
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "30";
                int temp = GetComponent<Mission_Manager>().LIMIT_TURN - 29;
                shot.text = temp.ToString();
                turn_keep_state = 0;
                ////ターンのアルファ初期化
                //GameObject.Find("turn_flame").GetComponent<Image>().color =
                //    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                //trun_alfa = 1.0f;
                score.text = " 10";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);

            }
            Color c = wave.color;

            //c.a -= a_value;
            //ターンアルファへらす
            if (turn_keep_state == 0)
            {
                //ターンが現れる時間
                trun_alfa += 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;
                wave.color = c;

                //ターンを表示している時間
                if (trun_alfa >= 5.0f)
                {
                    turn_keep_state = 1;
                }
            }
            else if (turn_keep_state == 1)
            {   //ターンを消す時間
                trun_alfa -= 5.0f * Time.deltaTime;
                GameObject.Find("turn_flame").GetComponent<Image>().color =
                            new Color(1.0f, 1.0f, 1.0f, trun_alfa);

                GameObject.Find("Turn_Number").GetComponent<Text>().color =
                    new Color(1.0f, 1.0f, 1.0f, trun_alfa);
                c.a = trun_alfa;

                if (trun_alfa <= 0.0f)
                {
                    trun_alfa = 0;
                }

            }
            //GameObject.Find("turn_flame").GetComponent<Image>().color =
            //       new Color(1.0f, 1.0f, 1.0f, trun_alfa);
            //trun_alfa -= 0.05f;
            wave.color = c;
            if (trun_alfa <= 0.0f)
            {

                move_flag = true;

                if (Camera.main.GetComponent<MainCameraScr>().number_count >= 30 &&
                    Camera.main.GetComponent<MainCameraScr>().main_move_state == 0)
                {

                    al_flag = false;
                    once_flag = false;
                    //GameObject.Find("FrontLayer/Canvas/Clear/clear_number").GetComponent<Text>().text = "16";
                    GameObject.Find("Main Camera").GetComponent<MainCameraScr>().hold = new Vector2(float.MaxValue, float.MaxValue);


                    shot_state = (int)MAIN_STATE.SHOT_31;

                    GetComponent<Mission_Manager>().gameOver_obj.SetActive(true);

                    //if (hit_flower == true)
                    //{
                    //    GameObject.Find("Player").GetComponent<Player_Collision>().touch_flag = false;
                    //    hit_flower = false;
                    //}
                    score.text = " 0";

                }
            }
            //}

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
        //time_text.text = temp.ToString();
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