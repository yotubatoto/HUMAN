using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    public GameObject SrashEnemyPrefab;
    public List<GameObject> obj = new List<GameObject>();
    public float revive_time = 0f;
    public float span = 0f;
    //private int state = 0;
    public int enemy_state = 0;
    float delta = 0f;
    public Vector3 pos = Vector3.zero;
    public Vector2[] coordinate = new Vector2[12];
    private bool flag = false;
    public List<GameObject> coodinate_obj = new List<GameObject>();
    private int next_state_ = 1;
    public float form_time = 0.0f;
    // Use this for initialization
    void Start()
    {
        for (int i = 0; i < 7; i++)
        {
            coordinate[i] = coodinate_obj[i].transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Execute();
    }

    void Execute()
    {
        //０～２まで第１陣の出現
        if (enemy_state == 0)
        {
            for (int i = 0; i < 3; i++)
            {
                float temp = 1.0f;
                if (i == 0)
                {
                    temp = 1.0f;
                }
                if (i == 1)
                {
                    temp = 2.0f;
                }
                if (i == 2)
                {
                    temp = 0.5f;
                }
                EnemyForm(i, 0, 100, temp);
            }
            enemy_state = 10;
            next_state_ = 1;
        }

        if (enemy_state == 10)
        {
            StateBuffer(6, next_state_);
        }

        //３～５までが第２陣の出現
        if (enemy_state == 1)
        {
            for (int i = 3; i < 6; i++)
            {
                EnemyForm(i, 3, 100, 3.0f);
            }
            enemy_state = 10;
            next_state_ = 0;
        }

        ////６～８までが第３陣の出現
        //if (enemy_state == 2)
        //{
        //    for (int i = 6; i < 9; i++)
        //    {
        //        EnemyForm(i, 3, 0);
        //    }
        //    enemy_state = 10;
        //    next_state_ = 3;

        //}

        ////９～１１までが第４陣の出現
        //if (enemy_state == 3)
        //{

        //    for (int i = 9; i < 12; i++)
        //    {
        //        EnemyForm(i, 0, 100);
        //    }
        //    enemy_state = 10;
        //    next_state_ = 0;
        //}
    }

    //敵を出現させる関数
    void EnemyForm(int i, float center_x, float center_y, float speed)
    {
        GameObject obj = Instantiate(SrashEnemyPrefab, coordinate[i], Quaternion.identity) as GameObject;
        GameObject temp_1 = obj.transform.Find("CenterPoint").gameObject;
        temp_1.transform.position = new Vector2(center_x, center_y);
        obj.GetComponent<SlasingEnemy>().speed = speed;
    }

    void StateBuffer(float interval_time, int next_state)
    {
        delta += Time.deltaTime;
        if (delta > interval_time)
        {
            this.delta = 0;
            enemy_state = next_state;
        }
    }
}
