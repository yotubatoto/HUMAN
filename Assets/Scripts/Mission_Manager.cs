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
	public GameObject clear_pop;
	public List<string> mission_text = new List<string> ();
	MainCameraScr mainSource;
	bool[] once_flag = new bool[3];
	int clear_number = 0;
	float stage_select_count = 0.0f;
    public int MAX_SHOT = 1;
    public GameObject gameOver_obj;
    private float delay_time = 0.0f;
    private bool clear_once_flag = false;

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
        //打ち出した後打数内でクリアできなかった場合
        if (GetComponent<MainCameraScr>().main_move_state == 0)
        {
            Mission_Lose();

        }
        //if (mission_state == (int)MISSION_STATE.STAGE_1_1)
        //{
        //    clear_flag = Resin_GetNumber(4);
        //}
        //clear_flag = true;
        //クリア条件を満たしたらカラーをいじっている
        if (clear_flag)
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
                if(clear_once_flag == false)
                {
                    clear_once_flag = true;
                    if (Mission_1(2))
                    {
                        GameObject.Find("Mission_1/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 1);
                        if (once_flag[0] == false)
                        {
                            clear_number += 1;
                        }
                    }
                    else
                    {
                        GameObject.Find("Mission_1/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 0.3f);
                    }
                    if (Mission_2(10))
                    {
                        GameObject.Find("Mission_2/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 1);
                        if (once_flag[1] == false)
                        {
                            clear_number += 1;
                        }
                    }
                    else
                    {
                        GameObject.Find("Mission_2/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 0.3f);
                    }
                    if (Mission_3())
                    {
                        GameObject.Find("Mission_3/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 1);
                        if (once_flag[2] == false)
                        {
                            clear_number += 1;
                        }
                    }
                    else
                    {
                        GameObject.Find("Mission_3/Context").gameObject.GetComponent<Text>().color
                        = new Color(0, 0, 0, 0.3f);
                    }
                }

                //Debug.Log("クリアナンバー" + clear_number);
                if (clear_number >= PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER + "star"))
                {
                    PlayerPrefs.SetInt(StageSelectManager.ST_OWNER_NUMBER + "star", clear_number);
                    Debug.Log("PlayerPrefsmdayo"+PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER + "star"));
                }
                stage_select_count += Time.deltaTime;
				if (stage_select_count > 3) {
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

        if (gameOver_obj.gameObject.activeSelf == true)
        {
            TouchInfo t_info = AppUtil.GetTouch();
            delay_time += Time.deltaTime;
            if (t_info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

                if (collition2d != null)
                {
                    Debug.Log(collition2d.gameObject.name);

                    if (collition2d.gameObject.name == "retry")
                    {
                        SceneManager.LoadScene("Stage_" + "1_1" + "_Scene");
                        //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                    }
                    else if (collition2d.gameObject.name == "stageselect")
                    {
                        SceneManager.LoadScene("StageSelect_Scene");
                    }
                    else if (collition2d.gameObject.name == "pause" && delay_time >= 0.5f)
                    {
                        delay_time = 0.0f;
                        gameOver_obj.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (gameOver_obj.gameObject.activeSelf == true)
        {
            TouchInfo t_info = AppUtil.GetTouch();
            delay_time += Time.deltaTime;
            if (t_info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

                if (collition2d != null)
                {
                    Debug.Log(collition2d.gameObject.name);

                    if (collition2d.gameObject.name == "retry_2")
                    {
                        SceneManager.LoadScene("Stage_" + "1_2" + "_Scene");
                        //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                    }
                    else if (collition2d.gameObject.name == "stageselect_2")
                    {
                        SceneManager.LoadScene("StageSelect_Scene");
                    }
                    else if (collition2d.gameObject.name == "pause" && delay_time >= 0.5f)
                    {
                        delay_time = 0.0f;
                        gameOver_obj.gameObject.SetActive(false);
                    }
                }
            }
        }

        if (gameOver_obj.gameObject.activeSelf == true)
        {
            TouchInfo t_info = AppUtil.GetTouch();
            delay_time += Time.deltaTime;
            if (t_info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

                if (collition2d != null)
                {
                    Debug.Log(collition2d.gameObject.name);

                    if (collition2d.gameObject.name == "retry_3")
                    {
                        SceneManager.LoadScene("Stage_" + "1_3" + "_Scene");
                        //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                    }
                    else if (collition2d.gameObject.name == "stageselect_3")
                    {
                        SceneManager.LoadScene("StageSelect_Scene");
                    }
                    else if (collition2d.gameObject.name == "pause" && delay_time >= 0.5f)
                    {
                        delay_time = 0.0f;
                        gameOver_obj.gameObject.SetActive(false);
                    }
                }
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
		GameObject[] obj_2 = GameObject.FindGameObjectsWithTag ("Big_Block");
        if (obj.Length == 0 && obj_2.Length == 0) 
		{
			return true;
		}
		return false;
	}

    //ゲームオーバー時にゲームオーバー画面表示しステージセレクト画面に戻る
    void Mission_Lose()
    {
       if(Camera.main.GetComponent<Manager>().shot_state -1 > MAX_SHOT)
        {
            Debug.Log("打数でクリアできなかった");
            gameOver_obj.gameObject.SetActive(true);
        }
       if(Mission_3())
        {
            // 全部壊れてる
            if(Mission_1(1) == false)
            {
                Debug.Log("全部壊れていてかつ光ってないものありでクリアできませんでした");
                gameOver_obj.gameObject.SetActive(false);
            }
        }
    }

    void TouchObjectSearch(string name)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        Application.Quit();

        if (collition2d != null)
        {
            if (collition2d.gameObject.name == name)
            {
                Debug.Log("aaa");
                Application.Quit();
                if (name == "retry")
                {
                    if (gameOver_obj.gameObject.activeSelf == false)
                    {
                        gameOver_obj.SetActive(true);
                    }
                }

            }
        }

    }
}
