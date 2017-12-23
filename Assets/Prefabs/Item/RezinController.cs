using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RezinController : MonoBehaviour
{
    public int state_ = 0;
    private float time = 0f;
    //GameObject wall;
    private float ax = 1.0f;
    private float x = 0.0f;
    private float y = 0.0f;
    private float moving_distance = 0.0f;
    private int move_state_x = 0;
    private int move_state_y = 0;
    public bool gimic_ax = false;
    private bool once_frag = false;
    public float ex_ax = 1.0f;

    //private float moving_distance = 0.0f;


    // Use this for initialization
    void Start ()
    {
        //this.wall = GameObject.Find("Wall");
       
	}
	
	// Update is called once per frame
	void Update ()
    {
        RezinMove();
    }


    void RezinMove()
    {
        time += Time.deltaTime;
        Vector2 pos = transform.position;

        //下移動
        if (state_ == 0)
        {
            //一定の距離を移動したら速く移動する
            if(move_state_y == 0)
            {
                pos.y -= 0.03f;
                moving_distance -= 0.03f;
                if(moving_distance < -5.0f)
                {
                    move_state_y = 1;
                }
            }

            //速く移動
            if(move_state_y == 1)
            {
                pos.y -= 0.09f;
                moving_distance -= 0.09f;
            }
            transform.position = pos;
        }

        //右移動
        else if (state_ == 1)
        {
            //一定の距離を移動したら速く移動する
            if(move_state_x == 0)
            {
                pos.x += 0.03f;
                moving_distance += 0.03f;
                if(moving_distance > 5.0f)
                {
                    move_state_x = 1;
                }
            }

            //速く移動
            if (move_state_x == 1)
            {
                pos.x += 0.09f;
                moving_distance += 0.09f;
            }
            transform.position = pos;
        }

        //円移動
        else if (state_ == 2)
        {
            var x = 5 * Mathf.Sin(time);
            var y = 5 * Mathf.Cos(time);
            transform.position = new Vector2(x, y);
        }

        //左移動
        else if (state_ == 3)
        {
            transform.Translate(-0.03f * ax * ex_ax, 0.0f, 0.0f);
        }

        //上移動
        else if (state_ == 4)
        {
            transform.Translate(0.0f, 0.03f * ax * ex_ax, 0.0f);
        }

        if (gimic_ax == true)
        {
            if (once_frag == false)
            {
                ex_ax = 4.0f;
                once_frag = true;
            }
            ex_ax -= 0.05f;
            if (ex_ax < 0.5f)
            {
                ex_ax = 0.5f;
                gimic_ax = false;
            }
        }
    }

    //壁との当たり判定
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if (collision.gameObject.tag == "Wall")
        //{
        //    ax *= -1.0f;
        //} 
    }
}
