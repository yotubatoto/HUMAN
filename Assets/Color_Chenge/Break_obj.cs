using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Break_obj : MonoBehaviour
{
    //private bool crash_count_flag = false;
    public int count = 0;
    public GameObject explosionprefab;
    private GameObject obj;

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
            count += 1;
            obj = Instantiate(explosionprefab, transform.position, Quaternion.identity);
            //crash_count_flag = true;
            if (count == 1)
            {
                Destroy(gameObject);
            }
        }
    }
}
