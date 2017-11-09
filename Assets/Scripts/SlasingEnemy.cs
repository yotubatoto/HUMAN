using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlasingEnemy : MonoBehaviour
{
    //public float Vector2 = v.normalize;
    public GameObject centerObj;
    private Vector2 vec = Vector2.zero;
    private Vector2 normalize = Vector2.zero;
    public float enemy_life_time = 1.5f;
    float time = 0f;
    public float speed = 1.0f;


    // Use this for initialization
    void Start()
    {
        vec = centerObj.transform.position - transform.position;
        normalize = vec.normalized;
        time = 0;
    }

    // Update is called once per frame
    void Update()
    {
        this.time += Time.deltaTime;
        transform.position += ((Vector3)normalize / 20 * speed);

        //時間経過で敵を破棄する
        if (this.time > enemy_life_time)
        {
            Destroy(gameObject);
        }

    }
}
