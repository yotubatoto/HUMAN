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
    public float speed = 0.01F;
    private float startTime;
    Color color;
    private int camera_state = 0;
    private float journeyLength;
    int shot_state = 1;
    private Vector2 start_pos;
    public bool wave_flag = false;
    int temp_state = 0;
    private float count = 0.0f;
    enum MAIN_STATE
    {
        SHOT_1 = 1,
        SHOT_2,
        SHOT_3,
        SHOT_4,
        SHOT_5,
        SHOT_6
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

        if (GetComponent<Mission_Manager>().clear_flag == true)
        {
            //Time.timeScale = 0.0f;
            if (camera_state == 0)
            {
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = true;
                wave_flag = true;
                Pauser.Pause();
                float distCovered = (Time.time - startTime) * speed;
                float fracJourney = distCovered / journeyLength;

                Camera.main.orthographicSize -= 0.3f;
                if (Camera.main.orthographicSize <= 5.0f)
                {
                    Camera.main.orthographicSize = 5.0f;
                    camera_state = 1;
                }

                transform.position = Vector2.Lerp(transform.position, goal.transform.position, fracJourney);
                transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
            }
            else if(camera_state == 1)
            {
                if(temp_state == 0)
                {
                    Camera.main.orthographicSize += 0.4f;
                    if (Camera.main.orthographicSize >= 25.0f)
                    {
                        Camera.main.orthographicSize = 25.0f;
                        //camera_state = 2;
                        temp_state = 1;
                    }
                }
                else if(temp_state == 1)
                {
                    count += 0.02f;
                    //float distCovered = (Time.time - startTime) * (speed);
                    //float fracJourney = distCovered / journeyLength;
                    //float time = Time.deltaTime;
                    transform.position = Vector3.Lerp(transform.position, start_pos, count);
                    transform.position = new Vector3(transform.position.x, transform.position.y, -10.0f);
                    //Debug.Log(fracJourney);
                    if (count >= 1.0f)
                    {
                        count = 0.0f;
                        Debug.Log("元気");
                        camera_state = 2;
                    }
                }
            }
            else if (camera_state == 2)
            {
                Pauser.Resume();
                camera_state = -1;
                wave_flag = false;
                Camera.main.GetComponent<MainCameraScr>().touch_freeze_flag = false;

            }


            
            //扉を不透明にする。
            color = goal.GetComponent<SpriteRenderer>().color;
            color.a += 0.05f;
            goal.GetComponent<SpriteRenderer>().color = color;

        }
        Count_Such();

        if (shot_state ==(int) MAIN_STATE.SHOT_1)
        {
           Color c =  wave.color;
           c.a -= 0.02f;
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
        else if (shot_state == (int)MAIN_STATE.SHOT_3)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 2";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
                Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= 0.02f;
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
        else if (shot_state == (int)MAIN_STATE.SHOT_5)
        {
            if (once_flag == false)
            {
                once_flag = true;
                wave.text = "WAVE 3";
                Color cc = wave.color;
                cc.a = 1;
                wave.color = cc;
				Camera.main.GetComponent<MainCameraScr>().end_flag = false;
                Camera.main.GetComponent<MainCameraScr>().state_move_flag = false;
            }
            Color c = wave.color;
            c.a -= 0.02f;
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