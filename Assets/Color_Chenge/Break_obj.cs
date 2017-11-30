using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_obj : MonoBehaviour
{
    //private bool crash_count_flag = false;
    //破壊されるカウント
    public int count = 0;
    public GameObject stardust_prefab;
    public GameObject dust_prefab;
    private GameObject obj;
   

    // Use this for initialization
    void Start()
    {
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
            //射出後のスピード○○のときは性質変化　弱に変化（赤オブジェ壊せずに跳ね返る）
            if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 20)
            {
                //何もしない
                return;
            }

            count += 1;
            obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
            Instantiate(dust_prefab, transform.position, Quaternion.identity);
            //crash_count_flag = true;
            if (count == 1)
            {
                Destroy(gameObject);
            }
            
            

        }
    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {   //パワーが○○以下のとき破壊される

            if (GameObject.Find("Main Camera").GetComponent<MainCameraScr>().sub.magnitude > 15)
            {
                //GameObject.Find("Block/block_red (2)").GetComponent<BoxCollider>().isTrigger 
                
                count += 1;
                obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
                Instantiate(dust_prefab, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
           
        }

    }

}

