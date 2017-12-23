using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class _Utility : MonoBehaviour 
{
	static public int Flashing(Image image,float speed,int state)
	{
		Color c = image.color;
		if (state == 0) 
		{
			c.a += speed*Time.deltaTime;
			if (c.a >= 1.0f) 
			{
				c.a = 1.0f;
				state = 1;
			}
		}
		else if (state == 1) 
		{
			c.a -= speed*Time.deltaTime;
			if (c.a <= 0.0f) 
			{
				c.a = 0.0f;
				state = 0;
			}
		}
		image.color = c;
		return state;
	}
}
