using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Debug__ : MonoBehaviour 
{
	private float value = 0.0f;
	MainCameraScr m_c_s;
	[SerializeField]
	private float CHANGE = 1000.0f;
	[SerializeField]
	private Text text;
	// Use this for initialization
	void Start ()
	{
		m_c_s = Camera.main.GetComponent<MainCameraScr>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (this.name == "Number")
		{
			text.text = m_c_s.force_velocity.ToString();
		}
		else
		{
			value = m_c_s.force_velocity;
			if (m_c_s.pause_freeze_flag) 
			{
				TouchInfo _info = AppUtil.GetTouch();
				if (_info == TouchInfo.Began)
				{
					Execute(CHANGE);
				}
			}
			m_c_s.force_velocity = value;
		}
	}

	void Execute(float n)
	{
		Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);
		if (collition2d != null) 
		{
			if (this.name == "UP") 
			{
				if(collition2d.gameObject.name == this.name) 
				{
					value += n;
				}
			}
			else if (this.name == "DOWN") 
			{
				if(collition2d.gameObject.name == this.name) 
				{
					value -= n;
				}
			}
		}
	}
}
