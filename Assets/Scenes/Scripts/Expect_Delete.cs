using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Expect_Delete : MonoBehaviour {
    public float delete_time = 1.0f;
    private float time = 0;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        time += Time.deltaTime;
        if (time > delete_time)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
        }
	}
}
