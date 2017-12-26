using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Gimic : MonoBehaviour {
    public Text resin_text;
    private int resin_count = 0;
    public GameObject player;
    private int bonus = 1;
    private int size_state = 0;
    private float s_plus = 0.0f;
    public GameObject chageprefab;
    private GameObject obj = null;
    private int chage_state = 0;
    private float c_plus = 0.0f;
    public float zoom_speed = 0.5f;
    public Sprite[] light_sprite = new Sprite[4];
    public float INITIAL_SIZE = 2f;  
    public float MAX_SIZE = 3f;
    public int number = 0;
    //ランタンをともした数でのフラグ
    public bool clear_flag = false;
	public int clear_count = 0;
    //private bool light_chenge_flag = false;
    public GameObject explosionprefab;
    private GameObject obj_2;
    //点灯時にボヤっとした明るさを表示
    public GameObject light_up_prefab;
    private GameObject obj_3;
    private float u_plus = 0.0f;
    public int light_state = 0;
    private GameObject child_circle;
    public GameObject spark_prefab;
    //ぼんやりする光のサイズを変える
    private float l_plus = 5.0f;
    public int not_count = 0;
    private bool lamp_chenge_flag = false;
    public int chenge_number = 0;


   

    //private bool light_flag = false;
    // Use this for initialization
    void Start ()
    {
        child_circle = gameObject.transform.Find("Light").gameObject;
        GetComponent<SpriteRenderer>().sprite = light_sprite[0];
    }
	
	// Update is called once per frame
	void Update () 
    {
        //クリアするためのカウント　ここをかえることでランプレベルが○○のときクリアになる
        if (not_count != 0)
        {
            clear_flag = true;
        }
        //Debug.Log(clear_count);
        //transform.localScale = new Vector3(100, 100, 1.0f);
        //gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[number];

        //if (size_state == 1)
        //{
        //    s_plus += zoom_speed;
        //    transform.localScale = new Vector3(s_plus + INITIAL_SIZE, s_plus + INITIAL_SIZE, 0.0f);
        //    if ((s_plus + INITIAL_SIZE) > MAX_SIZE)
        //    {
        //        size_state = 2;
        //        s_plus = INITIAL_SIZE;
        //    }
        //}

        //else if (size_state == 2)
        //{
        //    s_plus -= zoom_speed;
        //    transform.localScale = new Vector3(s_plus + INITIAL_SIZE, s_plus + INITIAL_SIZE, 0.0f);
        //    if ((s_plus + INITIAL_SIZE) < INITIAL_SIZE)
        //    {
        //        size_state = 0;
        //        s_plus = 0;
        //    }
        //}


       
        //if (size_state == 1)
        //{
        //    s_plus += zoom_speed;
        //    transform.localScale = new Vector3(s_plus + 4, s_plus + 4, 0.0f);
        //    if ((s_plus + 4) > 6)
        //    {
        //        size_state = 2;
        //        s_plus = 4;
        //    }
        //}

        //else if (size_state == 2)
        //{
        //    s_plus -= zoom_speed;
        //    transform.localScale = new Vector3(s_plus +4, s_plus + 4, 0.0f);
        //    if ((s_plus + 4) < 4)
        //    {
        //        size_state = 0;
        //        s_plus = 0;
        //    }
        //}

        if (chage_state == 1)
        {
            if(obj != null)
            {
                //c_plus += 0.1f;
                //obj.transform.localScale = new Vector3(c_plus + 0.2f, c_plus + 0.2f, 0.0f);
                //Color c = obj.GetComponent<SpriteRenderer>().color;
                //c.a -= 0.005f;
                //obj.GetComponent<SpriteRenderer>().color = c;
                //if (c.a <= 0.0f)
                //{
                //    chage_state = 0;
                //    c_plus = 0;
                //    Destroy(obj.gameObject);
                //}

                c_plus += 0.04f;
                obj.transform.localScale = new Vector3(c_plus + 0.2f, c_plus + 0.2f, 0.0f);
                Color c = obj.GetComponent<SpriteRenderer>().color;
                c.a -= 0.02f;
                obj.GetComponent<SpriteRenderer>().color = c;
                if (c.a <= 0.0f)
                {
                    chage_state = 0;
                    c_plus = 0;
                    Destroy(obj.gameObject);
                }
            }

        }

        

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (size_state == 0)
        {
            if (coll.gameObject.tag == "Player")
            {
                //number += 1;
                //light_chenge_flag = true;

                //if (number == 2)
                //{
                //    number = 0;
                //}

                //gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[1];
                // 灯っている時
                //if (number == 1)
                //{
                //    child_circle.GetComponent<SpriteRenderer>().enabled = true;

                //}
                //else
                //{
                //    l_plus += 3.0f;
                //    if (l_plus > 20.0f)
                //        l_plus = 20.0f;
                //    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);
                //    Debug.Log(l_plus);
                //}
                not_count += GameObject.Find("Player").GetComponent<Player_Collision>().item_count;


                //バグが出たら解除　ここでカウントを初期化すると　常に０になり、GIMIC　SEがならせなくなる
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count = 0;
            
                //size_state = 1;

                //ランタンにぼやけた光を出す
                if(chage_state == 0)
                {
                    //Debug.Log("aaa");
                    obj = Instantiate(chageprefab, transform.position, Quaternion.identity);  //ぼやけた光を生成
                    if(number == 0)
                    {
                        Instantiate(spark_prefab, transform.position, Quaternion.identity);
                    }
                    else
                    {
                        Instantiate(explosionprefab, transform.position, Quaternion.identity);
                    }
                    chage_state = 1;
                }

            }

           

        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "BlockPiece")
        {
            Debug.Log("fffff");
            //Debug.Log("gyy");
            //clear_count += 1;
            lamp_chenge_flag = true;
            chenge_number += 1;
            Debug.Log("gugugug");
            GetComponent<Sound_Manager>().Gimic_SE();

            if (chenge_number > 3) { chenge_number = 3; }

            //花のオブジェクト生成
            if (not_count >= 1)
                {
                    //seedカウントが1より大きい場合光のレベルが１になる

                    //ぼやけか光の輪を出す
                    //レベル1
                    //if (number >= 1)
                    //{
                    child_circle.GetComponent<SpriteRenderer>().enabled = true;
                    //}
                    l_plus += 3.0f;                                                          //ぼやけた光の輪に大きさをプラスする
                    if (l_plus > 8.0f)
                        l_plus = 8.0f;
                    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);   //ぼやけた光の輪の大きさをキープする
                    //Debug.Log(l_plus);
                
                    gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[chenge_number];
                //ランタンをスイッチONにする
                Instantiate(explosionprefab, transform.position, Quaternion.identity);
                
                    //Debug.Log("カウント:" + not_count);
                }

                 

           
                //レベル2
                if (not_count >= 2)
                {
                    l_plus += 3.0f;
                    if (l_plus > 15.0f)
                        l_plus = 15.0f;
                    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);
                //Debug.Log(l_plus);
                
                    gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[chenge_number];

                //Debug.Log("カウント:" + not_count);
            }

               


            //レベル3
            if (not_count >= 3)
                {
                    l_plus += 3.0f;
                    if (l_plus > 30.0f)
                        l_plus = 30.0f;
                    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);
                //Debug.Log(l_plus);

                    gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[chenge_number];
                //Debug.Log("カウント:" + not_count);
            }

     


            ////レベル4
            //if (not_count >= 4)
            //{
            //    l_plus += 3.0f;
            //    if (l_plus > 17.0f)
            //        l_plus = 17.0f;
            //    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);
            //    Debug.Log(l_plus);
            //    gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[1];
            //    Debug.Log("カウント:" + not_count);

            //}


            ////レベル5
            //if (not_count >= 5)
            //{
            //    l_plus += 3.0f;
            //    if (l_plus > 20.0f)
            //        l_plus = 20.0f;
            //    child_circle.transform.localScale = new Vector3(l_plus, l_plus, 0.0f);
            //    Debug.Log(l_plus);
            //    gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[1];
            //    Debug.Log("カウント:" + not_count);

            //}

            //Destroy(collision.gameObject);

        }
    }

    public int GetnotCount()
    { return not_count; }

}
