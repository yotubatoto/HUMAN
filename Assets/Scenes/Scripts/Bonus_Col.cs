﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bonus_Col : MonoBehaviour
{

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnTriggerEnter2D(Collider2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            Destroy(gameObject);

            coll.GetComponent<Sound_Manager>().Gimic_SE();
        }
        
    }
   
}
