using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stage_Controller: MonoBehaviour {
    public float speed = 2;
    GameObject mainCamera;
    Vector2 vec;
    //スクロールカメラ
    public float camera_scr;
    public int camera_move_state = 0;


	// Use this for initialization
	void Start () 
    {
        mainCamera = GameObject.Find("Main Camera");		
	}
	
	// Update is called once per frame
	void Update () 
    {   
        //　移動処理 
        if (camera_move_state == 1)
        {
            camera_scr -= 7.0f* Time.deltaTime;
            if (camera_scr <= -13.5f)
            {
                camera_scr = -13.5f;
                //camera_move_state = 2;
            }
            transform.position = new Vector3(0.0f, camera_scr, -10.0f);
          
        }
        if (camera_move_state == 2)
        {
            camera_scr += 7.0f * Time.deltaTime;
            if (camera_scr >= 0)
            {
                camera_scr = 0;
                //camera_move_state = 2;
                camera_move_state = 0;
            }
            transform.position = new Vector3(0.0f, camera_scr, -10.0f);
           
        }
	}
}
