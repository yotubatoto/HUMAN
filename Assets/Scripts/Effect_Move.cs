using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Effect_Move : MonoBehaviour
{
    private float speed = 50.0f;
    private float rotationSmooth = 2f;

    private GameObject Gimic;
    public bool move_flag = false;
    private bool once_flag = false;
    Quaternion targetRotation;
    Vector2 vel = Vector2.zero;
    Vector2 unko1 = Vector2.zero;
    string coll_name;
    float ax = 1.0f;
    // Use this for initialization
    void Start()
    {
        // 始めにギミックの位置を取得できるようにする
        Gimic = GameObject.FindWithTag("Gimic");
    }

    // Update is called once per frame
    void Update()
    {
        //Debug.Log(move_flag);
        if (move_flag == true)
        {
            if (once_flag == false)
            {
                once_flag = true;
                // プレイヤーがランタンに当たったらseedがランタンのほうを向く
                unko1 = GameObject.Find("Player").GetComponent<Player_Collision>().hit_coordinate;
                Vector2 unko2 = transform.position;
                vel = unko1 - unko2;
                //unko1.z = unko2.z;
                coll_name = GameObject.Find("Player").GetComponent<Player_Collision>().coll_name;
                //targetRotation = Quaternion.LookRotation(unko1 - unko2);
            }

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSmooth);

            // 前方に進む
            transform.Translate(((vel.normalized * speed) * ax) * Time.deltaTime);
            ax += (0.2f * Time.deltaTime);
        }


    }

    //private void OnParticleCollision(GameObject other)
    //{
    //    if (other.gameObject.tag == "Player")
    //    {
    //        Destroy(gameObject);
    //        Debug.Log("死にました");
    //    }
    //}

    //ランタンと当たったらオブジェクトを破棄する
    //private void OnCollisionEnter2D(Collision2D coll)
    //{
    //    if (coll.gameObject.tag == "Gimic")
    //    {
    //        //Instantiate(light, transform.position, Quaternion.identity);
    //        //if(time > life_time)
    //        //{
    //        //    Destroy(gameObject);
    //        //}

    //        Destroy(gameObject);
    //        Debug.Log("死にました");
    //    }
    //}

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Gimic")
        {

            if (move_flag && coll_name == collision.gameObject.name)
            {
                Destroy(gameObject);
                collision.gameObject.GetComponent<Wall_Gimic>().chenge_number += 1;
            }
            //Instantiate(light, transform.position, Quaternion.identity);
            //if(time > life_time)
            //{
            //    Destroy(gameObject);
            //}

            //Destroy(gameObject);

        }
    }
   
}


