using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Player_Collision : MonoBehaviour {
    public int item_count = 0;
    public Text item_text;
    private bool flashing_flag = false;
    public float flashing_time = 0;
    public GameObject camera;
    public GameObject enemy_coll_effect;
    private float delete_count = 0.0f;
    private GameObject obj = null;
    public GameObject[] point_line_obj = new GameObject[2];
    private bool bonus_count_flag = false;
    private float bonus_count = 0.0f;
    private int bonus_point = 0;
    private bool resin_coll_flag = false;
    public Text combo_text;
    private int number_of_times = 0;
    public bool bonus_flag = false;
    public GameObject goal;
	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        if (flashing_flag == true)
        {
            GetComponent<PlayerController>().Flashing();
            flashing_time += Time.deltaTime;
            if (flashing_time > 4.0f)
            {
                flashing_flag = false;
                GetComponent<PlayerController>().Flashing_Ini();
                flashing_time = 0;
                //レイヤーを元に戻している
                gameObject.layer = LayerName.Default;
            }
            else
            {//接触判定はずしている
                gameObject.layer = LayerName.Player;
            }
        }
        if(obj != null)
        {
            delete_count += Time.deltaTime;
            if(delete_count > 1)
            {
                Destroy(obj);
                obj = null;
                delete_count = 0.0f;
            }
        }

        if (bonus_count_flag == true)
        {
            bonus_count += Time.deltaTime;
            if (bonus_count > 3)
            {
                bonus_count_flag = false;
                bonus_point = 0;
                bonus_count = 0.0f;
                number_of_times = 0;
            }
        }
        combo_text.text = number_of_times.ToString();
	}
    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Enemy")
        {
            GetComponent<Sound_Manager>().SE();
            flashing_flag = true;
            Debug.Log("ooooooooo");
            camera.GetComponent<ShakeCamera>().Shake();
            
            item_count -= 1;
            if (item_count < 0)
            {
                item_count = 0;
            }
            item_text.text = item_count.ToString();
            obj = Instantiate(enemy_coll_effect, transform.position, Quaternion.identity) as GameObject;
        }

        if (coll.gameObject.tag == "Gimic")
        {

            GetComponent<Sound_Manager>().Resin_SE();
            if (bonus_count < 3)
            {
                bonus_count = 0;
                number_of_times += 1;
                if (bonus_count_flag)
                    bonus_point += 5;
            }
            bonus_count_flag = true;

            item_count += bonus_point;
            item_text.text = item_count.ToString();
        }
        

        
    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Time_count_up")
        {
            GetComponent<Sound_Manager>().Item_UP_SE();
            camera.GetComponent<Manager>().rimit_time += 5;
        }

        if (coll.gameObject.tag == "Bonus")
        {
            bonus_flag = true;

            GetComponent<Sound_Manager>().Item_UP_SE();
            
        }
        if (coll.gameObject.tag == "Goal") 
        {
            if (goal.GetComponent<SpriteRenderer>().color.a >= 1)
            {
                Debug.Log("ごーーる");
            }
        }
        
    }
    
}
