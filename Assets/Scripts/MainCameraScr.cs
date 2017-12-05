using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class MainCameraScr : MonoBehaviour
{
	private Vector2 startPos = Vector2.zero;
	private Vector2 endPos = Vector2.zero;
	private Vector2 movePos = Vector2.zero;
	public GameObject player;
    public bool touch_freeze_flag = false;
    public Vector3 Vec;
	private bool flag = false;
	public GameObject arrow;
    public GameObject circle;
    public GameObject pause;
    private float pause_time = 0.0f;
    public GameObject pause_black;
    public bool end_flag = false;
    public bool state_move_flag = false;
    public GameObject semitransparentPrefab;
    private bool prediction_flag = false;
    private GameObject obj = null;
    private int time = 0;
    private float old_angle = 0.0f;
	private Vector2 force_ = Vector2.zero;
	public float force_velocity = 40000.0f;
    public float nature_change_yellow;
    public float nature_change_blue;
    private int pause_count = 1;
    private int load_count = 1;
    //プレイヤー矢印の大きさ差分
    public GameObject player_anime_difference;
    public GameObject now_loading;
    Color color;
    //射出の減衰スピード
    public float attenuation_speed = 2.0f;
    private int shake_state = 0;
    public float arrow_shake = 0.0f;
    public GameObject anime;
    private float end_time = 0.0f;
    private bool pause_se_flag = false;

    private float swipe_scale = 0;
    public Vector2 sub;
    //どれぐらい引っ張れるか
    //ここをいじると連動してVELO＿MAGNIも落ちる
    public float VELOCITY_MAX = 20.0f;
    public bool pause_freeze_flag = false;
    public GameObject retry;
    private Vector2 arrow_start_pos = Vector2.zero;

    //ランプの数
    private GameObject[] right_obj;
    
    private bool began_flag = false;
	public GameObject debug_obj;
    public GameObject[] small;
    public GameObject[] big;
    private float _time = 0.0f;
    //ライト点灯のカウントを数える（クリア条件につながる）　ランプレベルにかかわらず
    //クリアランプのレベルはWall gimic Csのクリアカウントをいじる
    private int right_count = 0;
    public int main_move_state = 0;
    public int number_count = 0;
    // 性質変化の現在の状態 =>enableがfalseの場合0、青だと１、黄色だと２、赤だと３
    public int characteristic_change_state = 0;
	//public Text debug_test;
    private bool test_flag = false;
    private float t_x, t_y = 0.0f;
	public GameObject finger_circle;
	public float MAX_DISTANCE = 25.0f;
    public GameObject retry_obj;
    private float delay_time = 0.0f;
    /* public GameObject Afterimage_prefab; */  //残像のプレファブ変数
                                                //public Text debug_test;

    /* --------------------------------------------------
	 * @パラメータ初期化
	*/
    void Start () {
		Application.targetFrameRate = 60;
        //カメラのスケール２５
        //Camera.main.orthographicSize = 25.0f;
        right_obj = GameObject.FindGameObjectsWithTag("Gimic");
        right_count = right_obj.Length;
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update ()
	{
        

        //Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude);
        small = GameObject.FindGameObjectsWithTag("Small_Block");
        
        //Debug.Log("main_move_state: " + main_move_state);
        bool _flag = false;
        for (int i = 0; i < right_count; i++)
        {
            if (right_obj[i].GetComponent<Wall_Gimic>().clear_flag == false)
            {
                _flag = true;
            }
        }
        if (_flag == false)
        {
            GetComponent<Mission_Manager>().clear_flag = true;
        }

        TouchInfo info = AppUtil.GetTouch();
        if(pause_black.gameObject.activeSelf == false)
        {
            if (info == TouchInfo.Began)
            {
                Debug.Log("sss");
                TouchObjectFind("pause");
                TouchObjectSearch(name);
                delay_time = 0.0f;
            }
        }
      
        if(pause_freeze_flag == false)
        {

          

            // 射出していないとき
            if (main_move_state == 0)
            {
                //TouchInfo _info = AppUtil.GetTouch();

                //GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                //GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                //GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;

                

                if (info == TouchInfo.Began)
                {
                    

                    test_flag = false;
                    began_flag = true;
                    test_flag = false;
                    //_time = 0.0f;
                    startPos = AppUtil.GetTouchWorldPosition(Camera.main);
                    circle.transform.position = startPos;
//					finger_circle.GetComponent<SpriteRenderer> ().color = new Color(1.0f,0,0,1);
//					finger_circle.gameObject.transform.position = AppUtil.GetTouchWorldPosition(Camera.main);
//					finger_circle.gameObject.transform.position = new Vector3 (startPos.x,
//						startPos.y, 0);
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().enabled = true;


                    Color color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color =
                        new Color(0.0f, 0.0f, 1.0f, 1.0f);
                    circle.GetComponent<SpriteRenderer>().color =
                        new Color(c_color.r, c_color.g, c_color.b, 1.0f);
                    arrow.transform.localScale = new Vector3(10.0f, 1, 1);
                    // スワイプし始めたら状態を移行する

                   

                }
                if (info == TouchInfo.Moved)
                {
//					finger_circle.GetComponent<SpriteRenderer> ().color = new Color(1.0f,0,0,1);
//					finger_circle.gameObject.transform.position = AppUtil.GetTouchWorldPosition(Camera.main);
//					finger_circle.gameObject.transform.position = new Vector3 (sub.x,sub.y, 0);
                    end_flag = false;
                    main_move_state = 1;
                    //if (began_flag == false)
                    //{
                    //    info = TouchInfo.Began;
                    //}
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                    Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                    Color circle_color = circle.GetComponent<SpriteRenderer>().color;
                    movePos = AppUtil.GetTouchWorldPosition(Camera.main);
                    sub = movePos - startPos;
                    arrow.transform.localScale = new Vector3(10.0f, sub.magnitude / 2, .0f);


                    float temp = sub.magnitude;

                    //arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);


                    Shake_Arrow();

                    //Debug.Log(temp);

                    float ang = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg;

                    float angle = ang - 90.0f;
                    if ((int)old_angle == (int)ang)
                    {
                        if (prediction_flag == false)
                        {
                            if (temp > 3)
                            {
                                //Debug.Log(temp);

                                prediction_flag = true;
                                GameObject[] a = GameObject.FindGameObjectsWithTag("semi");
                                if (GameObject.FindGameObjectsWithTag("semi") != null)
                                {
                                    foreach (GameObject _obj in a)
                                    {
                                        Destroy(_obj);
                                    }
                                }
                                GameObject obj_h = Instantiate(semitransparentPrefab, player.transform.position, player.transform.rotation);


                                obj_h.transform.eulerAngles = new Vector3(0, 0, 180 + angle);
                                //ノーマライズド速度プレイヤーの

                                //力を固定する45000
                                force_ = ((sub.normalized * force_velocity) * temp * -1) * Time.deltaTime;
                                if (force_.magnitude > 40000)
                                {
                                    force_ = force_.normalized * 40000;
                                }
                                obj_h.GetComponent<Rigidbody2D>().AddForce(force_);
                            }

                        }
                    }
					float radius = Vector2.Distance(startPos,movePos);
					if (radius > MAX_DISTANCE) 
					{
						float radian = CalcRadian(
							startPos, 
							movePos
						);
						float x = MAX_DISTANCE * Mathf.Cos (radian);
						float y = MAX_DISTANCE * Mathf.Sin (radian);
						sub = new Vector2(x,y);
					}
                    //Debug.Log((old_angle) - (ang));
                    //予測線の出る角度
                    float test = old_angle - ang;
                    if (test > 0.7f || test < -0.7f)
                    {
                        prediction_flag = false;
                    }
                    player.transform.eulerAngles = new Vector3(0, 0, 180 + angle);

                    old_angle = ang;
                    //Debug.Log(sub.magnitude);

                    //矢印赤
                    if (sub.magnitude > 20)
                    {
                        anime.GetComponent<Animator>().speed = 3.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    }
                    //矢印イエロー
                    else if (sub.magnitude > 9)
                    {
                        anime.GetComponent<Animator>().speed = 2.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                    }
                    //3より射出パワーが上なら矢印ブルー
                    else if (sub.magnitude > 3)
                    {
                        anime.GetComponent<Animator>().speed = 2.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 1.0f, 1.0f);


                    }
                    else
                    {   //射出すらできないパワーの時ブラックカラー矢印
                        anime.GetComponent<Animator>().speed = 1.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    }
                }
            }
            // 画面に触れて矢印が出ているとき
            else if (main_move_state == 1)
            {

                if (info == TouchInfo.Moved)
                {			
//					finger_circle.GetComponent<SpriteRenderer> ().color = new Color(1.0f,0,0,1);
//					finger_circle.gameObject.transform.position = AppUtil.GetTouchWorldPosition(Camera.main);
//					finger_circle.gameObject.transform.position = new Vector3 (sub.x,sub.y, 0);
                    //if (began_flag == false)
                    //{
                    //    info = TouchInfo.Began;
                    //}
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                    Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                    Color circle_color = circle.GetComponent<SpriteRenderer>().color;
                    movePos = AppUtil.GetTouchWorldPosition(Camera.main);
                    sub = movePos - startPos;

                    //Debug.Log(temp);
					// ここでdumpをやっている
					float radius = Vector2.Distance(startPos,movePos);
					if (radius > MAX_DISTANCE) 
					{
						float radian = CalcRadian(
							startPos, 
							movePos
						);
						float x = MAX_DISTANCE * Mathf.Cos (radian);
						float y = MAX_DISTANCE * Mathf.Sin (radian);
						sub = new Vector2(x,y);
					}

					arrow.transform.localScale = new Vector3(10.0f, sub.magnitude / 2, 2.0f);

					Shake_Arrow();
					float temp = sub.magnitude;
					Debug.Log (sub);
                    float ang = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg;

                    float angle = ang - 90.0f;
                    if ((int)old_angle == (int)ang)
                    {
                        if (prediction_flag == false)
                        {
                            if (temp > 3)
                            {
                                //Debug.Log(temp);

                                prediction_flag = true;
                                GameObject[] a = GameObject.FindGameObjectsWithTag("semi");
                                if (GameObject.FindGameObjectsWithTag("semi") != null)
                                {
                                    foreach (GameObject _obj in a)
                                    {
                                        Destroy(_obj);
                                    }
                                }
                                GameObject obj_h = Instantiate(semitransparentPrefab, player.transform.position, player.transform.rotation);


                                obj_h.transform.eulerAngles = new Vector3(0, 0, 180 + angle);
                                //ノーマライズド速度プレイヤーの

                                //力を固定する45000
                                force_ = ((sub.normalized * force_velocity) * temp * -1) * Time.deltaTime;
                                if (force_.magnitude > 40000)
                                {
                                    force_ = force_.normalized * 40000;
                                }
                                obj_h.GetComponent<Rigidbody2D>().AddForce(force_);
                            }

                        }
                    }
                    //Debug.Log((old_angle) - (ang));
                    //予測線の出る角度
                    float test = old_angle - ang;
                    if (test > 0.7f || test < -0.7f)
                    {
                        prediction_flag = false;
                    }
                    player.transform.eulerAngles = new Vector3(0, 0, 180 + angle);

                    old_angle = ang;
                    //Debug.Log(sub.magnitude);
								
                    //矢印赤
                    if (sub.magnitude > 14)
                    {
                        anime.GetComponent<Animator>().speed = 3.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                    }
                    //矢印イエロー
                    else if (sub.magnitude > 9)
                    {
                        anime.GetComponent<Animator>().speed = 2.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                    }
                    //3より射出パワーが上なら矢印ブルー
                    else if (sub.magnitude > 3.0f)
                    {
                        anime.GetComponent<Animator>().speed = 2.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 1.0f, 1.0f);


                    }
                    else
                    {   //射出すらできないパワーの時ブラックカラー矢印
                        anime.GetComponent<Animator>().speed = 1.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    }
                }
                if (info == TouchInfo.Ended)
                {
//					finger_circle.GetComponent<SpriteRenderer> ().color = new Color(1.0f,0,0,0);
                    //デバッグログ　射出時のパワーを測る
                 
                    began_flag = false;
                    end_time = 0.0f;
                    //速度が３まで低下したら次のWAVEにいく
                    if (sub.magnitude > 3.0f)
                    {
                        number_count += 1;
                        end_flag = true;
                        anime.GetComponent<Animator>().speed = 1.0f;
                        //arrow.GetComponent<SpriteRenderer>().enabled = false;
                        Color color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(color.r, color.g, color.b, 0.0f);
                        GameObject.Find("Player/player_motion").GetComponent<SpriteRenderer>().enabled = false;

                        flag = true;
                        endPos = AppUtil.GetTouchWorldPosition(Camera.main);
                        Vector2 a = endPos - startPos;
                        //Debug.Log(a.magnitude);
                        float temp = 0;
                        temp = a.magnitude;
                        //if (temp > 12.0f)
                        //{
                        //    temp = 12.0f;
                        //}
                        //スワイプの長さの値を変えれる
                        player.GetComponent<Rigidbody2D>().AddForce(force_);

                    }
                    GameObject[] aa = GameObject.FindGameObjectsWithTag("semi");
                    if (GameObject.FindGameObjectsWithTag("semi") != null)
                    {
                        foreach (GameObject _obj in aa)
                        {
                            Destroy(_obj);
                        }
                    }
                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    circle.GetComponent<SpriteRenderer>().color = new Color(c_color.r, c_color.g, c_color.b, 0.0f);
                }

                // 画面から指を離したら状態を移行
                if (end_flag)
                {
                    main_move_state = 2;
                }
            }
            // 打ち出した後
            else if (main_move_state == 2)
            {
                if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= attenuation_speed)
                {
                    //射出性質変化 小のとき青のオーラをまとう
                    //GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    state_move_flag = true;
                    flag = false;
                    GameObject[] a = GameObject.FindGameObjectsWithTag("semi");
                    if (GameObject.FindGameObjectsWithTag("semi") != null)
                    {
                       
                        foreach (GameObject _obj in a)
                        {
                            Destroy(_obj);
                        }
                        //GameObject obj_a = Instantiate(Afterimage_prefab, transform.position, transform.rotation);  //プレイヤーが打ち出された後残像を生成
                        //Debug.Log("aa");
                    }
                    if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 3)
                    {
                        main_move_state = 0;
                    }
                    main_move_state = 0;
                }
               
            }
        }

        if (pause_black.gameObject.activeSelf == true)
        {
            TouchInfo t_info = AppUtil.GetTouch();
            delay_time += Time.deltaTime;
            if (t_info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

                if (collition2d != null)
                {
                    Debug.Log(collition2d.gameObject.name);

                    if (collition2d.gameObject.name == "Retry")
                    {
                        SceneManager.LoadScene("Stage_" + "1_1" + "_Scene");
                        //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                    }
                    else if(collition2d.gameObject.name == "Select")
                    {
                        SceneManager.LoadScene("StageSelect_Scene");
                    }
                    else if(collition2d.gameObject.name == "pause" && delay_time >= 0.5f)
                    {
                        delay_time = 0.0f;
                        pause_black.gameObject.SetActive(false);
                    }
                }
            }
        }
            //    {
            //if(pause_freeze_flag == true) 
            //{
            //    TouchInfo info_retry = AppUtil.GetTouch();



            //    if (retry_obj.gameObject.activeSelf == true)
            //    {
            //            if (info_retry == TouchInfo.Began)
            //            {
            //            Vector2 tapPoint   = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //            Collider2D collition2d  = Physics2D.OverlapPoint(tapPoint);
            //            if (collition2d)
            //            {
            //                RaycastHit2D hitObjects  = Physics2D.Raycast(tapPoint, -Vector2.up);
            //                if (hitObjects)
            //                {
            //                    Debug.Log("hit object is " + hitObjects.collider.gameObject.name);
            //                }
            //            }
            //            ////if (retry_obj.activeSelf == true)
            //            ////{
            //            ////    Debug.Log("ppp");
            //            //Collider2D collition2 = Physics2D.OverlapPoint(Input.mousePosition);
            //            //if (collition2 != null)
            //            //{
            //            //    Debug.Log("キターー");
            //            //    if (collition2.gameObject.name == "Retry")
            //            //    {
            //            //      SceneManager.LoadScene("Title_Scene");
            //            //    }

            //            //}

            //        }
            //        //TouchObjectFind("pause");
            //        //TouchObjectFind("Retry");
            //        //GameObject.Find("Retry").GetComponent<Image>.enabled = false;

            //    }
            //}

            //        Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude);
            // 性質変化
            Change();
	}

	private float CalcRadian(Vector3 from, Vector3 to) 
	{
		float dx = to.x - from.x;
		float dy = to.y - from.y;
		float radian = Mathf.Atan2(dy, dx);
		return radian;
	}

    void Change()
    {
        if(main_move_state == 2)
        {
            //if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > nature_change_blue &&

               if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < nature_change_blue)
            {
                characteristic_change_state = 1;
                //射出性質変化 中小のオーラを消し青のオーラを発生
                
                GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = true;
                foreach (GameObject obs in small)
                {
                    obs.GetComponent<Collider2D>().isTrigger = false;
                }
            }
            else if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > nature_change_blue &&
                GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < nature_change_yellow)
            {
                characteristic_change_state = 2;
                //射出性質変化 赤青オーラを消し黄のオーラを発生
                
                GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                foreach (GameObject obs in small)
                {
                    obs.GetComponent<Collider2D>().isTrigger = false;
                }
            }
   
            else if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > nature_change_yellow)
            {
                characteristic_change_state = 3;
                //射出性質変化 赤のオーラを発生

                GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = true;
                GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                small = GameObject.FindGameObjectsWithTag("Small_Block");
                foreach (GameObject obs in small)
                {
                    obs.GetComponent<Collider2D>().isTrigger = true;
                }
            }
           
        }
        else
        {
            characteristic_change_state = 0;
            GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
            GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;
        }
    }

    void TouchObjectFind(string name)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

        //Debug.Log(collition2d.gameObject.name);
        if (collition2d != null)
        {
            if (collition2d.gameObject.name == name)
            {
                pause_count += 1;
                //偶数時がポーズ
                if (pause_count % 2 == 0)
                {

                    if (pause_se_flag == false)
                    {
                        pause_se_flag = true;
                        GetComponent<Sound_Manager>().pause_SE();
                    }
                    pause_freeze_flag = true;

                   


                    Pauser.Pause();
                    //Color pause_color = new Color(0, 0, 0, 0);
                    pause_black.gameObject.SetActive(true);
                    //Color pause_ = pause_black.gameObject.GetComponent<Image>().color;
                    //pause_black.GetComponent<Image>().color = 
                    //    new Color(pause_color.r, pause_color.g, pause_color.b, 0.7f);
                    //GameObject.Find("Retry").GetComponent<Image>().enabled = true;
                    //GameObject.Find("Select").GetComponent<Image>().enabled = true;
                }
                else
                {
                    //pause_time += 0.01f;
                    //if (pause_time > 1)
                    //{
                        pause_freeze_flag = false;

                    //}
                    pause_se_flag = false;
                    Pauser.Resume();
                    pause_black.gameObject.SetActive(false);

                    //Color pause_color = new Color(0, 0, 0, 0);
                    //Color pause_ = pause_black.gameObject.GetComponent<Image>().color;
                    //pause_black.GetComponent<Image>().color = 
                    //    new Color(pause_color.r, pause_color.g, pause_color.b, 0.0f);
                    //GameObject.Find("Retry").GetComponent<Image>().enabled = false;
                    //GameObject.Find("Select").GetComponent<Image>().enabled = false;


                }


            }
            if (collition2d.gameObject.name == name)
            {
                if (load_count == 1)
                {
                    Color pause_color = new Color(0, 0, 0, 0);
                    //Color pause_ = now_loading.gameObject.GetComponent<Image>().color;
                //    now_loading.GetComponent<Image>().color =
                //        new Color(pause_color.r, pause_color.g, pause_color.b, 0.7f);
                }
                
            }

            //Debug.Log(collition2d.gameObject.name);

            
        }


    }
    void Shake_Arrow()
    {//引っ張り強さが20以上の時
        if (sub.magnitude >= 14.0f)
        {
            //Debug.Log("aaaa");
            Vector2 pos = arrow.transform.position;
            if (shake_state == 0)
            {//矢印揺れるスピード
                arrow_shake += 0.08f;
                pos.y += arrow_shake;
                if (arrow_shake > 0.3f)
                {
                    shake_state = 1;
                    arrow_shake = 0.0f;
                }

            }
            if (shake_state == 1)
            {
                arrow_shake += 0.08f;
                pos.y -= arrow_shake;
                if (arrow_shake > 0.3f)
                {
                    shake_state = 0;
                    arrow_shake = 0.0f;
                }

            }
            arrow.transform.position = pos;
        }
    }

    void TouchObjectSearch(string name)
    {
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        Application.Quit();

        if (collition2d != null)
        {
            if (collition2d.gameObject.name == name)
            {
                    Debug.Log("aaa");
                    Application.Quit();
                    if(name == "pause")
                    {
                        if (retry_obj.gameObject.activeSelf == false)
                        {
                            retry_obj.SetActive(true);
                        }
                    }
                       
            }
        }

    }
}
