using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class Mission_Manager : MonoBehaviour
{
    public GameObject Playerobj;
    public int mission_state = 0;
    public bool clear_flag = false;
    private int clear_state = 0;
    public Image clear_text;
    private float clear_time = 0.0f;
    bool bgm_clear_flag = false;
    //ステージクリアしたら（ステージクリアのテキストが表示される時間）
    private float clear_count = 0.0f;
    //private GameObject[] small;
    private GameObject[] gimic;
    private GameObject[] gimic_object;
    private int gimic_number = 0;
    private int block_number = 0;
    //連打防止
    private bool clear_barrage_flag = false;
    private bool game_over_barrage_flag = false;
    public Image fade;
    enum MISSION_STATE
    {
        STAGE_1_1 = 0,
        STAGE_1_2,
        STAGE_1_3
    };
    public GameObject clear_pop;
    public List<string> mission_text = new List<string>();
    MainCameraScr mainSource;
    bool[] once_flag = new bool[3];
    int clear_number = 0;
    float stage_select_count = 0.0f;
    //    public int MAX_SHOT = 1;
    public GameObject gameOver_obj;
    private float delay_time = 0.0f;
    private bool clear_once_flag = false;
    public GameObject[] star_obj = new GameObject[3];
    private int MAX_TURN = 15;
    public int LIMIT_TURN = 10;
    public GameObject turn_limit;
    public int CLEAR_LAMP_LEVEL = 1;
    public GameObject Result_obj;
    public GameObject goal_trun;
    public GameObject clear_goal_turn;
    public string[] GOAL_TURN = new string[40];
    public string[] LIMITE = new string[50];
    public AudioClip gameover_bgm;
    public AudioClip game_clear_bgm;
    private int game_clear_bgm_state = 0;
    private bool ending_flag = false;
    private bool ending_barrage_flag = false;


    private bool bgm_once_flag = false;
    private float volume_state = 0;
    private string st_owner = "";
    public GameObject next_stage;
    public int state = 0;
    private float bug_time = 0.0f;
    // Use this for initialization
    void Start()
    {
        if (StageSelectManager.ST_OWNER_NUMBER != null)
            st_owner = StageSelectManager.ST_OWNER_NUMBER.Substring(0, 1);
        if(StageSelectManager.ST_OWNER_NUMBER == "5_10")
        {
            clear_flag = false;
        }
        //ヌルでないとき成立する
        Debug.Log("PlayerPrefsmdayo" + PlayerPrefs.GetInt("3_1" + "star"));
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_1")
        {
            LIMIT_TURN = int.Parse(LIMITE[0]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_2")
        {
            LIMIT_TURN = int.Parse(LIMITE[1]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_3")
        {
            LIMIT_TURN = int.Parse(LIMITE[2]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_4")
        {
            LIMIT_TURN = int.Parse(LIMITE[3]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_5")
        {
            LIMIT_TURN = int.Parse(LIMITE[4]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_6")
        {
            LIMIT_TURN = int.Parse(LIMITE[5]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_7")
        {
            LIMIT_TURN = int.Parse(LIMITE[6]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_8")
        {
            LIMIT_TURN = int.Parse(LIMITE[7]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_9")
        {
            LIMIT_TURN = int.Parse(LIMITE[8]);
        }
        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "1_10")
        {
            LIMIT_TURN = int.Parse(LIMITE[9]);
        }

        if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_1")
        {
            Debug.Log("iiiiiiiiiiiiiiiiii");
            goal_trun.GetComponent<Text>().text = GOAL_TURN[0];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            //LIMIT_TURN = LIMITE[]
            LIMIT_TURN = int.Parse(LIMITE[10]);
        }
        //goal_trun.GetComponent<Text>().text = "10";

        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_2")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[1];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[11]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_3")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[2];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[12]);

        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_4")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[3];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[13]);

        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_5")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[4];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[14]);
        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_6")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[5];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[15]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_7")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[6];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[16]);

        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_8")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[7];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[17]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_9")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[8];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[18]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "2_10")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[9];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[19]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_1")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[10];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[20]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_2")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[11];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[21]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_3")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[22]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_4")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[23]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_5")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[24]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_6")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[25]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_7")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[26]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_8")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[27]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_9")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[28]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "3_10")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[29]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_1")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[30]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_2")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[31]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_3")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[32]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_4")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[33]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_5")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[34]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_6")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[35]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_7")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[36]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_8")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[37]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_9")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[38]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "4_10")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[39]);



        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_1")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[40]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_2")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[41]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_3")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[42]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_4")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[43]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_5")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[44]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_6")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[45]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_7")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[46]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_8")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[47]);


        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_9")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[48]);

        }
        else if (StageSelectManager.ST_OWNER_NUMBER != null && StageSelectManager.ST_OWNER_NUMBER == "5_10")
        {
            goal_trun.GetComponent<Text>().text = GOAL_TURN[12];
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
            LIMIT_TURN = int.Parse(LIMITE[49]);

        }


        else if (StageSelectManager.ST_OWNER_NUMBER == null)
        {
            goal_trun.GetComponent<Text>().text = "1";
            clear_goal_turn.GetComponent<Text>().text = goal_trun.GetComponent<Text>().text.ToString();
        }


        mainSource = Camera.main.gameObject.GetComponent<MainCameraScr>();
        for (int i = 0; i < 3; i++)
        {
            once_flag[i] = false;
        }
        turn_limit.GetComponent<Text>().text = LIMIT_TURN.ToString();
        MAX_TURN = int.Parse(turn_limit.gameObject.GetComponent<Text>().text);
        //		GameObject.Find ("Debug/Text").gameObject.GetComponent<Text> ().text = MAX_TURN.ToString ();
    }


    // Update is called once per frame
    void Update()
    {
        if(StageSelectManager.ST_OWNER_NUMBER == "5_10" && bug_time < 1)
        {
            clear_flag = false;
            bug_time += Time.deltaTime;
            if(bug_time > 1)
            {
                bug_time = 1;
            }
        }
        block_number = 0;
        gimic_number = 0;

        block_number += GameObject.FindGameObjectsWithTag("Small_Block").Length;
        block_number += GameObject.FindGameObjectsWithTag("Big_Block").Length;
        block_number += GameObject.FindGameObjectsWithTag("Blue_Block").Length;

        if (GameObject.FindGameObjectsWithTag("BlockPiece").Length >= 1)
        {
            block_number += 1;
        }

        //block_number += GameObject.FindGameObjectsWithTag("Gimic").Length;

        gimic_object = GameObject.FindGameObjectsWithTag("Gimic");
        for (int i = 0; i < gimic_object.Length; i++)
        {
            if (gimic_object[i].GetComponent<Wall_Gimic>().not_count == 0)
            {
                gimic_number += 1;
            }
        }


        Debug.Log("B:" + block_number + " G:" + gimic_number);

        //打ち出した後打数内でクリアできなかった場合
        if (GetComponent<MainCameraScr>().main_move_state == 0)
        {
           
            //Debug.Log("wwwwwwwwwwwwwwww");
            GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;


            Mission_Lose();
            GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;


        }
        TouchInfo _info = AppUtil.GetTouch();
        //gameOver_obj.SetActive(true);
        if (_info == TouchInfo.Began)
        {
            TouchObjectSearch();
        }
        if (gameOver_obj.activeSelf)
        {
            if (volume_state == 0)
            {
                float v = GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().volume;
                v -= 0.05f;
                if (v <= 0)
                {
                    v = 0;
                    volume_state = 1;
                }
                GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().volume = v;
            }
            else if (volume_state == 1)
            {
                float v = GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().volume;
                v += 0.05f;
                if (v >= 1)
                {
                    v = 1;
                }
                GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().volume = v;
                if (bgm_once_flag == false)
                {
                    bgm_once_flag = true;
                    GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().clip = null;
                    GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().clip = gameover_bgm;
                    GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().Play();
                    GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().loop = false;

                }

            }
            Camera.main.GetComponent<MainCameraScr>().pause_freeze_flag = true;
            GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;
        }
        //if (mission_state == (int)MISSION_STATE.STAGE_1_1)
        //{
        //    clear_flag = Resin_GetNumber(4);
        //}
        //        clear_flag = true;
        //クリア条件を満たしたらカラーをいじっている
        if (clear_flag)
        {
            Camera.main.GetComponent<MainCameraScr>().pause_freeze_flag = true;
            if (clear_state == 0)
            {
                PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER + "clear", 1);
                //				clear_text.enabled = true;
                Color c = clear_text.color;
                c.a += 1.0f * Time.deltaTime;

               
                GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;
                if (c.a >= 1.0f)
                {
                    c.a = 1.0f;
                    clear_state = 1;
                }
                clear_text.color = c;
            }
            else if (clear_state == 1)
            {
                //ステージクリアしたら（ステージクリアのテキストが表示される時間）
                clear_count += Time.deltaTime;
                if (clear_count > 1.0f)
                {
                    clear_state = 2;
                }

                if (game_clear_bgm_state == 0)
                {
                    if (bgm_clear_flag == false)
                    {
                        bgm_once_flag = true;
                        GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().clip = null;
                        GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().clip = game_clear_bgm;
                        GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().Play();
                        GameObject.Find("BGM").gameObject.GetComponent<AudioSource>().loop = false;
                        bgm_clear_flag = false;

                    }

                }
            }
            else if (clear_state == 2)
            {
                clear_text.color = new Color(1, 1, 1, 0);
                if(st_owner != "1")
                {
                    clear_pop.SetActive(true);
                }


                GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;
                

                //           GameObject.Find ("clear_number").gameObject.GetComponent<Text> ().text = 
                //(Camera.main.GetComponent<Manager> ().shot_state - 1).ToString ();        //この処理をManagerように変えて入れる
                if (st_owner != "1")
                {
                    if (clear_once_flag == false)
                    {
                        clear_once_flag = true;
                        if (Mission_1(CLEAR_LAMP_LEVEL))
                        {
                            star_obj[2].SetActive(true);
                            if (once_flag[0] == false)
                            {
                                clear_number += 1;
                            }
                        }
                        if (Mission_2(int.Parse(goal_trun.GetComponent<Text>().text)))
                        {
                            star_obj[0].SetActive(true);
                            if (once_flag[1] == false)
                            {
                                clear_number += 1;
                            }
                        }
                        if (Mission_3())
                        {
                            star_obj[1].SetActive(true);
                            if (once_flag[2] == false)
                            {
                                clear_number += 1;
                            }
                        }
                    }

                    //Debug.Log("クリアナンバー" + clear_number);
                    if (clear_number >= PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER + "star"))
                    {
                        PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER + "star", clear_number);
                        Debug.Log("PlayerPrefsmdayo" + PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER + "star"));
                    }
                }
                else
                {
                    PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER + "star", 3);
                }

                stage_select_count += Time.deltaTime;
                if(st_owner != "1")
                {
                    if (stage_select_count > 3)
                    {
                        clear_state = 3;
                    }
                }
                else
                {
                    clear_state = 3;
                }
            }
            else if (clear_state == 3)
            {
                if(st_owner != "1")
                {
                    GameObject.Find("Touch").gameObject.GetComponent<Text>().color =
                    new Color(0, 0, 0, 1);
                    TouchInfo info = AppUtil.GetTouch();
                    if (info == TouchInfo.Ended)
                    {
                        clear_state = 4;
                    }
                }
                else
                {
                    clear_state = 4;
                }
            }
            if (clear_state == 4)
            {
                //Color c = fade.color;
                //c.a += 0.02f;
                //if(c.a > 1.0f)
                //{
                //    c.a = 1.0f;

                //    if (PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER) == 0)
                //    {
                //        PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER, 1);
                //    }
                //    SceneManager.LoadScene("StageSelect_Scene");
                //}
                //fade.color = c;
                //TouchInfo info = AppUtil.GetTouch();

                Debug.Log("yeeeh");
                clear_pop.SetActive(false);
                string st = StageSelectManager.ST_OWNER_NUMBER;
                // 1_1の一番後ろの文字列を抽出してる 1 tail = 1
                int len = st.Length;
                string tail = "";
                if(len >= 4)
                {
                    tail = st.Substring(2, 2); // 1
                }
                else if(len < 4)
                {
                    tail = st.Substring(2, 1); // 1
                }
                if(tail == "10")
                {
                    if (st_owner == "5" && ending_flag == false && ending_barrage_flag == false)
                    {
                        GameObject.Find("Common/Canvas/result_black 1/Retry_result").GetComponent<Collider2D>().enabled = false;
                        GameObject.Find("Common/Canvas/result_black 1/Stage_Select_result").GetComponent<Collider2D>().enabled= false;

                        ending_flag = true;
                        Camera.main.GetComponent<Now_Loading>().Load_NextScene_Ending();
                        ending_barrage_flag = true;
                        GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                        GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;
                       
                    }
                    Result_obj.gameObject.SetActive(true);
                    Vector3 retry_pos = GameObject.Find("Common/Canvas/result_black 1/Retry_result").GetComponent<RectTransform>().transform.localPosition;
                    retry_pos.x = 362.0f;
                    retry_pos.y = -155.0f;
                    GameObject.Find("Common/Canvas/result_black 1/Retry_result").GetComponent<RectTransform>().transform.localPosition = retry_pos;

                    Vector3 select_pos = GameObject.Find("Common/Canvas/result_black 1/Stage_Select_result").GetComponent<RectTransform>().transform.localPosition;
                    select_pos.x = -338.0f;
                    select_pos.y = -155.0f;
                    GameObject.Find("Common/Canvas/result_black 1/Stage_Select_result").GetComponent<RectTransform>().transform.localPosition = select_pos;
                    next_stage.SetActive(false);
                }
                else
                {
                    Result_obj.gameObject.SetActive(true);

                }
            }
        }

        if (Result_obj.gameObject.activeSelf == true)
        {
            if (_info == TouchInfo.Began)
            {
                TouchObjectCheck();
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
            if (mainSource.right_obj[i].GetComponent<Wall_Gimic>().not_count < clear)
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
        int temp = Camera.main.GetComponent<Manager>().shot_state - 1;
        if (temp <= n)
        {
            return true;
        }
        return false;
    }

    bool Mission_3()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Small_Block");
        //GameObject[] obj_2 = GameObject.FindGameObjectsWithTag("Big_Block");
        //GameObject[] obj_3 = GameObject.FindGameObjectsWithTag("BlockPiece");
        //GameObject[] obj_4 = GameObject.FindGameObjectsWithTag("No_Seed_Block");
        GameObject[] obj_5 = GameObject.FindGameObjectsWithTag("No_Seed_Green_Block");



        if (obj.Length == 0 && obj_5.Length == 0)
        {
            return true;
        }
        return false;
    }
    //レッドブロック,ブルーブロックを認識させないと速攻ゲームオーバーになるのでレングス追加
    bool Mission_4()
    {
        GameObject[] obj = GameObject.FindGameObjectsWithTag("Small_Block");
        GameObject[] obj_2 = GameObject.FindGameObjectsWithTag("Big_Block");
        GameObject[] obj_3 = GameObject.FindGameObjectsWithTag("BlockPiece");
        //GameObject[] obj_4 = GameObject.FindGameObjectsWithTag("No_Seed_Block");
        GameObject[] obj_5 = GameObject.FindGameObjectsWithTag("No_Seed_Green_Block");
        GameObject[] obj_6 = GameObject.FindGameObjectsWithTag("Blue_Block");




        if (obj.Length == 0 && obj_2.Length == 0 && obj_3.Length == 0 && obj_5.Length == 0 && obj_6.Length == 0)
        {
            return true;
        }
        return false;
    }

    //ゲームオーバー時にゲームオーバー画面表示しステージセレクト画面に戻る
    void Mission_Lose()
    {

        if (int.Parse(GameObject.Find("Trun_Current").gameObject.GetComponent<Text>().text) <= 0)
        {
            Debug.Log("ポーズ");
            
            int a = 0;
            GameObject.Find("Trun_Current").gameObject.GetComponent<Text>().text = a.ToString();
            GameObject.Find("turn_flame").GetComponent<Image>().enabled = false;
            GameObject.Find("Turn_Number").GetComponent<Text>().enabled = false;
            Debug.Log("打数でクリアできなかった");
            gameOver_obj.SetActive(true);
            GameObject.Find("Common/Canvas/pause").GetComponent<CircleCollider2D>().enabled = false;



            Time.timeScale = 0.0f;
        }
        if (block_number < gimic_number)
        {
            GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;
            Debug.Log("ブロックの数が少ないので終わり");
            gameOver_obj.SetActive(true);


        }

        if (Mission_4())
        {
            // 全部壊れてる
            if (Mission_1(1) == false)
            {

                Debug.Log("全部壊れていてかつ光ってないものありでクリアできませんでした");

                GameObject.Find("pause").gameObject.GetComponent<Collider2D>().enabled = false;


                gameOver_obj.gameObject.SetActive(true);




                Time.timeScale = 0.0f;
            }
        }
       


    }

    void TouchObjectSearch()
    {
        Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);


        if (collition2d != null)
        {
            Debug.Log(collition2d.gameObject.name);
            if (collition2d.gameObject.name == "retry" && game_over_barrage_flag == false)
            {

                if (gameOver_obj.gameObject.activeSelf)
                {
                    //SceneManager.LoadScene("Stage_"+StageSelectManager.ST_OWNER_NUMBER+"_Scene");
                    Camera.main.GetComponent<Now_Loading>().LoadNextScene();
                    game_over_barrage_flag = true;
                   
                    GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                    GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;
                }
            }
            if (collition2d.gameObject.name == "stageselect" && game_over_barrage_flag == false)
            {
                if (gameOver_obj.gameObject.activeSelf)
                {
                    //SceneManager.LoadScene("StageSelect_Scene");
                    Camera.main.GetComponent<Now_Loading>().Load_NextScene_Title();
                    game_over_barrage_flag = true; 
                    GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                    GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;
                    //state = _Utility.Flashing(GameObject.Find("Now_Loading").GetComponent<Image>(), 1.5f, state);
                }
            }
        }

    }

    void TouchObjectCheck()
    {
        Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);


        if (collition2d != null)
        {
            Debug.Log(collition2d.gameObject.name);
            if (collition2d.gameObject.name == "Retry_result" &&  clear_barrage_flag == false)
            {
                Debug.Log(StageSelectManager.ST_OWNER_NUMBER);

                //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                Camera.main.GetComponent<Now_Loading>().LoadNextScene();

                GetComponent<Sound_Manager>().Stage_Choice_SE();
                clear_barrage_flag = true;
                GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;

            }
            if (collition2d.gameObject.name == "Stage_Select_result" && clear_barrage_flag == false)
            {

                Camera.main.GetComponent<Now_Loading>().Load_NextScene_Title();
                GetComponent<Sound_Manager>().Stage_Choice_SE();
                clear_barrage_flag = true;
                GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;
            }
            if (collition2d.gameObject.name == "Next_Stage" && clear_barrage_flag == false)
            {
                // ST_OWNER_NUMBER 1_1
                // st = 1_1
                string st = StageSelectManager.ST_OWNER_NUMBER;
                // 1_1の一番後ろの文字列を抽出してる 1 tail = 1
                string tail = st.Substring(2, 1); // 1
                // 1_1の一番前の文字列から２文字抽出してる head = 1_
                string head = st.Substring(0, 2); // 1_
                // tail =  1 このtailをint型にキャストしてその値を代入してる tem_tailは今はint型の1が入ってる
                int tem_tail = int.Parse(tail);
                // int型のtem_tailっていう値に１プラスして2にする tem_tail = 2
                tem_tail += 1;
                // head = 1_ tem_tail =2(int) だから文字列の連結を使って head(1_) + tem_tailをstring型に再度キャストしたものを
                // 連結させる res = 1_2
                string res = head + tem_tail.ToString();
                StageSelectManager.ST_OWNER_NUMBER = res;
                Camera.main.GetComponent<Now_Loading>().LoadNextScene();
                GetComponent<Sound_Manager>().Stage_Choice_SE();
                clear_barrage_flag = true;
                GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;
                //SceneManager.LoadScene("Stage_"+res + "_Scene");
            }
        }

    }
}
