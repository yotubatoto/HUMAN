using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour 
{
    public SpriteRenderer sp;
    private int flashing_count = 0;
	// Use this for initialization
	void Start () 
	{
		//GetComponent<Rigidbody2D>().AddForce(Vector2.right* 800);
	}
	
	// Update is called once per frame
	void Update () 
	{
        //Flashing();
	}
    
    public void Flashing()
    {
        flashing_count += 1;
        
        
        if(flashing_count % 3 == 0)
        {
            Debug.Log("oooooooo");
            sp.color = new Color(1, 1, 1,0);
            flashing_count = 0;
        }
        else
        {
            sp.color = new Color(1, 1, 1,1);
        }
    }
   public void Flashing_Ini()
    {
        sp.color = new Color(1, 1, 1, 1);
    }
}
