using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gimic_Velocity : MonoBehaviour {
    public GameObject player_obj;
    private Vector2 player_vel;

	// Use this for initialization
	void Start () 
    {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
        Debug.Log("fdfe");
	}
    	
	
    void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            player_vel = player_obj.GetComponent<Rigidbody2D>().velocity;
            Debug.Log(player_vel);
        }
    }
}
