using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    private float life_time = 0.0f;
    public float MAX_TIME = 0.0f;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        life_time += Time.deltaTime;
		if(life_time > MAX_TIME)
        {
            Destroy(gameObject);
        }
	}
}
