using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Description_Manager : MonoBehaviour {

	// Use this for initialization
	public Image[] ima = new Image[2];
	public GameObject now_loading;
	public Image left;
	public Image right;
    
	int count = 0;
	void Start () 
	{
        //マルチタッチ無効
        Input.multiTouchEnabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
       
		// エスケープキー取得
		if (Input.GetKeyDown(KeyCode.Escape))
		{
			// アプリケーション終了
			Application.Quit();
			return;
		}
		if (count >= 2)
			count = 4;
		TouchInfo info = AppUtil.GetTouch ();
		if (info == TouchInfo.Began) 
		{
			Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

			if (collition2d != null) 
			{
				if (left.enabled)
				{
					if (collition2d.gameObject.name == "Left") 
					{
						GetComponent<Sound_Manager> ().SE ();
						count -= 1;
					}
				}
				if (right.enabled) 
				{
					if (collition2d.gameObject.name == "Right")
					{
						GetComponent<Sound_Manager> ().SE ();
						count += 1;
					}
				}

				if (count == 0) 
				{
					ima [0].enabled = true;
					ima [1].enabled = false;
//					ima [2].enabled = false;
//					ima [3].enabled = false;
					right.enabled = true;
					left.enabled = false;
				}
				if (count == 1) 
				{
					ima [0].enabled = false;
					ima [1].enabled = true;
//					ima [2].enabled = false;
//					ima [3].enabled = false;
					right.enabled = false;
					left.enabled = true;
				}
//				if (count == 2) 
//				{
//					ima [0].enabled = false;
//					ima [1].enabled = false;
////					ima [2].enabled = true;
////					ima [3].enabled = false;
//					right.enabled = true;
//					left.enabled = true;
//				}
//				if (count == 3) 
//				{
//					ima [0].enabled = false;
//					ima [1].enabled = false;
//					ima [2].enabled = false;
////					ima [3].enabled = true;
//					right.enabled = false;
//					left.enabled = true;
//				}

                
				if (collition2d.gameObject.name == "Next")
				{
					GameObject.Find ("GameMain").GetComponent<Now_Loading> ().Load_NextScene_Title ();
					now_loading.GetComponent<Image> ().enabled = true;
					GetComponent<Sound_Manager> ().Resin_SE();
				}
			}
		}
	}
}
