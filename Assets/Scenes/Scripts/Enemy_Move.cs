using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Move : MonoBehaviour
{
    public int state = -1;
    public float MAX_SPEED_X = -0.05f;
    public float MAX_SPEED_Y = -0.05f;
    bool m_xPlus = true;
    private bool m_yPlus = true;
    private Manager manager;



    // Use this for initialization
    void Start ()
    {
        manager = GameObject.Find("Main Camera").GetComponent<Manager>();
      
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (manager.move_flag)
            return;
        
		if(state == 0)
        {
                transform.Translate(MAX_SPEED_X, 0.0f, 0.0f);

        }
        else if(state == 1)
        {
            transform.Translate(0.0f, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 2)
        {
            transform.Translate(0.0f, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 3)
        {
            transform.Translate(MAX_SPEED_X, MAX_SPEED_Y, 0.0f);
        }
        else if(state == 4)
        {
            if (m_yPlus)
            {
                transform.position += new Vector3(0.0f, MAX_SPEED_Y, 0.0f);
                    if (transform.position.y >= 20)
                    m_yPlus = false;
            }
            else
            {
                transform.position -= new Vector3(0.0f, MAX_SPEED_Y, 0.0f);
                if (transform.position.y <= -22)
                    m_yPlus = true;
            }
        }
        else if(state == 5)
        {
            if (m_xPlus)
            {
                transform.position += new Vector3(MAX_SPEED_X, 0f, 0f);
                if (transform.position.x >= 38)
                    m_xPlus = false;
            }
            else
            {
                transform.position -= new Vector3(MAX_SPEED_X, 0f, 0f);
                if (transform.position.x <= -40)
                    m_xPlus = true;
            }
        }
      
    }
}
