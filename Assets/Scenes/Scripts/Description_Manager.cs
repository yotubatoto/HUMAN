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
    public Image now_load;
    public GameObject now_load_back;
    private bool transition = false;
    private int now_load_state = 0;
    private int choice_state_left = 0;
    private int choice_state_right = 0;
    void Awake()
    {
        // 開発している画面を元に縦横比取得 (縦画面) iPhone6, 6sサイズ
        //float developAspect = 750.0f / 1334.0f;
        // 横画面で開発している場合は以下の用に切り替えます
        float developAspect = 1334.0f / 750.0f;

        // 実機のサイズを取得して、縦横比取得
        float deviceAspect = (float)Screen.width / (float)Screen.height;

        // 実機と開発画面との対比
        float scale = deviceAspect / developAspect;

        Camera mainCamera = Camera.main;

        // カメラに設定していたorthographicSizeを実機との対比でスケール
        float deviceSize = mainCamera.orthographicSize;
        // scaleの逆数
        float deviceScale = 1.0f / scale;
        // orthographicSizeを計算し直す
        mainCamera.orthographicSize = deviceSize * deviceScale;

    }

    
    
	int count = 0;
	void Start () 
	{
        //マルチタッチ無効
        Input.multiTouchEnabled = false;
        GameObject.Find("Left").GetComponent<Image>().enabled = false;
        GameObject.Find("left_flare").GetComponent<Image>().enabled = false;

        

	}
	
	// Update is called once per frame
	void Update ()
	{
        now_load_state = _Utility.Flashing(now_load, 1.5f, now_load_state);
        choice_state_left = _Utility.Flashing(left, 1.5f, choice_state_left);
        choice_state_right = _Utility.Flashing(right, 1.5f, choice_state_right);

       
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
                        GameObject.Find("right_flare").GetComponent<Image>().enabled = true;

					}
				}
				if (right.enabled) 
				{
					if (collition2d.gameObject.name == "Right")
					{
						GetComponent<Sound_Manager> ().SE ();
						count += 1;
                        //GameObject.Find("Left").GetComponent<Image>().enabled = true;

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
                    GameObject.Find("left_flare").GetComponent<Image>().enabled = false;
                    GameObject.Find("right_flare").GetComponent<Image>().enabled = true;



				}
				if (count == 1) 
				{
					ima [0].enabled = false;
					ima [1].enabled = true;
					right.enabled = false;
					left.enabled = true;
                    GameObject.Find("left_flare").GetComponent<Image>().enabled = true;
                    GameObject.Find("right_flare").GetComponent<Image>().enabled = false;


				}			

                //ステセレ呼び出しかつ、連打防止
				if (collition2d.gameObject.name == "Next"　&& transition == false)
                {
                        GameObject.Find("GameMain").GetComponent<Now_Loading>().Load_NextScene_Title();
                        now_loading.GetComponent<Image>().enabled = true;
                        now_load_back.GetComponent<Image>().enabled = true;
                        GetComponent<Sound_Manager>().Resin_SE();
                        GameObject.Find("Right").GetComponent<BoxCollider2D>().enabled = false;                    
                        GameObject.Find("Left").GetComponent<BoxCollider2D>().enabled = false;                    
                        transition = true;
					
				}
			}
		}
	}
}
