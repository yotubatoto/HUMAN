using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Stage_Controller: MonoBehaviour {
    public float speed = 2;
    GameObject mainCamera;
    Vector2 vec;
    public float choice_speed;
    public GameObject choice_right;
    public GameObject choice_left;
    //public float choice_shake = 0.0f;

    //スクロールカメラ
    public float camera_scr;
    public int camera_move_state = 1;
    private int choice_state = 0;


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


            Chioce_Shake_Right();
            Choice_Shake_Left();

                //camera_scr -= 7.0f* Time.deltaTime;
                //if (camera_scr <= -13.5f)
                //{
                //    camera_scr = -13.5f;
                //    //camera_move_state = 2;
                //}
                //transform.position = new Vector3(0.0f, camera_scr, -10.0f);
                camera_move_state = 2;
            
          
        }
        if (camera_move_state == 2)
        {
          
           
                //camera_scr += 7.0f * Time.deltaTime;
                //if (camera_scr >= 0)
                //{
                //    camera_scr = 0;
                //    //camera_move_state = 2;
                //    camera_move_state = 0;
                //}
                //transform.position = new Vector3(0.0f, camera_scr, -10.0f);
                camera_move_state = 1;

            
        }
           
	}
    //ステセレ矢印動かす
    void Chioce_Shake_Right()
    {
        //アタッチしてなければ実行しない
        if (choice_right == null)
        {
            return;
        }
        Vector2 pos = choice_right.transform.position;
       
        //右に動かす
        if (choice_state == 0)
        {
            choice_speed += 50.0f *Time.deltaTime;
            pos.x += 1.0f * Time.deltaTime;
            //距離
            if (choice_speed > 25)
            {
                choice_state = 1;
                choice_speed = 0;
            }
        }
        //左に動かす
        else if (choice_state == 1)
        {
            choice_speed -= 50.0f * Time.deltaTime;
            pos.x -= 1.0f * Time.deltaTime;
            if (choice_speed < -25)
            {
                choice_state = 0;
                choice_speed = 0;
            }

        }
        choice_right.transform.position = pos;
      
    }
    void Choice_Shake_Left()
    {
        //アタッチしてなければ実行しない
        if (choice_left == null)
        {
            return;
        }
        Vector2 pos = choice_left.transform.position;
        //左に動かす
        if (choice_state == 0)
        {
            choice_speed -= 50.0f * Time.deltaTime;
            pos.x -= 1.0f * Time.deltaTime;
            //矢印距離
            if (choice_speed < -25)
            {
                choice_state = 1;
                choice_speed = 0;
            }
        }
        //右に動かす
        else if (choice_state == 1)
        {
            choice_speed += 50.0f * Time.deltaTime;
            pos.x += 1.0f * Time.deltaTime;
            if (choice_speed > 25)
            {
                choice_state = 0;
                choice_speed = 0;
            }

        }
        choice_left.transform.position = pos;
    }

       
}
