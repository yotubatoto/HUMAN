using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstanceController : MonoBehaviour
{
    public int obstance_state = 0;
    //public float MAX_SPEED_X = -0.03f;
    //public float MAX_SPEED_Y = -0.03f;
    public float life_time = 1.5f;
    float time = 0f;
    float x = 0.0f;
    float y = 0.0f;
    private int state = 0;
    private float moving_distance = 0.0f;

	// Use this for initialization
	void Start ()
    {
        time = 0;
	}
	
	// Update is called once per frame
	void Update ()
    {
        ObstanceMove();
	}

    //オブスタンスの動き
    void ObstanceMove()
    {
        time += Time.deltaTime;
        Vector2 pos = transform.position;
        //print(time);

        //横に移動しながた漂う
        if (obstance_state == 0)
        {
            transform.position = new Vector2(Mathf.PingPong(time, 5), transform.position.y);
            if (time > life_time)
            {
                Destroy(gameObject);
            }
        }

        //一番上に到達したら下に速く移動し、一番下に到達したら上にゆっくり移動する
        else if (obstance_state == 1)
        {
            if(state == 0)
            {
                pos.y += 0.03f;
                moving_distance += 0.03f;
                if(moving_distance > 10.0f)
                {
                    state = 1;
                }
            }

            if(state == 1)
            {
                pos.y -= 0.09f;
                moving_distance -= 0.09f;
                if(moving_distance < -6.0f)
                {
                    state = 0;
                }
            }
            transform.position = pos;
        }

        //左端に着いたら右に加速して移動し、右端に着いたら左にゆっくり移動する
        else if(obstance_state == 2)
        {
            if(state == 0)
            {
                pos.x -= 0.03f;
                moving_distance -= 0.03f;
                if(moving_distance < -13.0f)
                {
                    state = 1;
                }
            }

            if(state == 1)
            {
                pos.x += 0.09f;
                moving_distance += 0.09f;
                if(moving_distance > 4.5f)
                {
                    state = 0;
                }
            }
            transform.position = pos;
        }

       
    }
}
