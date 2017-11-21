﻿using UnityEngine;
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
    public GameObject pause_black;
    public bool end_flag = false;
    public bool state_move_flag = false;
    public GameObject semitransparentPrefab;
    private bool prediction_flag = false;
    private GameObject obj = null;
    private int time = 0;
    private float old_angle = 0.0f;
	private Vector2 force_ = Vector2.zero;
    private int pause_count = 1;
    //射出の減衰スピード
    public float attenuation_speed = 2.0f;
    private int shake_state = 0;
    public float arrow_shake = 0.0f;
    public GameObject anime;
    private float end_time = 0.0f;

    private float swipe_scale = 0;
    private Vector2 sub;
    //どれぐらい引っ張れるか
    public float VELOCITY_MAX = 10.0f;
    private bool pause_freeze_flag = false;
    private Vector2 arrow_start_pos = Vector2.zero;
	//public Text debug_test;
    /* --------------------------------------------------
	 * @パラメータ初期化
	*/
    void Start () {
		Application.targetFrameRate = 60;
        //カメラのスケール２５
		Camera.main.orthographicSize = 25.0f;
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update ()
	{

        TouchInfo _info = AppUtil.GetTouch();
        if (_info == TouchInfo.Began)
        {
            TouchObjectFind("pause");
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

            if (touch_freeze_flag == false)
            {
                
                if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= attenuation_speed)
                {
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    flag = false;
                }
                if (end_flag == true && player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f && GetComponent<Manager>().wave_flag == false)
                {
                    state_move_flag = true;
                    GameObject[] a = GameObject.FindGameObjectsWithTag("semi");
                    if (GameObject.FindGameObjectsWithTag("semi") != null)
                    {
                        foreach (GameObject _obj in a)
                        {
                            Destroy(_obj);
                        }
                    }
                }
                //else
                //{
                //    state_move_flag = false;
                //}
                if (flag == false)
                {
                    TouchInfo info = AppUtil.GetTouch();
                    if (info == TouchInfo.Began)
                    {
                        // タッチ開始
                        startPos = AppUtil.GetTouchWorldPosition(Camera.main);
                        circle.transform.position = startPos;
                        anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                        Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                        Color c_color = circle.GetComponent<SpriteRenderer>().color;
                        arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(0.0f,0.0f,1.0f,1.0f);
                        circle.GetComponent<SpriteRenderer>().color = new Color(c_color.r, c_color.g, c_color.b, 0.4f);
                        arrow.transform.localScale = new Vector3(1, 1, 1);

                    }
                    if (info == TouchInfo.Moved)
                    {

                        Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                        Color circle_color = circle.GetComponent<SpriteRenderer>().color;
                        movePos = AppUtil.GetTouchWorldPosition(Camera.main);
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

                        if (sub.x > VELOCITY_MAX)
                        {
                            sub.x = VELOCITY_MAX;
                        }
                        if (sub.x < -VELOCITY_MAX)
                        {
                            sub.x = -VELOCITY_MAX;
                        }
                        if (sub.y > VELOCITY_MAX)
                        {
                            sub.y = VELOCITY_MAX;
                        }
                        if (sub.y < -VELOCITY_MAX)
                        {
                            sub.y = -VELOCITY_MAX;
                        }
                        arrow.transform.localScale = new Vector3(1.0f, sub.magnitude, 1.0f);
                       

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
                                    force_ = (sub.normalized * 900.0f) * temp * -1;
                                    obj_h.GetComponent<Rigidbody2D>().AddForce(force_);
                                }
                            }
                        }
                        //Debug.Log((old_angle) - (ang));
                        float test = old_angle - ang;
                        if (test > 1.1f || test < -1.1f)
                        {
                            prediction_flag = false;
                        }
                        player.transform.eulerAngles = new Vector3(0, 0, 180 + angle);

                        old_angle = ang;

                        if (sub.magnitude < 6)
                        {
                            anime.GetComponent<Animator>().speed = 0.5f;
                            arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color
                                = new Color(0.0f, 0.0f, 1.0f, 1.0f);
                        }
                        if (sub.magnitude > 6)
                        {
                            anime.GetComponent<Animator>().speed = 2.5f;
                            arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color
                                = new Color(1.0f, 1.0f, 0.0f, 1.0f);
                        }
                        if (sub.magnitude > 12)
                        {
                            anime.GetComponent<Animator>().speed = 5.0f;
                            arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color
                                = new Color(1.0f, 0.0f, 0.0f, 1.0f);
                            // endにいく
                            end_time += Time.deltaTime;
                            if (end_time > 3)
                            {
                                info = TouchInfo.Ended;
                            }
                        }
                    }
                    if (info == TouchInfo.Ended)
                    {
                        end_time = 0.0f;
                        if (sub.magnitude > 4)
                        {
                            end_flag = true;
                            anime.GetComponent<Animator>().speed = 0.5f;
                            //arrow.GetComponent<SpriteRenderer>().enabled = false;
                            Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                            arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.0f);
                            anime.gameObject.GetComponent<SpriteRenderer>().enabled = false;
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
                            GameObject[] aa = GameObject.FindGameObjectsWithTag("semi");
                            if (GameObject.FindGameObjectsWithTag("semi") != null)
                            {
                                foreach (GameObject _obj in aa)
                                {
                                    Destroy(_obj);
                                }
                            }
                        }
                        Color c_color = circle.GetComponent<SpriteRenderer>().color;
                        circle.GetComponent<SpriteRenderer>().color = new Color(c_color.r, c_color.g, c_color.b, 0.0f);
                    }
                }
                //// カメラは追いかける
                //Vector3 vec = (player.transform.position - transform.position).normalized;
                //vec *= 1.0f;
                //transform.position += new Vector3(vec.x, vec.y, 0.0f);
            }
        }

		

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
        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Collider2D collition2d = Physics2D.OverlapPoint(point);

        //Debug.Log(collition2d.gameObject.name);
        if (collition2d != null)
        {
            if (collition2d.gameObject.name == name)
            {
                pause_count += 1;
                //偶数時がポーズ
                if (pause_count % 2 == 0)
                {
                    pause_freeze_flag = true;
                    Pauser.Pause();
                    Color pause_color = new Color(0, 0, 0, 0);
                    Color pause_ = pause_black.gameObject.GetComponent<SpriteRenderer>().color;
                    pause_black.GetComponent<SpriteRenderer>().color = 
                        new Color(pause_color.r, pause_color.g, pause_color.b, 0.7f);
                }
                else
                {
                    pause_freeze_flag = false;
                    Pauser.Resume();
                    Color pause_color = new Color(0, 0, 0, 0);
                    Color pause_ = pause_black.gameObject.GetComponent<SpriteRenderer>().color;
                    pause_black.GetComponent<SpriteRenderer>().color = 
                        new Color(pause_color.r, pause_color.g, pause_color.b, 0.0f);
                }
                
            }
        }
    }
    void Shake_Arrow()
    {
        if (sub.magnitude >= 16.0f)
        {
            //Debug.Log("aaaa");
            Vector2 pos = arrow.transform.position;
            if (shake_state == 0)
            {
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
