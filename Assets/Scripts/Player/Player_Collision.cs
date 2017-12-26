using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


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
    public GameObject effect_prefab;
    private bool gimic_coll_flag = false;
    public float VELOCITY_MAX = 20.0f;
    public int state = 0;
    //現在使ってない12/1日時点
    //public int lamp_count = 0;
    private int total_item_count = 0;
    public GameObject light_prefab;
    public Vector3 hit_coordinate;   //プレイヤーとランタンが当たった座標を調べる
    //public float life_time = 3.0f;
    //float time = 0f;
    //public int combo_count = 0;
    public bool touch_flag = false;  //最初に当たったランタンに光の種が行くようにする
    public string coll_name;

    bool once1_flag = false;

    // Use this for initialization
    void Start () 
    {
        //if(StageSelectManager.ST_OWNER_NUMBER == "1-1")
        //{
        //    total_item_count = Save_Load.Load("1");
        //}
        //time = 0;
    }
	
	// Update is called once per frame
	void Update () 
    {

        //damp_();
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

        //time += Time.deltaTime;

        //if (bonus_count_flag == true)
        //{
        //    bonus_count += Time.deltaTime;
        //    if (bonus_count > 3)
        //    {
        //        bonus_count_flag = false;
        //        bonus_point = 0;
        //        bonus_count = 0.0f;
        //        number_of_times = 0;
        //    }
        //}
        //combo_text.text = number_of_times.ToString();
        //if (gimic_coll_flag)
        //{
        //    // サイズカエル処理をします

        //    // gimic_coll_flagをfalseに戻すのは?stateのときかつsizeが1になったら
        //    if(state == 0)
        //    {
        //        //接触したら１から0.5まで値を減らす
        //        Vector2 scale = transform.localScale;
        //        scale.x -= 0.1f;
        //        transform.localScale = scale;
        //        if(scale.x <= 0.5f)
        //        {
        //            scale.x = 0.5f;
        //            state = 1;
        //        }
        //    }

        //    if(state == 1)
        //    {
        //        //サイスを0.5から１に値を増やす
        //        Vector2 scale = transform.localScale;
        //        scale.x += 0.1f;
        //        transform.localScale = scale;
        //        if (scale.x >= 1.0f)
        //        {
        //            state = 0;
        //            scale.x = 1.0f;
        //            gimic_coll_flag = false;
        //        }
        //    }

        //}
    }

    //public void PlayerSizeChange(float offset)
    //{
    //    float sizeX = (GetComponent<Rigidbody2D>().velocity.magnitude) / 20.0f/*(113)*/;
    //    if (sizeX <= 0.5f)
    //    {
    //        sizeX = 0.5f;
    //    }
    //    if (sizeX >= 1.0f)
    //    {
    //        sizeX = 1.0f;
    //    }
    //    sizeX = sizeX + offset;
    //    transform.localScale = new Vector2(sizeX, transform.localScale.y);
    //    if (sizeX >= 1.0f)
    //    {
    //        sizeX = 1.0f;
    //        gimic_coll_flag = false;
    //    }
    //}

    void damp_()
    {
        Vector2 temp = GetComponent<Rigidbody2D>().velocity;
        if (temp.x > VELOCITY_MAX)
        {
            temp.x = VELOCITY_MAX;
        }
        if (temp.x < -VELOCITY_MAX)
        {
            temp.x = -VELOCITY_MAX;
        }
        if (temp.y > VELOCITY_MAX)
        {
            temp.y = VELOCITY_MAX;
        }
        if (temp.y < -VELOCITY_MAX)
        {
            temp.y = -VELOCITY_MAX;
        }
        GetComponent<Rigidbody2D>().velocity = temp;
    }

    void OnCollisionEnter2D(Collision2D coll) 
    {
        if (coll.gameObject.tag == "Gimic")
        {
            gimic_coll_flag = true;

            if (item_count == 0)
            {
                GetComponent<Sound_Manager>().Obstance_SE();

            }
            if(item_count >= 1)
            {
                Debug.Log("uiguegugueguf");
                GetComponent<Sound_Manager>().Obstance_SE();
            }

            //if (GetComponent<>()
            //{

            //}

            //else if (GetComponent<Break_obj>().count >= 1)
            //{
            //   
            //}
            
            hit_coordinate = coll.transform.position;
          
            GameObject[] seed;
            seed = GameObject.FindGameObjectsWithTag("BlockPiece");
            coll_name = coll.gameObject.name;
            foreach (GameObject obs in seed)
            {
                obs.GetComponent<Effect_Move>().move_flag = true;
            }

        }

        if (coll.gameObject.tag == "Blue_Block")
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 30.0f)
            {
                GetComponent<Sound_Manager>().Obstance_SE();

            }
            else if (GetComponent<Rigidbody2D>().velocity.magnitude >= 30.0f)
            {
                GetComponent<Sound_Manager>().SE();

            }
        }
      

        if (coll.gameObject.tag == "Small_Block")
        {
            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 30.0f)
            {
                GetComponent<Sound_Manager>().Obstance_SE();

            }
            else if (GetComponent<Rigidbody2D>().velocity.magnitude >= 30.0f)
            {
                GetComponent<Sound_Manager>().SE();

            }
        }


        if (coll.gameObject.tag == "Obstance")
        {
            GetComponent<Sound_Manager>().Obstance_SE();
        }

        if (coll.gameObject.tag == "Big_Block")
        {
            if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 0　
                && GetComponent<Rigidbody2D>().velocity.magnitude < 100.0f)
            {
                GetComponent<Sound_Manager>().Obstance_SE();
            }
            else if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 0
                && GetComponent<Rigidbody2D>().velocity.magnitude >= 100.0f)
            {
                GetComponent<Sound_Manager>().Damage_SE();
            }

            if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 1 && GetComponent<Rigidbody2D>().velocity.magnitude > 100.0f)
            {
                GetComponent<Sound_Manager>().Damage_SE();
            }
            else if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 1 && GetComponent<Rigidbody2D>().velocity.magnitude <= 100.0f)
            {
                GetComponent<Sound_Manager>().Obstance_SE();
            }

            if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 2 &&
                    GetComponent<Rigidbody2D>().velocity.magnitude > 100.0f)
            {
                GetComponent<Sound_Manager>().SE();
            }
                   
                
            
        }

        //光の種が出ない赤ブロック用
        if (coll.gameObject.tag == "No_Seed_Block")
        {
            if (coll.gameObject.GetComponent<No_Seed_Hit>().break_count == 0)
            {
                GetComponent<Sound_Manager>().Obstance_SE();
            }
            if (coll.gameObject.GetComponent<No_Seed_Hit>().break_count == 1)
            {
                GetComponent<Sound_Manager>().Damage_SE();
            }
            if (coll.gameObject.GetComponent<No_Seed_Hit>().break_count == 2)
            {
                GetComponent<Sound_Manager>().SE();
            }
        }

        //光の種が出ない緑ブロック用

        if (coll.gameObject.tag == "No_Seed_Green_Block")
        {

            if (GetComponent<Rigidbody2D>().velocity.magnitude <= 30.0f)
            {
                GetComponent<Sound_Manager>().Obstance_SE();

            }
            else if (GetComponent<Rigidbody2D>().velocity.magnitude >= 30.0f)
            {
                GetComponent<Sound_Manager>().SE();
            }
        }




        if (coll.gameObject.tag == "wall_sound")
        {
            GetComponent<Sound_Manager>().Obstance_SE();
        }
      
        
            
            
        

        //if(coll.gameObject.tag == "BlockPiece")
        //{
        //    GameObject harumafuji = Instantiate(light_prefab, transform.position, Quaternion.identity);
        //    Destroy(harumafuji, 3.0f);
        //}
       

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        //if (coll.gameObject.tag == "Bonus")
        //{
        //    bonus_count_flag = true;

        //    GetComponent<Sound_Manager>().Block_Second_SE();
            
        //}
        //if (coll.gameObject.tag == "Goal") 
        //{
        //    if (goal.GetComponent<SpriteRenderer>().color.a >= 1)
        //    {
        //        Debug.Log("ごーーる");
        //        Pauser.Resume();
        //        SceneManager.LoadScene("StageSelect_Scene");
        //    }
        //}
        if (coll.gameObject.tag == "Small_Block")
        {
            GetComponent<Sound_Manager>().SE();
        }
        if (coll.gameObject.tag == "Big_Block")
        {
            if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 1)
            {
                //GetComponent<Sound_Manager>().SE();
            }
            if (coll.gameObject.GetComponent<hit_multiple_times>().break_count == 2)
            {
                //GetComponent<Sound_Manager>().Block_Second_SE();
            }
        }

       
      
        
    }
}
