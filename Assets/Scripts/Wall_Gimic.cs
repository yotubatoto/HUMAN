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


    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.localScale = new Vector3(100, 100, 1.0f);

        if (size_state == 1)
        {
            s_plus += zoom_speed;
            transform.localScale = new Vector3(s_plus + 2, s_plus + 2, 0.0f);
            if((s_plus +2) > 3)
            {
                size_state = 2;
                s_plus = 2;
            }
        }

        else if(size_state == 2)
        {
            s_plus -= zoom_speed;
            transform.localScale = new Vector3(s_plus + 2, s_plus + 2, 0.0f);
            if((s_plus + 2) < 2)
            {
                size_state = 0;
                s_plus = 0;
            }
        }

        if(chage_state == 1)
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

        }

        

    }
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (size_state == 0)
        {
            if (coll.gameObject.tag == "Player")
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = light_sprite[1];
                size_state = 1;
                if(chage_state == 0)
                {
                    Debug.Log("aaa");
                    obj = Instantiate(chageprefab, transform.position, Quaternion.identity);
                    chage_state = 1;
                }
            }
        }

    }
}
