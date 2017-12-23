using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Switch : MonoBehaviour
{
    public int switch_count = 0;
    public GameObject hit_obj;
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
        if(trigger.gameObject.tag == "Player")
        {
            if(hit_obj.GetComponent<Renfe_hit>().obj != null)
            {
                for (int i = 0; i < hit_obj.GetComponent<Renfe_hit>().obj.Count; i++)
                {
                    hit_obj.GetComponent<Renfe_hit>().obj[i].GetComponent<Wall_Gimic>().number = 1;
                }
            }
        }
    }
}
