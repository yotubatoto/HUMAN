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
    public Sprite[] light_sprite = new Sprite[2];
    public float INITIAL_SIZE = 2f;  
    public float MAX_SIZE = 3f;
    public int number = 0;
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

    //private bool light_flag = false;
    // Use this for initialization
    void Start ()
    {
        child_circle = gameObject.transform.Find("Light").gameObject;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.localScale = new Vector3(100, 100, 1.0f);
        gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[number];

        if (size_state == 1)
        {
            s_plus += zoom_speed;
            transform.localScale = new Vector3(s_plus + INITIAL_SIZE, s_plus + INITIAL_SIZE, 0.0f);
            if ((s_plus + INITIAL_SIZE) > MAX_SIZE)
            {
                size_state = 2;
                s_plus = INITIAL_SIZE;
            }
        }

        else if (size_state == 2)
        {
            s_plus -= zoom_speed;
            transform.localScale = new Vector3(s_plus + INITIAL_SIZE, s_plus + INITIAL_SIZE, 0.0f);
            if ((s_plus + INITIAL_SIZE) < INITIAL_SIZE)
            {
                size_state = 0;
                s_plus = 0;
            }
        }


       
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

            //if(light_state == 1)
            //{
            //    u_plus += 0.005f;
            //    obj_3.transform.localScale = new Vector3(u_plus + 0.005f, u_plus + 0.005f, 0.0f);
            //    if(u_plus > 3.0f)
            //    {
            //        obj_3.transform.localScale = new Vector3(3.0f, 3.0f, 0);
            //        light_state = 2;
            //    }
            //}

            //else if(light_state == 2)
            //{
              
            //}


        }

        

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (size_state == 0)
        {
            if (coll.gameObject.tag == "Player")
            {
                number += 1;
                //light_chenge_flag = true;

                if (number == 2)
                {
                    number = 0;
                }

                gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[number];
                // 灯っている時
                if(number == 1)
                {
                    child_circle.GetComponent<SpriteRenderer>().enabled = true;
                }
                else
                {
                    child_circle.GetComponent<SpriteRenderer>().enabled = false;
                }
                size_state = 1;
                if(chage_state == 0)
                {
                    Debug.Log("aaa");
                    obj = Instantiate(chageprefab, transform.position, Quaternion.identity);
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

                //if (light_state == 0)
                //{
                //    obj_3 = Instantiate(light_up_prefab, transform.position, Quaternion.identity);
                //    light_state = 1;
                //}

            }
        }

    }
}
