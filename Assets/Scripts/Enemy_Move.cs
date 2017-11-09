using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int state = 0;
    public float MAX_SPEED_X = -0.05f;
    public float MAX_SPEED_Y = -0.05f;
 


	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(state == 0)
        {
                transform.Translate(MAX_SPEED_X, 0.0f, 0.0f);

        }
        else if(state == 1)
        {
            transform.Translate(0.0f, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 2)
        {
            transform.Translate(0.0f, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 3)
        {
            transform.Translate(MAX_SPEED_X, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 4)
        {
            transform.Translate(MAX_SPEED_X, -MAX_SPEED_Y, 0.0f);
        }
	}
}
