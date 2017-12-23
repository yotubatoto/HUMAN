using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resin_Gimic_Controller : MonoBehaviour {
    public GameObject centerObj;
    private Vector3 vec = Vector2.zero;
    private Vector3 normalize = Vector2.zero;
    private float ax = 1.0f;
    private float coliision_time = 0;
    public float max_time = 0;
    public bool gimic_ax = false;
    private bool once_frag = false;
    private float ex_ax = 1.0f;

	// Use this for initialization
	void Start () 
    {
        vec = centerObj.transform.position - transform.position;
        normalize = vec.normalized;
	}
	
	// Update is called once per frame
	void Update () 
    {
        //transform.position += (normalize / 20);
        coliision_time += Time.deltaTime;
        transform.Translate((normalize / 20) * ax * ex_ax);

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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            ax *= -1.0f;
        } 
    }

    void OnTriggerStay2D(Collider2D coll)
    {
        if (coliision_time > max_time)
        {
            if (coll.gameObject.tag == "Player")
            {
                Destroy(gameObject);
            }
        }
    }
}
