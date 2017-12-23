using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Circle_break : MonoBehaviour
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

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
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
}
