using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Light_Move : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        //プレイヤーに光のエフェクトを追従させる
        transform.position = GameObject.Find("Player").transform.position;
    }
}
