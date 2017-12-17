using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StageSelectManager : MonoBehaviour
{
    private Vector2 startPos;
    private Vector2 endPos;
    private Vector2 pos;
    private bool onceFlag = false;
    private bool flag = false;
    private float time = 0.0f;
    private bool touchFlag_ = false;
    private float c = 0;
    private List<GameObject> childStage = new List<GameObject>();
    public int itemCount = 0;
    public static bool ST_CLEAR_FLAG;
    public GameObject now_loading;
    public int clear = 0;
    public float move_speed = 20.5f;
	public static string ST_OWNER_NUMBER = null;
    private bool se_flag = false;
    Color color;
    public GameObject pop_obj;
    public GameObject choice;
    public GameObject now_load_back;
    private Image now_load;
    private int now_load_state = 0; 

    TouchInfo info;
	public Text[] left = new Text[10];
    public Text[] right = new Text[10];

    
    void Awake()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            int gg = i + 1;
            childStage.Add(transform.Find(gg.ToString()).gameObject);
        }
    }
    void Start()
    {

        //PlayerPrefs.SetInt("1_1" + "star", 0);
        //変数「ClearStage」に「CLEARSTAGE」の値を代入しなおす
        //マルチタッチ無効
        Input.multiTouchEnabled = false;
		Time.timeScale = 1.0f;
        
    }

    // Update is called once per frame
    void Update()
    {
        
		// エスケープキー取得
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// アプリケーション終了
			Application.Quit();
			return;
		}
		//GameObject.Find ("debug_text").gameObject.GetComponent<Text> ().text = ((int)transform.position.x).ToString ();
        info = AppUtil.GetTouch();
        Debug.Log(transform.position);
        if (now_loading.gameObject.GetComponent<Image>().enabled == false)
        {
            Execute();

        }
        //if (now_loading.gameObject.GetComponent<Image> ().color.a == 0.0f)
        {
            //Debug.Log("aaaaa");
            //Execute();

		}

		
		

        if (pop_obj.gameObject.activeSelf == true)
        {
            //Debug.Log(PlayerPrefs.GetInt("1_1star"));

			if((int)transform.position.x <= -35.0f)
			{
				for (int i = 0; i < 3; i++) {
					left[i].text = "3";
					right[i].text = (i+1).ToString();
				}
				// 3-1
				if (PlayerPrefs.GetInt("3_1star") == 0)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_1star") == 1)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_1star") == 2)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_1star") == 3)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
				// 3-2
				if (PlayerPrefs.GetInt("3_2star") == 0)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_2star") == 1)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_2star") == 2)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_2star") == 3)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
				// 3-3
				if (PlayerPrefs.GetInt("3_3star") == 0)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_3star") == 1)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_3star") == 2)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("3_3star") == 3)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
			}
			else if ((int)transform.position.x <= -20.0f && (int)transform.position.x > -30.0f)
			{
				for (int i = 0; i < 10; i++) {
					left[i].text = "2";
					right[i].text = (i+1).ToString();
				}
				// 2-1
				if (PlayerPrefs.GetInt("2_1star") == 0)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_1star") == 1)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_1star") == 2)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_1star") == 3)
				{
					pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
				// 2-2
				if (PlayerPrefs.GetInt("2_2star") == 0)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_2star") == 1)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_2star") == 2)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_2star") == 3)
				{
					pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
				// 2-3
				if (PlayerPrefs.GetInt("2_3star") == 0)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_3star") == 1)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_3star") == 2)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
				}
				if (PlayerPrefs.GetInt("2_3star") == 3)
				{
					pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
					pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
				}
                //2-4
                if (PlayerPrefs.GetInt("2_4star") == 0)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_4star") == 1)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_3star") == 2)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_4star") == 3)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-5
                if (PlayerPrefs.GetInt("2_5star") == 0)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_5star") == 1)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_5star") == 2)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_5star") == 3)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-6
                if (PlayerPrefs.GetInt("2_6star") == 0)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_6star") == 1)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_6star") == 2)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_6star") == 3)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-7
                if (PlayerPrefs.GetInt("2_7star") == 0)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_3star") == 1)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_7star") == 2)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_7star") == 3)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-8
                if (PlayerPrefs.GetInt("2_8star") == 0)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_8star") == 1)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_8star") == 2)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_8star") == 3)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-9
                if (PlayerPrefs.GetInt("2_9star") == 0)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_9star") == 1)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_9star") == 2)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_9star") == 3)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //2-10
                if (PlayerPrefs.GetInt("2_10star") == 0)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_10star") == 1)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_10star") == 2)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("2_10star") == 3)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }
			else if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
            {
				for (int i = 0; i < 10; i++) {
					left[i].text = "1";
					right[i].text = (i+1).ToString();
				}
                // 1-1
                if (PlayerPrefs.GetInt("1_1star") == 0)
                {
                    pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_1star") == 1)
                {
                    pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_1star") == 2)
                {
                    pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_1star") == 3)
                {
                    pop_obj.transform.Find("_1/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_1/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_1/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                // 1-2
                if (PlayerPrefs.GetInt("1_2star") == 0)
                {
                    pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_2star") == 1)
                {
                    pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_2star") == 2)
                {
                    pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_2star") == 3)
                {
                    pop_obj.transform.Find("_2/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_2/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_2/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                // 1-3
                if (PlayerPrefs.GetInt("1_3star") == 0)
                {
                    pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_3star") == 1)
                {
                    pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_3star") == 2)
                {
                    pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_3star") == 3)
                {
                    pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-4
                if (PlayerPrefs.GetInt("1_4star") == 0)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_4star") == 1)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_4star") == 2)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_4star") == 3)
                {
                    pop_obj.transform.Find("_4/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_4/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-5
                if (PlayerPrefs.GetInt("1_5star") == 0)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_5star") == 1)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_5star") == 2)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_5star") == 3)
                {
                    pop_obj.transform.Find("_5/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_5/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-6
                if (PlayerPrefs.GetInt("1_6star") == 0)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_6star") == 1)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_6star") == 2)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_6star") == 3)
                {
                    pop_obj.transform.Find("_6/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_6/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-7
                if (PlayerPrefs.GetInt("1_7star") == 0)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_7star") == 1)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_7star") == 2)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_7star") == 3)
                {
                    pop_obj.transform.Find("_7/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_7/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-8
                if (PlayerPrefs.GetInt("1_8star") == 0)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_8star") == 1)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_8star") == 2)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_8star") == 3)
                {
                    pop_obj.transform.Find("_8/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_8/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-9
                if (PlayerPrefs.GetInt("1_9star") == 0)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_9star") == 1)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_9star") == 2)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_9star") == 3)
                {
                    pop_obj.transform.Find("_9/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_9/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
                //1-10
                if (PlayerPrefs.GetInt("1_10star") == 0)
                {
                    pop_obj.transform.Find("_3/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_3/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_3/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_10star") == 1)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_10star") == 2)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 0);
                }
                if (PlayerPrefs.GetInt("1_10star") == 3)
                {
                    pop_obj.transform.Find("_10/Star_1").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_2").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                    pop_obj.transform.Find("_10/Star_3").gameObject.GetComponent<Image>().color = new Color(1, 1, 1, 1);
                }
            }

			if (now_loading.gameObject.GetComponent<Image> ().color.a == 0.0f) 
			{
				if (info == TouchInfo.Began)
				{
					Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);
					if(collition2d != null)
					{
						if(collition2d.gameObject.name == "_1" || collition2d.gameObject.name == "_2" ||
							collition2d.gameObject.name == "_3" || collition2d.gameObject.name == "_4" || collition2d.gameObject.name == "_5"
                          || collition2d.gameObject.name == "_6" || collition2d.gameObject.name == "_7" || collition2d.gameObject.name == "_8"
                          || collition2d.gameObject.name == "_9" || collition2d.gameObject.name == "_10")
						{
							TouchObjectFind();
						}
					}
					else
					{
						pop_obj.SetActive(false);
					}


				}
			}
        }
    }

   public void Execute()
    {
        if (onceFlag == false || time > 0.6f)
        {
            if (info == TouchInfo.Began)
            {
                se_flag = false;
                // タッチ開始
                startPos = AppUtil.GetTouchWorldPosition(Camera.main);
                onceFlag = false;
                time = 0;
                touchFlag_ = true;
                c = 0;
                Camera.main.GetComponent<Stage_Controller>().camera_scr = 0.0f;
            }
        }
        if (touchFlag_ == true)
        {
            if (info == TouchInfo.Ended)
            {
                endPos = AppUtil.GetTouchWorldPosition(Camera.main);
				if((int)startPos.x == (int)endPos.x)
				{
                    TouchObjectFind("col", 1);
                    TouchObjectFind("vector_right", 1);
                    TouchObjectFind("vector_right(1)", 1);
                    TouchObjectFind("vector_left", 1);
                    TouchObjectFind("vector_left(1)", 1);


				}
                else if (startPos.x > endPos.x)
                {
                    if (startPos.x - endPos.x <= 0.02)
                    {
                        TouchObjectFind("col",1);
                    }
                    pos = transform.position;
                    pos.x -= move_speed;
                   
                    flag = true;
                }
                else if (startPos.x < endPos.x)
                {
                    if (endPos.x - startPos.x <= 0.02)
                    {
                        TouchObjectFind("col",1);
                    }
                    pos = transform.position;
                    pos.x += move_speed;
                    flag = false;
                }
               
                onceFlag = true;
                touchFlag_ = false;
            }
        }

        if (onceFlag == true)
        {
            //Debug.Log(flag);
            if (!(((transform.position.x >= 0 && transform.position.x < move_speed) && flag == false)
                 || ((transform.position.x <= -move_speed*2) && flag == true)))
            {
                //スワイプスピードカメラ
                transform.position = Vector3.Lerp(transform.position, pos, c += 0.1f);
                if (c > 1)
                {
                    c = 1;
                }
            }
            time += Time.deltaTime;
        }
    }


    void TouchObjectFind(string name,int move_state)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        //Debug.Log(collition2d.gameObject.name);
        
            if (collition2d != null)
            {
                if (collition2d.gameObject.name == name)
                {
                    if (se_flag == false)
                    {
                        se_flag = true;
                        GetComponent<Sound_Manager>().Decision_SE();
                        if (name == "col")
                        {
                            if (pop_obj.gameObject.activeSelf == false)
                            {
                                pop_obj.SetActive(true);
                            }
                        }

                        if (name == "vector_right" || name == "vector_right(1)" || name == "vector_left" || name == "vector_left(1)")
                        {
                            Debug.Log("YFYyuf");
                        }
                        
                    }
                    
                    
                    //Camera.main.GetComponent<Stage_Controller>().camera_move_state = move_state;
                }
        

        
            
        }
    }

    void TouchObjectFind()
    {
		Debug.Log ((int)transform.position.x);
        //Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

        //Debug.Log(collition2d.gameObject.name);
        if (collition2d != null)
        {
            now_loading.GetComponent<Image>().enabled = true;
            now_load = GameObject.Find("Now_Loading").GetComponent<Image>();
            now_load_state = _Utility.Flashing(now_load, 1.5f, now_load_state);
            now_load_back.GetComponent<Image>().enabled = true;

            if (collition2d.gameObject.name == "_1")
            {
                Debug.Log(transform.position);
				if ((int)transform.position.x <= -36.0f)
				{
					ST_OWNER_NUMBER = "3_1";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
					now_loading.GetComponent<Now_Loading>().LoadNextScene();
					GameObject.Find("Now_Loading").GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);


					//SceneManager.LoadScene("Stage_1_Scene");
				}
				else if ((int)transform.position.x <= -20.0f)
				{
					ST_OWNER_NUMBER = "2_1";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
					now_loading.GetComponent<Now_Loading>().LoadNextScene();
					GameObject.Find("Now_Loading").GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);


					//SceneManager.LoadScene("Stage_1_Scene");
				}
				else if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.0f)
                {
                    ST_OWNER_NUMBER = "1_1";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }
            if (collition2d.gameObject.name == "_2")
            {
                if ((int)transform.position.x <= -36.0f)
                {
                    ST_OWNER_NUMBER = "3_2";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
				else if ((int)transform.position.x <= -20.0f)
				{
					ST_OWNER_NUMBER = "2_2";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
					now_loading.GetComponent<Now_Loading>().LoadNextScene();
					GameObject.Find("Now_Loading").GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);

					//SceneManager.LoadScene("Stage_1_Scene");
				}
				else if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
				{
					ST_OWNER_NUMBER = "1_2";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
					now_loading.GetComponent<Now_Loading>().LoadNextScene();
					GameObject.Find("Now_Loading").GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);

                   
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_3")
            {
				if ((int)transform.position.x <= -36.0f)
				{
					ST_OWNER_NUMBER = "3_3";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
					now_loading.GetComponent<Now_Loading>().GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);

					//SceneManager.LoadScene("Stage_1_Scene");
				}
				else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_3";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
				else if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
				{
					ST_OWNER_NUMBER = "1_3";
					GetComponent<Sound_Manager>().Stage_Choice_SE();
					now_loading.GetComponent<Now_Loading>().LoadNextScene();
					GameObject.Find("Now_Loading").GetComponent<Image>().color
					= new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
              
              
            }

            if (collition2d.gameObject.name == "_4")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_4";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                   
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_4";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_5")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_5";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                   
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_5";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_6")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_6";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_6";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_7")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_7";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_7";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_8")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_8";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);

                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_8";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_9")
            {
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_9";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_9";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_10")
            {                
                if ((int)transform.position.x <= 0 && (int)transform.position.x > -10.5f)
                {
                    ST_OWNER_NUMBER = "1_10";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                    = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                else if ((int)transform.position.x <= -20.0f)
                {
                    ST_OWNER_NUMBER = "2_10";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<Image>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }
        }
    }

}
