using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mission_Manager : MonoBehaviour {
    public GameObject Playerobj;
    public int mission_state = 0;
    public bool clear_flag = false;
    enum MISSION_STATE
    {
        STAGE_1_1 = 0,
        STAGE_1_2,
        STAGE_1_3
    };


	// Use this for initialization
	void Start () 
    {
	}
	
	// Update is called once per frame
	void Update () 
    {
        //if (mission_state == (int)MISSION_STATE.STAGE_1_1)
        //{
        //    clear_flag = Resin_GetNumber(4);
        //}
	}
    bool Resin_GetNumber(int max_resin)
    {
        int resin_count = Playerobj.GetComponent<Player_Collision>().item_count;

        if (resin_count > max_resin)
        {
            return true;
        }
        return false;
    }
    
    

    
}
