using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejin_Gimic_Manager : MonoBehaviour
{
    private GameObject[] rejin_instance = new GameObject[2];
    public GameObject obj = null;
    private GameObject[] child_obj = new GameObject[4];
    public GameObject player_obj;
    public float player_vel = 0.0f;
    public int gimic_explosion_count = 0;
    public GameObject time_countup_obj; 
   
    // Use this for initialization
    void Start()
    {
        child_obj[0] = transform.Find("UP").gameObject;
        child_obj[1] = transform.Find("RIGHT").gameObject;
        child_obj[2] = transform.Find("DOWN").gameObject;
        child_obj[3] = transform.Find("LEFT").gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {

            if (player_vel > 5)
            {

                gimic_explosion_count += 1;
                if (gimic_explosion_count == 4)
                {
                    //iを1増やすので右に１ずれて生成される
                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(0, 30, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(30, 0, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(0, -30, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-30, 0, 0);

                    // 斜め
                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(15, 15, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(15, -15, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-15, -15, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-15, 15, 0);

                    // 斜め
                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(15, 30, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(15, -30, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-15, -30, 0);

                    rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                    rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-15, 30, 0);
                    Instantiate(time_countup_obj, gameObject.transform.position, Quaternion.identity);
                    Destroy(gameObject);

                }
                else
                {
                    if (child_obj[0].GetComponent<Rejin_Incetance_Collision>().coll_flag == true)
                    {
                        rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                        rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(0, -90, 0);

                    }

                    else if (child_obj[1].GetComponent<Rejin_Incetance_Collision>().coll_flag == true)
                    {
                        rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                        rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(-90, 0, 0);

                    }
                    else if (child_obj[2].GetComponent<Rejin_Incetance_Collision>().coll_flag == true)
                    {
                        rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                        rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(0, 90, 0);

                    }
                    else if (child_obj[3].GetComponent<Rejin_Incetance_Collision>().coll_flag == true)
                    {
                        rejin_instance[0] = Instantiate(obj, new Vector2(gameObject.transform.position.x, gameObject.transform.position.y), Quaternion.identity);
                        rejin_instance[0].transform.Find("Center_Point").transform.position = new Vector3(90, 0, 0);
                    }
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            player_vel = player_obj.GetComponent<Rigidbody2D>().velocity.magnitude;
            //Debug.Log(player_vel);
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            player_vel = 0.0f;
        }
    }

    

}