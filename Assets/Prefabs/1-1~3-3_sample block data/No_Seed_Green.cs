using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_Seed_Green : MonoBehaviour
{
    public int count = 0;
    public GameObject stardust_prefab;
    public GameObject dust_prefab;
    private GameObject obj;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
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
                Debug.Log("きてる");
                return;
            }

            count += 1;
            obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
            Instantiate(dust_prefab, transform.position, Quaternion.identity);
            //crash_count_flag = true;

            //プレイヤーと当たったらオブジェクトを破棄する
            if (count <= 1)
            {
                Destroy(gameObject);
                //GameObject.Find("Player").GetComponent<Player_Collision>().combo_count += 1;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text =
                    GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString(); //オブジェクトが破棄されたらSEEDカウントを表示
                Debug.Log("生成されました");
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);     //seedカウントを追加

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
                //GameObject.Find("Block/block_red (2)").GetComponent<BoxCollider>().isTrigger 

                count += 1;
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text =
                GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString(); //オブジェクトが破棄されたらSEEDカウントを表示
                //Debug.Log("生成されました");
                //Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);     //seedカウントを追加
                obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
                Instantiate(dust_prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }

        }

    }

}
