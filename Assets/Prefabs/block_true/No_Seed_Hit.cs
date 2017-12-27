using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class No_Seed_Hit : MonoBehaviour
{
    public int number = 0;
    public int break_count = 0;
    public Sprite[] block_sprite = new Sprite[2];
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
        //Debug.Log(GetComponent<Rigidbody2D>().velocity.magnitude);
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {   //タグプレイヤーよび　プレイヤーオブジェみつけ　速度○○以上のとき
        if (coll.gameObject.tag == "Player" && GameObject.Find("Player").
            GetComponent<Rigidbody2D>().velocity.magnitude >= 103)
        {
            number += 1;
            //Debug.Log("aioooooooooooooooooooooooooo");
            break_count += 1;
            Debug.Log("ブレイクカウント" + break_count);

            if (number == 2)
            {
                number = 0;
            }
            //プレイヤーと２回当たったらオブジェクトを破棄する
            if (break_count == 2)
            {
                Destroy(gameObject);
                //GameObject.Find("Player").GetComponent<Player_Collision>().item_count += 1;
                GameObject.Find("Player").GetComponent<Player_Collision>().item_text.text =
                    GameObject.Find("Player").GetComponent<Player_Collision>().item_count.ToString();
            }

            //オブジェクトが破棄されたらエフェクトを発生させてランタンに光を灯す
            obj = Instantiate(stardust_prefab, transform.position, Quaternion.identity);
            Instantiate(dust_prefab, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().sprite = block_sprite[number];
        }
        if (coll.gameObject.tag == "Player")
        {
            if (break_count == 0
                && coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 100.0f)
            {
                coll.gameObject.GetComponent<Sound_Manager>().Obstance_SE();
            }

            else if (break_count == 1
                && coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 100.0f)
            {
                coll.gameObject.GetComponent<Sound_Manager>().Damage_SE();
            }

            else if (break_count == 1
                && coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude < 100.0f)
            {
                coll.gameObject.GetComponent<Sound_Manager>().Obstance_SE();
            }

            else if (break_count == 2
                && coll.gameObject.GetComponent<Rigidbody2D>().velocity.magnitude >= 100.0f)
            {
                coll.gameObject.GetComponent<Sound_Manager>().SE();
            }
        }

    }
    public void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player" && GameObject.Find("Main Camera").
            GetComponent<MainCameraScr>().sub.magnitude > 15)
        {
            number += 1;
            break_count += 1;
        }

        else if (coll.gameObject.tag == "Player" && GameObject.Find("Player").
            GetComponent<Rigidbody2D>().velocity.magnitude < 20)

            {
            gameObject.GetComponent<SpriteRenderer>().sprite = block_sprite[number];

                return;
            }

    }
}
