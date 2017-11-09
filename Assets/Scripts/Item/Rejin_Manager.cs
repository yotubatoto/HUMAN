using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rejin_Manager : MonoBehaviour
{
    public int stage;
    public GameObject managerObj = null;
    private int itemCount = 0;
	// Use this for initialization
	void Start () 
    {

        itemCount = managerObj.GetComponent<StageSelectManager>().itemCount;
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (stage == 1)
        {
            if (itemCount > 3)
            {
                GameObject child_ = transform.Find("RED").gameObject;
                child_.SetActive(true);
            }
            if (itemCount > 6)
            {
                GameObject child_ = transform.Find("GREEN").gameObject;
                child_.SetActive(true);
            }
        }

            
	}
    

    
}
