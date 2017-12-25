using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Ending_Manager : MonoBehaviour
{
    private float count = 0;
    public float MAX_TIME = 5;
    public Image now_loading;
    public Image now_loading_back;
    private int state = 0;
    public Image tap;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        count += Time.deltaTime;
        if(count > MAX_TIME)
        {
            TouchInfo info = AppUtil.GetTouch();
            if(info == TouchInfo.Ended)
            {
                GetComponent<Now_Loading>().Load_NextScene_First();
                now_loading.enabled = true;
                now_loading_back.enabled = true;
            }
            tap.enabled = true;
        }
        if (now_loading_back.enabled)
        {
            state = _Utility.Flashing(now_loading, 1.5f, state);
        }
        if(tap.enabled)
        {
            Color c = tap.color;
            c.a += 0.1f;
            if(c.a >= 1)
            {
                c.a = 1.0f;
            }
            tap.color = c;
        }
		
	}
}
