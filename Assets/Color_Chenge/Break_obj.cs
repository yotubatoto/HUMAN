using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Break_obj : MonoBehaviour
{
    //private bool crash_count_flag = false;
    //破壊されるカウント
    public int count = 0;
    public GameObject stardust_prefab;
    public GameObject dust_prefab;
    private GameObject obj;


    public GameObject seed_prefab;
    //光の種の生存ターン
    public int seed_life_turn = 0;
    private GameObject seed_life;

    // Use this for initialization
    void Start()
    {
        seed_life = null;

    }

    // Update is called once per frame
    void Update()
    {


    }

    public void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            //Debug.Log(Camera.main.GetComponent<MainCameraScr>().sub.magnitude);
            //射出後のスピード○○のときは性質変化　弱に変化(青)（赤オブジェ壊せずに跳ね返る）
            //if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 20)
            //{
            //    //何もしない
            //    return;
            //}
            if (GameObject.Find("Main Camera").GetComponent<MainCameraScr>().characteristic_change_state == 1 ||
                GameObject.Find("Main Camera").GetComponent<MainCameraScr>().characteristic_change_state == 0)
            {
                //何もしない
                //Debug.Log("きてる");
                return;
            }

            count += 1;



            //if (coll.gameObject.tag == "Player")
            //{
            //    if (coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 30.0f)
            //    {
            //        coll.gameObject.GetComponent<Sound_Manager>().Obstance_SE();
            //    }

            //    else if (coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 100.0f)
            //    {
            //        coll.gameObject.GetComponent<Sound_Manager>().SE();
            //    }


            //}
           
            obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
            Instantiate(dust_prefab, transform.position, Quaternion.identity);
            //crash_count_flag = true;
         

            //プレイヤーと当たったらオブジェクトを破棄する
            if (count <= 1)
            {
                Destroy(gameObject);
                
                //GameObject.Find("Player").GetComponent<Player_Collision>().combo_count += 1;

                GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                //Debug.Log(GetComponent<Player_Collision>().item_count);
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text = 
                    GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString(); //オブジェクトが破棄されたらSEEDカウントを表示
                seed_life = Instantiate(seed_prefab, transform.position, Quaternion.identity);




             

                //seedprefabを生成
                //Debug.Log("生成されました");
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);     //seedカウントを追加
               
            }

            //if (seed_life != null)
            //{
            //    Instantiate(seed_prefab.transform.position,Quaternion.identity)
            //}

            if (seed_life_turn <= 0 && seed_life != null)
            {

                seed_life_turn += 1;
                if (seed_life_turn >= 3)
                {
                    Destroy(seed_life);
                    seed_life = null;

                }

            }
            
            

        }

    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {   //パワーが○○以下のとき破壊される
            // if (GameObject.Find("Main Camera").GetComponent<MainCameraScr>().sub.magnitude > 15)
            if (GameObject.Find("Main Camera").GetComponent<MainCameraScr>().characteristic_change_state >= 2)
            {
                

                    // if (coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 100.0f)
                    //{
                    //    coll.gameObject.GetComponent<Sound_Manager>().SE();
                    //}


                

                //GameObject.Find("Block/block_red (2)").GetComponent<BoxCollider>().isTrigger 
                
                count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text =
                GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString(); //オブジェクトが破棄されたらSEEDカウントを表示
                Instantiate(seed_prefab, transform.position, Quaternion.identity);

               






                //seedprefabを生成
                //Debug.Log("生成されました");
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);     //seedカウントを追加
                obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
                Instantiate(dust_prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
           
        }

    }

}

