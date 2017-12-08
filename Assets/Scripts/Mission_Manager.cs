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
    public Image clear_text;
    private float clear_time = 0.0f;
    //ステージクリアしたら（ステージクリアのテキストが表示される時間）
    private float clear_count = 0.0f;
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
//    public int MAX_SHOT = 1;
    public GameObject gameOver_obj;
    private float delay_time = 0.0f;
    private bool clear_once_flag = false;
	public GameObject[] star_obj = new GameObject[3];
	private int MAX_TURN = 15;
	public int LIMIT_TURN = 10;
	public GameObject turn_limit;
	public int CLEAR_LAMP_LEVEL = 1;
    // Use this for initialization
    void Start () 
    {
		mainSource = Camera.main.gameObject.GetComponent<MainCameraScr> ();
		for(int i=0;i<3;i++)
		{
			once_flag [i] = false;
		}
        turn_limit.GetComponent<Text>().text = LIMIT_TURN.ToString();
        MAX_TURN = int.Parse(turn_limit.gameObject.GetComponent<Text>().text);
//		GameObject.Find ("Debug/Text").gameObject.GetComponent<Text> ().text = MAX_TURN.ToString ();
	}

	
	// Update is called once per frame
	void Update () 
    {   
        //打ち出した後打数内でクリアできなかった場合
        if (GetComponent<MainCameraScr>().main_move_state == 0)
        {
            Mission_Lose();

        }
        TouchInfo _info = AppUtil.GetTouch();
        //gameOver_obj.SetActive(true);
        if(_info == TouchInfo.Began)
        {
            TouchObjectSearch();
        }
        if(gameOver_obj.activeSelf)
        {
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
			Camera.main.GetComponent<MainCameraScr> ().pause_freeze_flag = true;
			if (clear_state == 0) {
//				clear_text.enabled = true;
				Color c = clear_text.color;
				c.a += 0.01f;
				if (c.a >= 1.0f) {
					c.a = 1.0f;
					clear_state = 1;
				}
				clear_text.color = c;
			}
            else if(clear_state == 1)
            {
                //ステージクリアしたら（ステージクリアのテキストが表示される時間）
                clear_count += Time.deltaTime;
                if (clear_count > 1.0f)
                {
                    clear_state = 2;
                }
            }
            else if (clear_state == 2) 
            {
				clear_text.color = new Color(1,1,1,0);
				clear_pop.SetActive (true);
			
				GameObject.Find ("clear_number").gameObject.GetComponent<Text> ().text = 
					(Camera.main.GetComponent<Manager> ().shot_state - 1).ToString ();
                if(clear_once_flag == false)
                {
                    clear_once_flag = true;
					if (Mission_1(CLEAR_LAMP_LEVEL))
                    {
						star_obj [2].SetActive (true);
                        if (once_flag[0] == false)
                        {
                            clear_number += 1;
                        }
                    }
					if (Mission_2(MAX_TURN))
                    {
						star_obj [0].SetActive (true);
                        if (once_flag[1] == false)
                        {
                            clear_number += 1;
                        }
                    }
                    if (Mission_3())
                    {
						star_obj [1].SetActive (true);
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
                    Debug.Log("PlayerPrefsmdayo"+PlayerPrefs.GetInt(StageSelectManager.ST_OWNER_NUMBER + "star"));
                }
                stage_select_count += Time.deltaTime;
				if (stage_select_count > 3) {
					clear_state = 3;
				}
			} else if (clear_state == 3) 
			{
				
				GameObject.Find ("Touch").gameObject.GetComponent<Text> ().color = 
					new Color (0, 0, 0, 1);
				TouchInfo info = AppUtil.GetTouch();
				if (info == TouchInfo.Began) {
                    clear_state = 4;
				}
			}
            if (clear_state == 4)
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
			if (mainSource.right_obj[i].GetComponent<Wall_Gimic>().clear_count < clear)
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
        GameObject[] obj_2 = GameObject.FindGameObjectsWithTag("Big_Block");
        GameObject[] obj_3 = GameObject.FindGameObjectsWithTag("BlockPiece");
        if (obj.Length == 0 && obj_2.Length == 0 && obj_3.Length == 0) 
		{
			return true;
		}
		return false;
	}

    //ゲームオーバー時にゲームオーバー画面表示しステージセレクト画面に戻る
    void Mission_Lose()
    {
        if (int.Parse(GameObject.Find("Trun_Current").gameObject.GetComponent<Text>().text) > LIMIT_TURN)
        {
            GameObject.Find("Trun_Current").gameObject.GetComponent<Text>().text = LIMIT_TURN.ToString();
            Debug.Log("打数でクリアできなかった");
            gameOver_obj.gameObject.SetActive(true);
            Time.timeScale = 0.0f;
        }
       if(Mission_3())
        {
            // 全部壊れてる
            if(Mission_1(1) == false)
            {
                Debug.Log("全部壊れていてかつ光ってないものありでクリアできませんでした");
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
            if (collition2d.gameObject.name == "retry")
            {

                if (gameOver_obj.gameObject.activeSelf)
                {
                    SceneManager.LoadScene("Stage_"+StageSelectManager.ST_OWNER_NUMBER+"_Scene");
                }
            }
            if (collition2d.gameObject.name == "stageselect")
            {
                if (gameOver_obj.gameObject.activeSelf)
                {
                    SceneManager.LoadScene("StageSelect_Scene");
                }
            }
        }

    }
}
