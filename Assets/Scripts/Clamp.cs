using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clamp : MonoBehaviour {
    public float VELOCITY_MAX = 80.0f;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //Vector2 temp = GetComponent<Rigidbody2D>().velocity;
        //if (temp.x > VELOCITY_MAX)
        //{
        //    temp.x = VELOCITY_MAX;
        //}
        //if (temp.x < -VELOCITY_MAX)
        //{
        //    temp.x = -VELOCITY_MAX;
        //}
        //if (temp.y > VELOCITY_MAX)
        //{
        //    temp.y = VELOCITY_MAX;
        //}
        //if (temp.y < -VELOCITY_MAX)
        //{
        //    temp.y = -VELOCITY_MAX;
        //}
        //GetComponent<Rigidbody2D>().velocity = temp;
    }
}
