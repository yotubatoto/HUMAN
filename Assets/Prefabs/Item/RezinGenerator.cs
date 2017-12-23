using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RezinGenerator : MonoBehaviour
{
    public GameObject RezinPrefab;
    public float span = 0f;
    private float x = 0.0f;
    private float y = 0.0f;
    public float time = 0f;
    public Vector2[] coordinate = new Vector2[12];
    public List<GameObject> coordinate_obj = new List<GameObject>();
    private int rezin_state = 0;
    private int next_state_ = 1;

    // Use this for initialization
    void Start ()
    {
        for(int i = 0; i < 12; i++)
        {
            coordinate[i] = coordinate_obj[i].transform.position;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        Execute();
    }

    void Execute()
    {
        //第１陣レジン出現
        if (rezin_state == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                RezinFrom(i, 0);
            }
            rezin_state = 10;
            next_state_ = 1;
        }

        if (rezin_state == 10)
        {
            StateBuffer(6, next_state_);
        }

        //第２陣レジン出現
        if (rezin_state == 1)
        {
            for (int i = 3; i < 6; i++)
            {
                RezinFrom(i, 1);
            }
            rezin_state = 10;
            next_state_ = 2;
        }

        //第3陣レジン出現
        if (rezin_state == 2)
        {
            for (int i = 6; i < 9; i++)
            {
                RezinFrom(i, 3);
            }
            rezin_state = 10;
            next_state_ = 3;
        }

        //第４陣レジン出現
        if (rezin_state == 3)
        {
            for (int i = 9; i < 12; i++)
            {
                RezinFrom(i,4);
            }
            rezin_state = 10;
            next_state_ = 0;
        }
    }

    //レジンを生成する関数
    void RezinFrom(int i,int resin_move_state)
    {
        GameObject obj_1 = Instantiate(RezinPrefab, coordinate[i], Quaternion.identity) as GameObject;
        obj_1.GetComponent<RezinController>().state_ = resin_move_state;
    }

    void StateBuffer(float interval_time, int next_state)
    {
        this.time += Time.deltaTime;
        time += Time.deltaTime;
        if (time > interval_time)
        {
            this.time = 0;
            rezin_state = next_state;
        }
    }
}
