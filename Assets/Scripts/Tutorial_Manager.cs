using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tutorial_Manager : MonoBehaviour {
    public Image[] manual = new Image[10];
    public Image left;
    public Image right;
    private bool once_flag = false;
  
    private int manual_count = 0;

	// Use this for initialization
	void Start () 
    {
        //マルチタッチ無効
        Input.multiTouchEnabled = false;
        GameObject.Find("Left").GetComponent<Image>().enabled = false;
        GameObject.Find("Right").GetComponent<Image>().enabled = false;



        //gameObject.activeSelf(false);
        manual_count = 0;
	}
	
	// Update is called once per frame
    void Update()
    {


        TouchInfo info = AppUtil.GetTouch();
        if (info == TouchInfo.Began)
        {
            Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

            if (collition2d != null)
            {
                if (GameObject.Find("Question"))
                {
                    //manual_count += 1;
                    once_flag = true;
                    if (once_flag == true)
                    {
                        //right.enabled = true;
                        Debug.Log("あああ");
                    }


                }

                if (right.enabled == true)
                {

                    if (collition2d.gameObject.name == "Right")
                    {
                        //GetComponent<Sound_Manager>().SE();
                        Debug.Log("はまだ黒い" + manual_count);

                        Debug.Log("はまだ肌黒い");
                        manual_count += 1;
                        if (manual_count >= 9)
                        {
                            manual_count = 9;
                        }

                        Tutorial_Call(manual_count);

                    }
                }

                if (left.enabled == true)
                {
                    if (collition2d.gameObject.name == "Left")
                    {
                        //GetComponent<Sound_Manager>().SE();
                        Debug.Log("はまだ白い" + manual_count);

                        Debug.Log("はまだ肌白い");
                        manual_count -= 1;
                        if (manual_count <= 0)
                        {
                            manual_count = 0;
                        }

                    }
                    Tutorial_Call(manual_count);

                }
            }
        }
    }
    
      
			
	
    public void Tutorial_Call(int t_count)
    {
        manual_count = t_count;
        

                if (manual_count == 0)
                {
                    manual[0].enabled = true;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = false;
                }

                if (manual_count == 1)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = true;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 2)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = true;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 3)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = true;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 4)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = true;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;

                }

                if (manual_count == 5)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = true;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 6)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = true;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 7)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = true;
                    manual[8].enabled = false;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }

                if (manual_count == 8)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = true;
                    manual[9].enabled = false;
                    right.enabled = true;
                    left.enabled = true;
                }
                if (manual_count == 9)
                {
                    manual[0].enabled = false;
                    manual[1].enabled = false;
                    manual[2].enabled = false;
                    manual[3].enabled = false;
                    manual[4].enabled = false;
                    manual[5].enabled = false;
                    manual[6].enabled = false;
                    manual[7].enabled = false;
                    manual[8].enabled = false;
                    manual[9].enabled = true;
                    right.enabled = false;
                    left.enabled = true;
                }

     }

        
}
    

