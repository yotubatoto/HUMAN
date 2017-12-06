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
	public static string ST_OWNER_NUMBER = "";
    private bool se_flag = false;
    Color color;
    public GameObject pop_obj;
    TouchInfo info;
    // Use this for initialization
    void Awake()
    {
        //PlayerPrefs.SetInt("1_2",0);
        //ST_OWNER_NUMBER = "";

        //if (PlayerPrefs.GetInt("1_1")==1)
        //{
        //    Debug.Log("1_1クリアしている");
        //}
        //if (PlayerPrefs.GetInt("1_2") == 1)
        //{
        //    Debug.Log("1_2クリアしている");
        //    GameObject.Find("_2").GetComponent<SpriteRenderer>().color = new Color(1.0f, 1.0f, 1.0f, 1.0f);

        //}
        //else
        //{
        //    if(GameObject.Find("_2") != null)
        //    {
        //        GameObject.Find("_2").GetComponent<SpriteRenderer>().color = new Color(0.0f, 0.0f, 0.0f, 1.0f);
        //    }
        //}
        //PlayerPrefs.SetInt("item", 0);
        //PlayerPrefs.SetInt("clear", 0);

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

    }

    // Update is called once per frame
    void Update()
    {
        info = AppUtil.GetTouch();
        Debug.Log(transform.position);
        Execute();
    
        if (pop_obj.gameObject.activeSelf == true)
        {
            Debug.Log(PlayerPrefs.GetInt("1_1star"));
            if (transform.position.x <= 0 && transform.position.x > -20.5f)
            {
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
            }

            if (transform.position.x <= -20.5f && transform.position.x > -41.0f)
            {
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
            }
            
            if(transform.position.x <= -41.0f)
            {
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
           


            if (info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);
                if(collition2d != null)
                {
                    if(collition2d.gameObject.name == "_1" || collition2d.gameObject.name == "_2" ||
                        collition2d.gameObject.name == "_3")
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

    void Execute()
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
					TouchObjectFind("col",1);
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
                transform.position = Vector3.Lerp(transform.position, pos, c += 0.01f);
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
        if(collition2d != null)
        {
            if (collition2d.gameObject.name == name)
            {
                if (se_flag == false)
                {
                    se_flag = true;
                    GetComponent<Sound_Manager>().Decision_SE();
                    if(name == "col")
                    {
                        if(pop_obj.gameObject.activeSelf == false)
                        {
                            pop_obj.SetActive(true);
                        }
                    }
                }
                //Camera.main.GetComponent<Stage_Controller>().camera_move_state = move_state;
            }
        }
    }

    void TouchObjectFind()
    {
        //Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

        //Debug.Log(collition2d.gameObject.name);
        if (collition2d != null)
        {
            if (collition2d.gameObject.name == "_1")
            {
                Debug.Log(transform.position);

                if (transform.position.x <= 0 && transform.position.x > -20.5f)
                {
                    ST_OWNER_NUMBER = "1_1";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if (transform.position.x <= -20.5f && transform.position.x > -41.0f)
                {
                    ST_OWNER_NUMBER = "2_1";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if ((int)transform.position.x <= -41.0f)
                {
                    ST_OWNER_NUMBER = "3_1";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }
            if (collition2d.gameObject.name == "_2")
            {
                if (transform.position.x <= 0 && transform.position.x > -20.5f)
                {
                    ST_OWNER_NUMBER = "1_2";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if (transform.position.x <= -20.5f && transform.position.x > -41.0f)
                {
                    ST_OWNER_NUMBER = "2_2";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if ((int)transform.position.x <= -41.0f)
                {
                    ST_OWNER_NUMBER = "3_2";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }

            if (collition2d.gameObject.name == "_3")
            {
                if (transform.position.x <= 0 && transform.position.x > -20.5f)
                {
                    ST_OWNER_NUMBER = "1_3";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if (transform.position.x <= -20.5f && transform.position.x > -41.0f)
                {
                    ST_OWNER_NUMBER = "2_3";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
                if ((int)transform.position.x <= -41.0f)
                {
                    ST_OWNER_NUMBER = "3_3";
                    GetComponent<Sound_Manager>().Stage_Choice_SE();
                    now_loading.GetComponent<Now_Loading>().LoadNextScene();
                    GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color
                        = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                    //SceneManager.LoadScene("Stage_1_Scene");
                }
            }
        }
    }
}
