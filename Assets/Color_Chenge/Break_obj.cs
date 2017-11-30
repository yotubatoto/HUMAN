using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Break_obj : MonoBehaviour
{
    //private bool crash_count_flag = false;
    public int count = 0;
    public GameObject stardust_prefab;
    public GameObject dust_prefab;
    private GameObject obj;
    public GameObject seed_prefab;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {

    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);  //オブジェクトが破棄されたらエフェクトを生成
            Instantiate(dust_prefab, transform.position, Quaternion.identity);            //オブジェクトが破棄されたらエフェクトを生成
            //crash_count_flag = true;

            //プレイヤーと当たったらオブジェクトを破棄する
            if (count <= 1)
            {
                Destroy(gameObject);
                //GameObject.Find("Player").GetComponent<Player_Collision>().combo_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text = 
                    GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString(); //オブジェクトが破棄されたらSEEDカウントを表示
                Instantiate(seed_prefab, transform.position, Quaternion.identity);                    //seedprefabを生成
                Debug.Log("生成されました");
                Debug.Log(GameObject.Find("Player").GetComponent<Player_Collision>().item_count);     //seedカウントを追加
               
            }
        }
    }
}
