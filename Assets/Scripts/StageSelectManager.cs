using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

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
    public int clear = 0;
    public float move_speed = 20.5f;
    // Use this for initialization
    void Awake()
    {
        //PlayerPrefs.SetInt("item", 0);
        //PlayerPrefs.SetInt("clear", 0);

        for (int i = 0; i < transform.childCount; i++)
        {
            int gg = i + 1;
            childStage.Add(transform.Find(gg.ToString()).gameObject);
        }
        itemCount = PlayerPrefs.GetInt("item", 0);
        clear = PlayerPrefs.GetInt("clear", 0);
        if (clear == 0)
        {
            //クリアカウント０のときステージ２以上をロックしている
            childStage[1].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
            childStage[2].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
            childStage[3].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        }
        if (clear == 1)
        {
            // 2ステージ目のアンロック処理をする
            childStage[2].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
            childStage[3].GetComponent<SpriteRenderer>().color = new Color(0.3f, 0.3f, 0.3f, 1.0f);
        }

        Debug.Log("アイテムカウント:" + itemCount);
    }
    void Start()
    {

        //変数「ClearStage」に「CLEARSTAGE」の値を代入しなおす
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main.GetComponent<Stage_Controller>().camera_move_state == 0)
        {
            Execute();
        }
        else if (Camera.main.GetComponent<Stage_Controller>().camera_move_state == 1)
        {
            TouchInfo info = AppUtil.GetTouch();

            if (info == TouchInfo.Began)
            {
                // タッチ開始
                //Camera.main.GetComponent<Stage_Controller>().camera_scr = 0.0f;
                TouchObjectFind("return", 2);
                TouchObjectFind();
            }
        }
    }

    void Execute()
    {
        TouchInfo info = AppUtil.GetTouch();
        if (onceFlag == false || time > 0.4f)
        {
            if (info == TouchInfo.Began)
            {
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
                 || ((transform.position.x <= -move_speed*3) && flag == true)))
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
                Camera.main.GetComponent<Stage_Controller>().camera_move_state = move_state;
            }
        }
    }

    void TouchObjectFind()
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        //Debug.Log(collition2d.gameObject.name);
        if (collition2d != null)
        {
            if (collition2d.gameObject.name == "_1")
            {
                SceneManager.LoadScene("Stage_1_Scene");
            }
            if (collition2d.gameObject.name == "_2")
            {
                SceneManager.LoadScene("Stage_2_Scene");
            }
        }
    }
}
