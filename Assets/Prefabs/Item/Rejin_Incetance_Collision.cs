using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejin_Incetance_Collision : MonoBehaviour {
    public bool coll_flag = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		
	}
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll_flag = true;
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            coll_flag = false;
        }
    }
}
