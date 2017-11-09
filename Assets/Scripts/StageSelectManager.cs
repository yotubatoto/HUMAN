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
        Execute();
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
            }
        }
        if (touchFlag_ == true)
        {
            if (info == TouchInfo.Ended)
            {
                endPos = AppUtil.GetTouchWorldPosition(Camera.main);
                if (startPos.x > endPos.x)
                {
                    if (startPos.x - endPos.x <= 0.02)
                    {
                        TouchObjectFind();
                    }
                    pos = transform.position;
                    pos.x -= 7;
                    flag = true;
                }
                else if (startPos.x < endPos.x)
                {
                    if (endPos.x - startPos.x <= 0.02)
                    {
                        TouchObjectFind();
                    }
                    pos = transform.position;
                    pos.x += 7;
                    flag = false;
                }
                else
                {
                    TouchObjectFind();
                }
                onceFlag = true;
                touchFlag_ = false;
            }
        }

        if (onceFlag == true)
        {
            //Debug.Log(flag);
            if (!(((transform.position.x >= 0 && transform.position.x < 7) && flag == false)
                 || ((transform.position.x <= -21) && flag == true)))
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


    void TouchObjectFind()
    {
        //if (Input.GetMouseButtonDown(0))
        //{
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        if (int.Parse(collition2d.gameObject.name) - 1 <= clear)
        {
            if (collition2d)
            {
                Debug.Log(collition2d.gameObject.name.ToString());
                SceneManager.LoadScene("Stage_" + collition2d.gameObject.name.ToString() + "_Scene");
            }
        }
        //}
    }
}
