using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child_Coll : MonoBehaviour {
    public bool flag = false;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            if(Camera.main.GetComponent<MainCameraScr>().sub.magnitude > 10)
            {
                flag = true;
            }
        }
    }
    void OnTriggerExit2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            flag = false;
           transform.parent.gameObject.GetComponent<BoxCollider2D>().isTrigger = false;

        }
    }
}
