using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Time_Item_Coliision : MonoBehaviour {
    private float coliision_time = 0;
    //無敵時間の長さ
    public float max_time = 0;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        coliision_time += Time.deltaTime;
	}
    //void OnTriggerEnter2D(Collider2D coll)
    //{
    //    if (coliision_time > max_time)
    //    {
    //        if (coll.gameObject.tag == "Player")
    //        {
    //            Destroy(gameObject);
    //        }
    //    }
    //}

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coliision_time > max_time)
        {
            if (coll.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
