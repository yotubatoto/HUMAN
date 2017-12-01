using UnityEngine;
using System.Collections;
using UnityEngine.UI;

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
	public float force_velocity = 50000.0f;
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
    public float VELOCITY_MAX = 20.0f;
    public bool pause_freeze_flag = false;
    private Vector2 arrow_start_pos = Vector2.zero;

    public GameObject[] right_obj = new GameObject[4];
    
    private bool began_flag = false;
	public GameObject debug_obj;
    public GameObject[] small;
    public GameObject[] big;
    private float _time = 0.0f;
	//public Text debug_test;

    /* --------------------------------------------------
	 * @パラメータ初期化
	*/
    void Start () {
		Application.targetFrameRate = 60;
        //カメラのスケール２５
        //Camera.main.orthographicSize = 25.0f;
        //small = GameObject.FindGameObjectsWithTag("Small_Block");
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update ()
	{
        //射出したあとのスピードを測る
        //Debug.Log(player.GetComponent<Rigidbody2D>().velocity.magnitude);

        TouchInfo _info = AppUtil.GetTouch();
        if (_info == TouchInfo.Began)
        {
            TouchObjectFind("pause");
        }
        //射出性質変化 小のとき青のオーラをまとう
        GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
       
        bool _flag = false;
        for (int i = 0; i < 4; i++)
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

		if (Input.GetKeyDown(KeyCode.RightArrow))
		{
			Camera.main.orthographicSize += 1.0f;
			Debug.Log(Camera.main.orthographicSize);
		}
		if (Input.GetKeyDown(KeyCode.LeftArrow))
		{
			Camera.main.orthographicSize -= 1.0f;
			Debug.Log(Camera.main.orthographicSize);
		}

		if (pause_freeze_flag == false)
        {
			debug_obj.SetActive (false);
			if (touch_freeze_flag == false) {

				if (player.GetComponent<Rigidbody2D> ().velocity.magnitude <= attenuation_speed && end_flag == true) {
                    //Debug.Log ("fddd");
					player.GetComponent<Rigidbody2D> ().velocity = new Vector2 (0, 0);
                    state_move_flag = true;
                    flag = false;
                    GameObject[] a = GameObject.FindGameObjectsWithTag("semi");
                    if (GameObject.FindGameObjectsWithTag("semi") != null)
                    {
                        foreach (GameObject _obj in a)
                        {
                            Destroy(_obj);
                        }
                    }
				}
                // && GetComponent<Manager> ().wave_flag == false
                //if (end_flag == true && player.GetComponent<Rigidbody2D> ().velocity.magnitude <= 0.0f ) {
                //    state_move_flag = true;
                //    flag = false;
                //    GameObject[] a = GameObject.FindGameObjectsWithTag ("semi");
                //    if (GameObject.FindGameObjectsWithTag ("semi") != null) {
                //        foreach (GameObject _obj in a) {
                //            Destroy (_obj);
                //        }
                //    }
                //}
         
				if (flag == false)
                {
					TouchInfo info = AppUtil.GetTouch ();
					if (info == TouchInfo.Began) {
						// タッチ開始
						began_flag = true;
                        //_time = 0.0f;
						startPos = AppUtil.GetTouchWorldPosition (Camera.main);
						circle.transform.position = startPos;
						anime.gameObject.GetComponent<SpriteRenderer> ().enabled = true;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().enabled = true;


						Color color = GameObject.Find ("arrow").GetComponent<SpriteRenderer> ().color;
						Color c_color = circle.GetComponent<SpriteRenderer> ().color;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color = 
                            new Color(0.0f, 0.0f, 1.0f, 1.0f);
						circle.GetComponent<SpriteRenderer> ().color = 
                            new Color (c_color.r, c_color.g, c_color.b, 0.4f);
						arrow.transform.localScale = new Vector3 (10.0f, 1, 1);

					}
					if (info == TouchInfo.Moved) {
						if (began_flag == false) {
							info = TouchInfo.Began;
						}
						anime.gameObject.GetComponent<SpriteRenderer> ().enabled = true;

						Color color = arrow.transform.Find ("arrow").gameObject.GetComponent<SpriteRenderer> ().color;
						Color circle_color = circle.GetComponent<SpriteRenderer> ().color;
						movePos = AppUtil.GetTouchWorldPosition (Camera.main);
						sub = movePos - startPos;
						// sub.magn大きさ　と　arrowのサイズをいい感じに比例させる
						// 数値を最大値で悪と0~1の間になる
						//float testes = sub.magnitude;
						//if (testes > 12)
						//    testes = 12.0f;
						//testes = (testes) / 12;

						//if (sub == Vector2.zero)
						//{
						//    info = TouchInfo.None;
						//    arrow.GetComponent<SpriteRenderer>().enabled = false;

						//}

						//if(sub.magnitude > 20.0f)
						//{
						//    sub.magnitude = 20.0f;
						//}
						//for(int i = 0; i < 10; i++)
						//{
						//    if(obj[i].GetComponent<Wall_Gimic>().number == 0)
						//    {

						//    }
						//}



						if (sub.x > VELOCITY_MAX) {
							sub.x = VELOCITY_MAX;
						}
						if (sub.x < -VELOCITY_MAX) {
							sub.x = -VELOCITY_MAX;
						}
						if (sub.y > VELOCITY_MAX) {
							sub.y = VELOCITY_MAX;
						}
						if (sub.y < -VELOCITY_MAX) {
							sub.y = -VELOCITY_MAX;
						}
						arrow.transform.localScale = new Vector3 (10.0f, sub.magnitude / 2, 2.0f);
                       

						float temp = sub.magnitude;

						//arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);

                       
						Shake_Arrow ();

						//Debug.Log(temp);

						float ang = Mathf.Atan2 (sub.y, sub.x) * Mathf.Rad2Deg;

						float angle = ang - 90.0f;
						if ((int)old_angle == (int)ang) {
							if (prediction_flag == false) {
								if (temp > 3) {
									//Debug.Log(temp);

									prediction_flag = true;
									GameObject[] a = GameObject.FindGameObjectsWithTag ("semi");
									if (GameObject.FindGameObjectsWithTag ("semi") != null) {
										foreach (GameObject _obj in a) {
											Destroy (_obj);
										}
									}
                                    GameObject obj_h = Instantiate (semitransparentPrefab, player.transform.position, player.transform.rotation);
                                   

                                    obj_h.transform.eulerAngles = new Vector3 (0, 0, 180 + angle);
									//ノーマライズド速度プレイヤーの

                                    //力を固定する45000
                                    force_ = ((sub.normalized * force_velocity) * temp * -1) * Time.deltaTime;
                                    if (force_.magnitude > 45000)
                                    {
                                        force_ = force_.normalized * 45000;
                                    }
                                    obj_h.GetComponent<Rigidbody2D>().AddForce(force_);                             
								}

							}
						}
						//Debug.Log((old_angle) - (ang));
						//予測線の出る角度
						float test = old_angle - ang;
						if (test > 0.7f || test < -0.7f) {
							prediction_flag = false;
						}
						player.transform.eulerAngles = new Vector3 (0, 0, 180 + angle);

						old_angle = ang;
                        //Debug.Log(sub.magnitude);
                            
                        //矢印赤
						if (sub.magnitude > 20) {
							anime.GetComponent<Animator> ().speed = 3.0f;
                            GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                                = new Color (1.0f, 0.0f, 0.0f, 1.0f);
							// endにいく
							//end_time += Time.deltaTime;
							//if (end_time > 4)
							//{
							//    touch_freeze_flag = true;
							//    info = TouchInfo.Ended;
                                
							//}
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
							anime.GetComponent<Animator> ().speed = 1.0f;
							GameObject.Find ("arrow").GetComponent<SpriteRenderer> ().color
                                = new Color (0.0f, 0.0f, 0.0f, 1.0f);
						}
					}
					if (info == TouchInfo.Ended) {
                        //デバッグログ　射出時のパワーを測る
                        //Debug.Log(sub.magnitude);

                        //if (GameObject.Find("Block/block_red (2)").GetComponent<BoxCollider>().)

                        //タップはなしたときスピードによって、障害物を突きにけるか否か。
                        bool once_flag;
                        if (sub.magnitude > 15)
                            once_flag = true;
                        else
                            once_flag = false;

                        //スモールブロック配列のトリガーをオンにする
                        small = GameObject.FindGameObjectsWithTag("Small_Block");
                        foreach (GameObject obs in small)
                        {
                            obs.GetComponent<Collider2D>().isTrigger = once_flag;
                            //射出性質変化 強のとき赤のオーラをまとう
                            GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = true;
                            //obs.layer = LayerName.None;
                        }
                        
            


                        //ビッグブロック配列のトリガーをオンにする
                        //big = GameObject.FindGameObjectsWithTag("Big_Block");
                        //foreach (GameObject obs in big)
                        //{
                        //    obs.GetComponent<Collider2D>().isTrigger = once_flag;
                        //    //obs.layer = LayerName.None;
                        //}
                      
                      


						began_flag = false;
						end_time = 0.0f;
                        //速度が３まで低下したら次のWAVEにいく
						if (sub.magnitude > 3) {

							end_flag = true;
							anime.GetComponent<Animator> ().speed = 1.0f;
							//arrow.GetComponent<SpriteRenderer>().enabled = false;
							Color color = GameObject.Find ("arrow").GetComponent<SpriteRenderer> ().color;
                            GameObject.Find("arrow").GetComponent<SpriteRenderer>().color 
                                = new Color(color.r, color.g, color.b, 0.0f);
                            GameObject.Find("Player/player_motion").GetComponent<SpriteRenderer>().enabled = false;

							flag = true;
							endPos = AppUtil.GetTouchWorldPosition (Camera.main);
							Vector2 a = endPos - startPos;
							//Debug.Log(a.magnitude);
							float temp = 0;
							temp = a.magnitude;
							//if (temp > 12.0f)
							//{
							//    temp = 12.0f;
							//}
							//スワイプの長さの値を変えれる
							player.GetComponent<Rigidbody2D> ().AddForce (force_);

						}
						GameObject[] aa = GameObject.FindGameObjectsWithTag ("semi");
						if (GameObject.FindGameObjectsWithTag ("semi") != null) {
							foreach (GameObject _obj in aa) {
								Destroy (_obj);
							}
						}
						Color c_color = circle.GetComponent<SpriteRenderer> ().color;
						circle.GetComponent<SpriteRenderer> ().color = new Color (c_color.r, c_color.g, c_color.b, 0.0f);
					}
				}
				//// カメラは追いかける
				//Vector3 vec = (player.transform.position - transform.position).normalized;
				//vec *= 1.0f;
				//transform.position += new Vector3(vec.x, vec.y, 0.0f);
			}
		}
		else 
		{
			debug_obj.SetActive (true);
		}
        
        //射出パワーが○○かつリジットボディのスピードが０のとき（subは射出時パワー、velocity magniはスピード）
        if (sub.magnitude > 20 && GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > 0)
        {
            
            if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 30)
            {
                //射出性質変化 強の赤オーラを消し黄のオーラを発生
                
                GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = true;

            }
            
            //スモールブロック配列のトリガーをオンにする
            
                    //射出後のスピードを測る
                     //Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude);

            //性質変化１２以下になったらタグを外し、中の性質変化に移行する（赤いオブジェ破壊せず跳ね返る）
                     if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 12)
                     {
                         //射出性質変化 中の黄オーラを消し青のオーラを発生

                         GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false; ;
                         GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = true;
                         small = GameObject.FindGameObjectsWithTag("Small_Block");
                         foreach (GameObject obs in small)
                         {
                             Debug.Log("iiiii");
                             obs.GetComponent<Collider2D>().isTrigger = false;

                         }
                     }

                     else if (sub.magnitude < 7 && GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                     {
                         
                        

                     }

            //射出パワーが○○かつリジットボディのスピードが０のとき（subは射出時パワー、velocity magniはスピード）
                     if (sub.magnitude > 20 && GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > 0)
                     {
                         //ビッグブロック配列のトリガーをオンにする

                         //射出後のスピードを測る
                         //Debug.Log(GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude);

                         //性質変化１２以下になったらタグを外し、中の性質変化に移行する（緑オブジェただ跳ね返る）
                         if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < 12)
                         {
                             big = GameObject.FindGameObjectsWithTag("Big_Block");
                             foreach (GameObject obs in big)
                             {
                                 //Debug.Log("iiiii");
                                 obs.GetComponent<Collider2D>().isTrigger = false;

                             }
                         }

                         else if (sub.magnitude < 7 && GameObject.Find("Player").GetComponent
                             <Rigidbody2D>().velocity.magnitude > 0)
                         {
                             //なにも書かない　＝　なにもしない
                         }
                     }
                                   
                
                    //float speed = rb.velocity.magnitude;

                    //obs.layer = LayerName.Default;
                    //bool f = false;
                    //obs.GetComponent<Collider2D>().isTrigger = f;
                    //Debug.Log(obs.GetComponent<Collider2D>().isTrigger);

                
        }
     
        //if (player.GetComponent<Rigidbody2D>().velocity.x < 6)
        //{
            
        //    //スモールブロック配列のトリガーをオンにする
        //    foreach (GameObject obs in small)
        //    {
        //        Debug.Log(obs.layer);
                        
        //        obs.layer = LayerName.Default;
        //        //bool f = false;
        //        //obs.GetComponent<Collider2D>().isTrigger = f;
        //        //Debug.Log(obs.GetComponent<Collider2D>().isTrigger);

        //    }
        //}
		// ----------
		// 移動範囲制限
		// ----------
		// 左// -6.2
		if (transform.position.x < -60.2f) {
			transform.position = new Vector3 (-6.2f, transform.position.y, transform.position.z);
		}
		// 右//6.2
		if (transform.position.x > 60.2f) {
			transform.position = new Vector3 (6.2f, transform.position.y, transform.position.z);
		}
		// 上//0.0f
		if (transform.position.y < 0.0f) {
			transform.position = new Vector3 (transform.position.x, 0.0f, transform.position.z);
		}
		// 下//50.0f
		if (transform.position.y > 70.0f) {
            transform.position = new Vector3(transform.position.x, 50.0f, transform.position.z);
		}
		// ----------
		//}

	}

    void TouchObjectFind(string name)
    {
        //Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
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
                    Color pause_color = new Color(0, 0, 0, 0);
                    Color pause_ = pause_black.gameObject.GetComponent<Image>().color;
                    pause_black.GetComponent<Image>().color = 
                        new Color(pause_color.r, pause_color.g, pause_color.b, 0.7f);
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
                    Color pause_color = new Color(0, 0, 0, 0);
                    Color pause_ = pause_black.gameObject.GetComponent<Image>().color;
                    pause_black.GetComponent<Image>().color = 
                        new Color(pause_color.r, pause_color.g, pause_color.b, 0.0f);
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
        }
        

    }
    void Shake_Arrow()
    {//引っ張り強さが16以上の時
        if (sub.magnitude >= 20.0f)
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

}
