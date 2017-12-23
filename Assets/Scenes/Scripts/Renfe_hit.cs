using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Renfe_hit : MonoBehaviour
{
    public List<GameObject> obj = new List<GameObject>();
    private int coll_count = 0;
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.gameObject.tag == "Gimic")
        {
            obj.Add(trigger.gameObject);
            //obj[coll_count] = trigger.gameObject;
            //coll_count += 1;
        }
    }
}
