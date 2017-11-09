using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Wall_Gimic : MonoBehaviour {
    public Text resin_text;
    private int resin_count = 0;
    public GameObject player;
    private int bonus = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
    {
		if(player.GetComponent<Player_Collision>().bonus_flag == true)
        {
            bonus = 5;
        }
	}
    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.tag == "Player")
        {
            //resin_count += 1;
            int temp = int.Parse(resin_text.text)+(1* bonus);
            resin_text.text = temp.ToString();
            bonus = 1;
            player.GetComponent<Player_Collision>().bonus_flag = false;
            
        }
    }
}
