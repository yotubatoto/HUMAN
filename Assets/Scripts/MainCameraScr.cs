using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Scripting;


//using UnityEngine.SceneManagement;



public class MainCameraScr : MonoBehaviour
{
    float velocity_max = float.MinValue;

    private Vector2 startPos = Vector2.zero;
    private Vector2 endPos = Vector2.zero;
    private Vector2 movePos = Vector2.zero;
    public GameObject player;
    public bool touch_freeze_flag = false;
    public Vector3 Vec;
    private bool flag = false;
    public GameObject arrow;
    public GameObject arrow_tri;
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
    Color color_1;
    //射出の減衰スピード
    public float attenuation_speed = 2.0f;
    private int shake_state = 0;
    public float arrow_shake = 0.0f;
    private float arrow_tri_shake = 0.0f;
    public GameObject anime;
    private float end_time = 0.0f;
    private bool pause_se_flag = false;
    //サブ＊下記の変数＊フォースベロシティをかけることで射出時のスピードの出方を調節
    private float speed = 1.0f;
    private float blue_speed = 1.2f;
    private float yellow_speed = 1.5f;

    //private float swipe_scale = 0;
    public Vector2 sub;
    public float temp;
    //どれぐらい引っ張れるか
    //ここをいじると連動してVELO＿MAGNIも落ちる
    public float VELOCITY_MAX = 20.0f;
    public bool pause_freeze_flag = false;
    public GameObject retry;
    private Vector2 arrow_start_pos = Vector2.zero;
    private Vector2 arrow_tri_start_pos = Vector2.zero;

    //ランプの数
    public GameObject[] right_obj;

    private bool began_flag = false;
    public GameObject debug_obj;
    public GameObject[] small;
    public GameObject[] big;
    public GameObject[] blue_small;
    private float _time = 0.0f;
    //ライト点灯のカウントを数える（クリア条件につながる）　ランプレベルにかかわらず
    //クリアランプのレベルはWall gimic Csのクリアカウントをいじる
    public int right_count = 0;
    // ゲームスタート時　-1 //射出していないとき　0　タッチして触れているとき 1（ふれたまま　打ち出した後　2
    public int main_move_state = -3;
    public int number_count = 0;
    // 性質変化の現在の状態 =>enableがfalseの場合0、青だと１、黄色だと２、赤だと３
    public int characteristic_change_state = 0;
    //public Text debug_test;
    private bool test_flag = false;
    private float t_x, t_y = 0.0f;
    public GameObject finger_circle;
    public float MAX_DISTANCE = 25.0f;
    //0色なし　1　青　2　黄　3　赤
    private int bonus_nature_change_red = 0;
    private int bonus_nature_change_yellow = 0;
    //大の小などで打つとボーナスで性質変化を保持する
    private float bonus_color_red = 0.0f;
    private float bonus_color_yellow = 0.0f;
    public float CHANGE_COLOR_DELAY_COUNT = 0.5f;
    private float delay_time = 0.0f;
    private bool gamestart_al_flag = false;

    private float diagonal;

    //ゲームスタート時のフェード
    public GameObject game_filter;
    private float filter_time = 1.0f;
    private bool game_start_flag = false;
    private float gamestart_al = 0.0f;
    public Sprite change_sp;
    private Sprite ini_sp;
    private int temp_save = 0;

    public GameObject rial;
    //連打防止
    private bool main_barrage_flag = false;

    //操作説明のオブジェ
    public GameObject[] manual = new GameObject[10];



    private bool transition_flag = false;

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
    public GameObject mission_obj;
    //ゲームスタート前のミッション表示
    public Vector2 hold = new Vector2(float.MaxValue, float.MaxValue);   //矢印がプレイヤーの座標から動かないようにする
    public float touch_time = 0.0f;
    //public float check_time = 0.0f;
    private string st_owner = null;
    private int state = 0;
    public Image nowloading_back_img;

    /* --------------------------------------------------
	 * @パラメータ初期化
	*/
    void Start()
    {
        //hamada
        //string a = "よろしく";
        if (StageSelectManager.ST_OWNER_NUMBER != null)
            st_owner = StageSelectManager.ST_OWNER_NUMBER.Substring(0, 1);
        //Debug.Log(b);
        //マルチタッチ無効
        Input.multiTouchEnabled = false;

        Time.timeScale = 1.0f;
        //Application.targetFrameRate = 60;
        //カメラのスケール２５
        //Camera.main.orthographicSize = 25.0f;
        right_obj = GameObject.FindGameObjectsWithTag("Gimic");
        right_count = right_obj.Length;
        Image image = pause.GetComponent<Image>();

        ini_sp = image.sprite;
        GameObject.Find("Fade").gameObject.GetComponent<Image>().enabled = true;
    }



    /* --------------------------------------------------
	 * @毎フレーム更新
	*/
    void Update()
    {
        if (nowloading_back_img.enabled)
        {
            //タップトゥスタートの透明、不透明　値など
            state = _Utility.Flashing(now_loading.GetComponent<Image>(), 1.5f, state);
            //now_load_state = _Utility.Flashing(now_load, 1.5f, now_load_state);
        }

        if (hold.x != float.MaxValue)
        {
            arrow.transform.position = hold;
            //arrow_tri.transform.position = hold;
            hold = new Vector2(float.MaxValue, float.MaxValue);
        }

        TouchInfo info_m = AppUtil.GetTouch();


        //スタート時にホワイトから透明に
        if (main_move_state == -3)
        {
            //ゲーム開始時フェードを済ませてからターンとターンナンバーのアルファをいじる。
            Color c = GameObject.Find("Fade").GetComponent<Image>().color;
            c.a -= 0.02f;
            if (c.a <= 0.0f)
            {
                main_move_state = -2;
                c.a = 0;
            }
            GameObject.Find("Fade").GetComponent<Image>().color = c;
        }


        else if (main_move_state == -2)
        {
            int temp = 0;
            if (st_owner != null)
            {
                if (st_owner == "1")
                {
                    //チュートリアル画像を表示する
                    for (int i = 1; i <= 10; i++)
                    {
                        if (StageSelectManager.ST_OWNER_NUMBER == ("1_" + i.ToString()))
                        {
                            manual[i - 1].SetActive(true);
                            temp = i;
                            temp_save = temp;
                        }
                    }
                }
                else
                {
                    mission_obj.SetActive(true);
                }
            }
            else
            {
                mission_obj.SetActive(true);
            }
            //manual_0.SetActive(true);
            if (info_m == TouchInfo.Ended)
            {

                main_move_state = -1;
                //manual_0.SetActive(false);
                if (st_owner != null && st_owner == "1")
                {
                    manual[temp - 1].SetActive(false);
                }
                else
                {
                    mission_obj.SetActive(false);
                }
            }

        }


        //ゲームスタート画像を徐々に遷移
        else if (main_move_state == -1)
        {
            if (gamestart_al_flag == false)
            {
                pause_freeze_flag = true;
                gamestart_al += 1.0f * Time.deltaTime;
                if (gamestart_al >= 1.0f)
                {
                    gamestart_al = 1.0f;
                    gamestart_al_flag = true;
                }
            }
            else
            {
                gamestart_al -= 1.0f * Time.deltaTime;

                if (gamestart_al <= 0.0f)
                {
                    main_move_state = 0;
                    pause_freeze_flag = false;
                }
            }


            GameObject.Find("GameStart").GetComponent<Image>().color = new Color(1.0f, 1.0f, 1.0f, gamestart_al);
        }

        if (main_move_state == 0)
        {


            ////ゲームスタート時のフィルターを少しずつフェードさせる
            //  GameObject.Find("Game_Filter").GetComponent<Image>().enabled = true;

            //  Color color = GameObject.Find("Game_Filter").GetComponent<Image>().color;
            //  GameObject.Find("Game_Filter").GetComponent<Image>().color =
            //              new Color(1.0f, 1.0f, 1.0f, filter_time);
            //  filter_time -= 0.02f;

            //  if(color == new Color (1.0f,1.0f,1.0f,0.0f))
            //  {
            //      main_move_state = 0;

            //  }

        }
        if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > velocity_max)
        {
            velocity_max = GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude;
            //Debug.Log("ベロシティ" + velocity_max);
        }

        //Debug.Log("ベロシティ" + GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude);

        small = GameObject.FindGameObjectsWithTag("Small_Block");
        blue_small = GameObject.FindGameObjectsWithTag("Blue_Block");

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
        if (pause_black.gameObject.activeSelf == true)
        {
            //if (nowloading_back_img.enabled)
            //{
            //    //タップトゥスタートの透明、不透明　値など
            //    state = _Utility.Flashing(now_loading.GetComponent<Image>(), 1, state);
            //    //now_load_state = _Utility.Flashing(now_load, 1.5f, now_load_state);
            //}
            pause_se_flag = false;
            Image image = pause.GetComponent<Image>();
            image.sprite = change_sp;
            Image imaage1 = pause.GetComponent<Image>();




            TouchInfo t_info = AppUtil.GetTouch();
            delay_time += Time.deltaTime;
            if (t_info == TouchInfo.Began)
            {
                Collider2D collition2d = Physics2D.OverlapPoint(Input.mousePosition);

                if (collition2d != null)
                {
                    //Debug.Log(collition2d.gameObject.name);
                    if (temp_save == 0)
                    {
                        temp_save = 1;
                    }

                    if (manual[temp_save - 1].activeSelf == false && collition2d.gameObject.name == "Retry" && main_barrage_flag == false)
                    {
                        //SceneManager.LoadScene("Stage_" + "1_1" + "_Scene");
                        //SceneManager.LoadScene("Stage_" + StageSelectManager.ST_OWNER_NUMBER + "_Scene");
                        GetComponent<Now_Loading>().LoadNextScene();
                        GetComponent<Sound_Manager>().Stage_Choice_SE();
                        main_barrage_flag = true;
                        GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                        GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;

                    }
                    else if (manual[temp_save - 1].activeSelf == false && collition2d.gameObject.name == "Stage_Select" && main_barrage_flag == false)
                    {
                        //SceneManager.LoadScene("StageSelect_Scene");
                        GetComponent<Now_Loading>().Load_NextScene_Title();
                        GetComponent<Sound_Manager>().Stage_Choice_SE();
                        main_barrage_flag = true;
                        GameObject.Find("Now_Loading").GetComponent<Image>().enabled = true;
                        GameObject.Find("Now_load_back").GetComponent<Image>().enabled = true;

                    }
                    else if (collition2d.gameObject.name == "Question")
                    {
                        string st = StageSelectManager.ST_OWNER_NUMBER.Substring(0, 1);
                        if (st != "1")
                        {
                            GetComponent<Sound_Manager>().Question_SE();
                            Debug.Log("iiiii");
                            GameObject.Find("Question").SetActive(false);
                            GameObject.Find("Common/Canvas/Tutorial").SetActive(true);
                            GameObject.Find("Common/Canvas/pause_black/Retry").SetActive(false);
                            GameObject.Find("Common/Canvas/pause_black/Stage_Select").SetActive(false);
                            GameObject.Find("Common/Canvas/Right").SetActive(true);
                            GameObject.Find("Common/Canvas/Left").SetActive(true);
                            //GetComponent<Tutorial_Manager>().right.enabled = true;
                            //GetComponent<Tutorial_Manager>().left.enabled = true;

                            GameObject.Find("Common/Canvas/Tutorial").GetComponent<Tutorial_Manager>().Tutorial_Call(0);

                        }


                        if (manual[temp_save - 1].activeSelf)
                        {
                            manual[temp_save - 1].SetActive(false);
                        }
                        else
                        {
                            //GameObject.Find("manual").SetActive(true);
                            string st_1 = StageSelectManager.ST_OWNER_NUMBER.Substring(0, 1);
                            if (st_1 == "1")
                            {
                                GetComponent<Sound_Manager>().Question_SE();
                                Debug.Log("bbbbbbbbbbbbb");


                                manual[temp_save - 1].SetActive(true);
                                GameObject.Find("Common/Canvas/pause_black/Question").SetActive(false);
                                GameObject.Find("Common/Canvas/pause_black/Retry").SetActive(false);
                                GameObject.Find("Common/Canvas/pause_black/Stage_Select").SetActive(false);

                            }
                            else
                            {

                                GameObject.Find("Common/Canvas/Tutorial").GetComponent<Tutorial_Manager>().Tutorial_Call(0);


                            }
                        }




                        //else if(string StageSelectManager.ST_OWNER_NUMBER.Substring"2_1")
                        //{

                        //}

                    }
                    else if (collition2d.gameObject.name == "pause")
                    {
                        if (manual[temp_save - 1].activeSelf)
                        {
                            Debug.Log("ポーズ解除");
                            manual[temp_save - 1].SetActive(false);
                        }
                        pause_freeze_flag = false;
                        //Pauser.Resume ();
                        //時間をもどす
                        Time.timeScale = 1.0f;
                        delay_time = 0.0f;
                        pause_black.gameObject.SetActive(false);
                        string st = StageSelectManager.ST_OWNER_NUMBER.Substring(0, 1);
                        if (st != "1")
                        {
                            GameObject.Find("Common/Canvas/Tutorial").SetActive(false);
                            GameObject.Find("Common/Canvas/Right").SetActive(false);
                            GameObject.Find("Common/Canvas/Left").SetActive(false);

                        }

                        //GetComponent<Tutorial_Manager>().left.enabled = false;

                        image.sprite = ini_sp;

                    }

                }
            }
        }
        if (pause_black.gameObject.activeSelf == false)
        {
            if (info == TouchInfo.Began)
            {

                TouchObjectFind("pause");
                delay_time = 0.0f;
            }
        }

        if (pause_freeze_flag == false)
        {
            if (main_move_state != 0)
            {
                if (info == TouchInfo.Began)
                {
                    transition_flag = true;

                    //test_flag = false;
                    //began_flag = true;
                    //test_flag = false;
                    //_time = 0.0f;
                    startPos = AppUtil.GetTouchWorldPosition(Camera.main);
                    circle.transform.position = (Vector2)AppUtil.GetTouchWorldPosition(Camera.main);
                    circle.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 0);
                    finger_circle.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1, 1, 1);
                    finger_circle.gameObject.transform.position = AppUtil.GetTouchWorldPosition(Camera.main);
                    //						startPos.y, 0);
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = false; ;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().enabled = true;



                    Color color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                    //                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color =
                        new Color(0.0f, 0.0f, 1.0f, 0.0f);

                    Color color_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;
                    //                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color =
                        new Color(0.0f, 0.0f, 1.0f, 0.0f);

                    arrow.transform.localScale = new Vector3(10.0f, 1, 1);
                }
            }


            // 射出していないとき
            if (main_move_state == 0)
            {
                //TouchInfo _info = AppUtil.GetTouch();
                bonus_color_yellow = 0;
                bonus_color_red = 0;
                bonus_nature_change_red = 0;
                bonus_nature_change_yellow = 0;
                //GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                //GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                //GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;



                if (info == TouchInfo.Began)
                {
                    transition_flag = true;
                    touch_time = Time.time;

                    test_flag = false;
                    began_flag = true;
                    test_flag = false;
                    //_time = 0.0f;
                    startPos = AppUtil.GetTouchWorldPosition(Camera.main);
                    circle.GetComponent<SpriteRenderer>().enabled = true;
                    finger_circle.GetComponent<SpriteRenderer>().enabled = true;

                    circle.transform.position = (Vector2)AppUtil.GetTouchWorldPosition(Camera.main);
                    circle.GetComponent<SpriteRenderer>().color = new Color(0, 0, 0, 1);
                    finger_circle.GetComponent<SpriteRenderer>().color = new Color(1.0f, 1, 1, 1);
                    finger_circle.gameObject.transform.position = AppUtil.GetTouchWorldPosition(Camera.main);
                    //						startPos.y, 0);
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().enabled = true;



                    Color color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                    //                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color =
                        new Color(0.0f, 0.0f, 1.0f, 1.0f);

                    Color color_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;
                    //                    Color c_color = circle.GetComponent<SpriteRenderer>().color;
                    GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color =
                        new Color(0.0f, 0.0f, 1.0f, 1.0f);


                    arrow.transform.localScale = new Vector3(10.0f, 1, 1);
                    // スワイプし始めたら状態を移行する



                }
                if (info == TouchInfo.Moved)
                {
                    //押しっぱなしでも必ずびぎゃんを経由させる
                    if (transition_flag == false)
                    {
                        Color big_one = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                        big_one.a = 1.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color = big_one;

                        Color big_one_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;
                        big_one.a = 1.0f;
                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color = big_one;
                        transition_flag = true;

                    }

                    end_flag = false;
                    main_move_state = 1;



                    //if (began_flag == false)
                    //{
                    //    info = TouchInfo.Began;
                    //}
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                    Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                    //Color color_1 = arrow_tri.transform.Find("arrow_tri").gameObject.GetComponent<SpriteRenderer>().color;

                    //                    Color circle_color = circle.GetComponent<SpriteRenderer>().color;
                    movePos = AppUtil.GetTouchWorldPosition(Camera.main);
                    sub = movePos - startPos;
                    Debug.Log(sub.magnitude);
                    arrow.transform.localScale = new Vector3(10.0f, sub.magnitude / 2, .0f);



                    //if(player.GetComponent<Rigidbody2D>().velocity =
                    //{
                    //    diagonal.normalized * force_velocity;

                    //}



                    //player.GetComponent<Rigidbody2D>().velocity =
                    //((sub * speed * force_velocity) * temp * -1) * Time.deltaTime;

                    ////赤矢印パワーの上限
                    //player.GetComponent<Rigidbody2D>().velocity =
                    //((sub * speed * force_velocity) * temp * -1) * Time.deltaTime;
                    //if (player.GetComponent<Rigidbody2D>().velocity.magnitude > force_velocity)
                    //{
                    //    player.GetComponent<Rigidbody2D>().velocity =
                    //        player.GetComponent<Rigidbody2D>().velocity.normalized * force_velocity;

                    //}
                    ;

                    temp = sub.magnitude;

                    //arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);


                    //Shake_Arrow();
                    //Debug.Log(temp);

                    float ang = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg;

                    float angle = ang - 90.0f;
                    if ((int)old_angle == (int)ang)
                    {
                        if (prediction_flag == false)
                        {
                            if (temp > 3.0f)
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

                                //力を固定する45000　予測線
                                //obj_h.GetComponent<Rigidbody2D>().velocity = 
                                //    ((sub * force_velocity) * temp * -1) * Time.deltaTime;

                                //if (obj_h.GetComponent<Rigidbody2D>().velocity.magnitude > force_velocity)

                                //{
                                //    obj_h.GetComponent<Rigidbody2D>().velocity =
                                //        obj_h.GetComponent<Rigidbody2D>().velocity.normalized * force_velocity;
                                //}
                                //obj_h.GetComponent<Rigidbody2D>().AddForce(force_);


                                //obj_h.GetComponent<Rigidbody2D>().velocity = force_;
                            }

                        }
                    }
                    float radius = Vector2.Distance(startPos, movePos);
                    if (radius > MAX_DISTANCE)
                    {
                        float radian = CalcRadian(
                            startPos,
                            movePos
                        );
                        float x = MAX_DISTANCE * Mathf.Cos(radian);
                        float y = MAX_DISTANCE * Mathf.Sin(radian);
                        sub = new Vector2(x, y);
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
                    //if (sub.magnitude > 10.0f)
                    //{
                    //    anime.GetComponent<Animator>().speed = 3.0f;
                    //    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                    //        = new Color(1.0f, 0.0f, 0.0f, 1.0f);

                    //}
                    ////矢印イエロー
                    //else if (sub.magnitude > 9.0f)
                    //{
                    //    anime.GetComponent<Animator>().speed = 2.0f;
                    //    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                    //        = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                    //}
                    ////3より射出パワーが上なら矢印ブルー
                    //else if (sub.magnitude > 3.0f)
                    //{
                    //    anime.GetComponent<Animator>().speed = 2.0f;
                    //    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                    //        = new Color(0.0f, 0.0f, 1.0f, 1.0f);


                    //}
                    //else
                    //{   //射出すらできないパワーの時ブラックカラー矢印
                    //    anime.GetComponent<Animator>().speed = 1.0f;
                    //    GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                    //        = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    //}
                }
            }
            // 画面に触れて矢印が出ているとき
            else if (main_move_state == 1)
            {

                if (info == TouchInfo.Moved)
                {

                    circle.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 1);

                    //if (began_flag == false)
                    //{
                    //    info = TouchInfo.Began;
                    //}
                    if (transition_flag == false)
                    {
                        info = TouchInfo.Began;
                    }
                    anime.gameObject.GetComponent<SpriteRenderer>().enabled = true;

                    Color color = arrow.transform.Find("arrow").gameObject.GetComponent<SpriteRenderer>().color;
                    //Color color_1 = arrow_tri.transform.Find("arrow_tri").gameObject.GetComponent<SpriteRenderer>().color;


                    //                    Color circle_color = circle.GetComponent<SpriteRenderer>().color;
                    movePos = AppUtil.GetTouchWorldPosition(Camera.main);
                    sub = movePos - startPos;
                    //Debug.Log("サブ" + sub.magnitude);

                    //Debug.Log(temp);
                    // ここでdumpをやっている
                    //Debug.Log(startPos);
                    float radius = Vector2.Distance(startPos, movePos);
                    if (radius > MAX_DISTANCE)
                    {
                        float radian = CalcRadian(
                            startPos,
                                           movePos
                                       );
                        float x = MAX_DISTANCE * Mathf.Cos(radian);
                        float y = MAX_DISTANCE * Mathf.Sin(radian);
                        sub = new Vector2(x, y);
                        finger_circle.gameObject.transform.position = new Vector3(startPos.x + x, startPos.y + y, 0);
                    }
                    else
                    {
                        finger_circle.gameObject.transform.position = movePos;
                    }

                    arrow.transform.localScale = new Vector3(10.0f, sub.magnitude / 4.0f, 2.0f);

                    //Shake_Arrow();
                    temp = sub.magnitude;
                    float ang = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg;

                    float angle = ang - 90.0f;
                    if ((int)old_angle == (int)ang)
                    {
                        if (prediction_flag == false)
                        {
                            if (temp > 3.0f)
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

                                //力を固定する45000 予測線の
                                //obj_h.GetComponent<Rigidbody2D>().velocity = 
                                //    ((sub * force_velocity) * temp * -1) * Time.deltaTime;
                                //if (obj_h.GetComponent<Rigidbody2D>().velocity.magnitude > force_velocity)
                                //{
                                //    obj_h.GetComponent<Rigidbody2D>().velocity =
                                //        obj_h.GetComponent<Rigidbody2D>().velocity.normalized * force_velocity;
                                //}
                                ////obj_h.GetComponent<Rigidbody2D>().velocity = new Vector2(100.0f, 0.0f);
                                //                                    .AddForce(force_);
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
                    if (sub.magnitude > 19.5f)
                    {
                        anime.GetComponent<Animator>().speed = 4.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.98f, 0.52f, 0.55f, 1.0f);
                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                          = new Color(0.98f, 0.52f, 0.55f, 1.0f);
                    }
                    //矢印イエロー
                    else if (sub.magnitude > 8.0f)
                    {
                        anime.GetComponent<Animator>().speed = 3.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(1.0f, 0.89f, 0.41f, 1.0f);
                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                           = new Color(1.0f, 0.89f, 0.41f, 1.0f);


                    }
                    //3より射出パワーが上なら矢印ブルー
                    else if (sub.magnitude > 3.0f)
                    {
                        anime.GetComponent<Animator>().speed = 2.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.51f, 0.54f, 1.0f, 1.0f);
                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                           = new Color(0.51f, 0.54f, 1.0f, 1.0f);



                    }
                    else
                    {
                        //射出すらできないパワーの時ブラックカラー矢印
                        anime.GetComponent<Animator>().speed = 1.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                           = new Color(0.0f, 0.0f, 0.0f, 1.0f);
                    }

                    Shake_Arrow();
                }


                if (true)
                {
                    Debug.Log("################");

                    if (info == TouchInfo.Ended)
                    {
                        //0.5より小さいと射出されない
                        touch_time = Time.time - touch_time;
                        Debug.Log(touch_time);

                        if (touch_time < 0.3f)
                        {
                            //number_count += 1;
                            end_flag = true;
                            anime.GetComponent<Animator>().speed = 1.0f;
                            //arrow.GetComponent<SpriteRenderer>().enabled = false;
                            Color color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                            GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                                = new Color(color.r, color.g, color.b, 0.0f);

                            Color color_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;
                            GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                                = new Color(color.r, color.g, color.b, 0.0f);

                            GameObject.Find("Player/player_motion").GetComponent<SpriteRenderer>().enabled = false;

                            flag = true;
                            endPos = AppUtil.GetTouchWorldPosition(Camera.main);
                            Vector2 a = endPos - startPos;
                            //Debug.Log(a.magnitude);
                            temp = 0;
                            temp = a.magnitude;
                            //if (temp > 12.0f)
                            //{
                            //    temp = 12.0f;
                            //}
                            //スワイプの長さの値を変えれる
                            //player.GetComponent<Rigidbody2D>().AddForce(force_);

                            temp = sub.magnitude;

                            color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                            color_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;


                            //プレイヤーのアドフォースから　ベロシティマグ二で引っ張る強さを計算している
                            color.a = 1.0f;
                            sub = new Vector2(0.0f, 0.0f);

                        }
                        //else if(touch_time < 5.0f)
                        //{

                        //}

                        finger_circle.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0, 0, 0);
                        circle.GetComponent<SpriteRenderer>().color = new Color(0.0f, 0, 0, 0);
                        //デバッグログ　射出時のパワーを測る
                        //bonus_color_red = 0;
                        began_flag = false;
                        end_time = 0.0f;
                        bonus_color_red = 0.0f;
                        bonus_color_yellow = 0.0f;
                        color = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                        Color color_2 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;

                        //射出すらできないパワーの時ブラックカラー矢印を消す
                        anime.GetComponent<Animator>().speed = 1.0f;
                        GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                            = new Color(0.0f, 0.0f, 0.0f, 0.0f);

                        GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                           = new Color(0.0f, 0.0f, 0.0f, 0.0f);


                        //速度が３まで低下したら次のWAVEにいく
                        if (sub.magnitude > 3.0f)
                        {
                            number_count += 1;
                            end_flag = true;
                            anime.GetComponent<Animator>().speed = 1.0f;
                            //arrow.GetComponent<SpriteRenderer>().enabled = false;
                            Color color_end = GameObject.Find("arrow").GetComponent<SpriteRenderer>().color;
                            GameObject.Find("arrow").GetComponent<SpriteRenderer>().color
                                = new Color(color.r, color.g, color.b, 0.0f);

                            Color color_end_1 = GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color;
                            GameObject.Find("arrow_tri").GetComponent<SpriteRenderer>().color
                                = new Color(color.r, color.g, color.b, 0.0f);
                            GameObject.Find("Player/player_motion").GetComponent<SpriteRenderer>().enabled = false;

                            flag = true;
                            endPos = AppUtil.GetTouchWorldPosition(Camera.main);
                            //Debug.Log(a.magnitude);
                            //if (temp > 12.0f)
                            //{
                            //    temp = 12.0f;
                            //}
                            //スワイプの長さの値を変えれる
                            //player.GetComponent<Rigidbody2D>().AddForce(force_);

                            temp = sub.magnitude;
                            //サブまぐにの色数値
                            ////temp = 19.5f - 3.83333f * 2.0f;

                            //カラーいじる矢印
                            //color = new Color(1.0f, 1.0f, 0.0f, 1.0f);

                            //プレイヤーのアドフォースから　ベロシティマグ二で引っ張る強さを計算している
                            color.a = 1.0f;
                            Debug.Log(color);


                            if (color == new Color(0.51f, 0.54f, 1.0f, 1.0f))
                            {
                                //青の強
                                if (temp > 8.0f - 1.66667f)
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                         ((sub.normalized * blue_speed * force_velocity) * temp * -1) * 0.016f;
                                }//青の中
                                else if (temp > 8.0f - 1.66667f * 2.0f)
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                         ((sub.normalized * blue_speed * force_velocity) * temp * -1) * 0.016f;/* 
                                                                                                         * タイムかけてしまうとPCのCPUによって経過時間がかわるのでNG * Time.deltaTime;*/
                                }//青の小
                                else
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                         ((sub.normalized * blue_speed * force_velocity) * temp * -1) * 0.01f/* 
                                                                                                         * タイムかけてしまうとPCのCPUによって経過時間がかわるのでNG * Time.deltaTime;*/;

                                }

                                //青の矢印の上限
                                if (player.GetComponent<Rigidbody2D>().velocity.magnitude > 30)
                                {
                                    player.GetComponent<Rigidbody2D>().velocity =
                                        player.GetComponent<Rigidbody2D>().velocity.normalized * 30;
                                }

                            }

                            //プレイヤーのアドフォースから　ベロシティマグ二で引っ張る強さを計算している
                            else if (color == new Color(1.0f, 0.89f, 0.41f, 1.0f))
                            {
                                if (temp > 19.5f - 3.83333f)
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                     ((sub.normalized * yellow_speed * force_velocity) * temp * -1) * 0.018f/** Time.deltaTime;*/;
                                }


                                else if (temp > 19.5 - 3.83333f * 2)
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                    ((sub.normalized * yellow_speed * force_velocity) * temp * -1) * 0.017f/** Time.deltaTime;*/;
                                }
                                else
                                {
                                    GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity =
                                    ((sub.normalized * yellow_speed * force_velocity) * temp * -1) * 0.022f/** Time.deltaTime;*/;
                                }



                                //黄色の矢印の上限
                                if (player.GetComponent<Rigidbody2D>().velocity.magnitude > 102.5f)
                                {
                                    player.GetComponent<Rigidbody2D>().velocity =
                                      player.GetComponent<Rigidbody2D>().velocity.normalized * 102.5f;

                                }



                                if (player.GetComponent<Rigidbody2D>().velocity.magnitude < 65)
                                {
                                    bonus_nature_change_yellow = 1;
                                }
                                else
                                {
                                    bonus_nature_change_yellow = 0;
                                }
                            }
                            else
                            {
                                //赤矢印パワーの上限
                                player.GetComponent<Rigidbody2D>().velocity =
                                    ((sub * speed * force_velocity) * temp * -1) * 1.0f /* Time.deltaTime;*/ ;
                                if (player.GetComponent<Rigidbody2D>().velocity.magnitude > force_velocity)
                                {
                                    player.GetComponent<Rigidbody2D>().velocity =
                                        player.GetComponent<Rigidbody2D>().velocity.normalized * force_velocity;

                                }
                                if (player.GetComponent<Rigidbody2D>().velocity.magnitude < 200)
                                {
                                    bonus_nature_change_red = 1;
                                }
                                else
                                {
                                    bonus_nature_change_red = 0;
                                }
                            }

                            //blue_speed = 2.0f;
                            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(blue_speed, 0.0f);




                            //プレイヤーのアドフォースから　ベロシティマグ二で引っ張る強さを計算している
                            //else if (GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled == false)
                            //{
                            //    player.GetComponent<Rigidbody2D>().velocity =
                            //        ((sub * speed * force_velocity) * temp * -1) * Time.deltaTime;
                            //    if (player.GetComponent<Rigidbody2D>().velocity.magnitude > force_velocity)
                            //    {
                            //        player.GetComponent<Rigidbody2D>().velocity =
                            //            player.GetComponent<Rigidbody2D>().velocity.normalized * force_velocity;
                            //    }
                            //}


                            //player.GetComponent<Rigidbody2D>().velocity = new Vector2(100.0f, 0.0f);




                        }
                        GameObject[] aa = GameObject.FindGameObjectsWithTag("semi");
                        if (GameObject.FindGameObjectsWithTag("semi") != null)
                        {
                            foreach (GameObject _obj in aa)
                            {
                                Destroy(_obj);
                            }
                        }
                        //Color c_color = circle.GetComponent<SpriteRenderer>().color;
                        //circle.GetComponent<SpriteRenderer>().color = new Color(c_color.r, c_color.g, c_color.b, 0.0f);


                    }

                    // 画面から指を離したら状態を移行
                    if (end_flag)
                    {
                        main_move_state = 2;
                    }
                }
            }
            // 打ち出した後
            else if (main_move_state == 2)
            {
                if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= attenuation_speed)
                {

                    //光の種　体力減少
                    GameObject[] seed;
                    seed = GameObject.FindGameObjectsWithTag("BlockPiece");
                    foreach (GameObject obs in seed)
                    {
                        obs.GetComponent<Seed_Life>().Seed_Life_Down();

                    }
                    //射出性質変化 小のとき青のオーラをまとう
                    //GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                    player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
                    //state_move_flag = true;
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
        if (main_move_state == 2)
        {
            //if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > nature_change_blue &&

            bonus_color_red += Time.deltaTime;
            bonus_color_yellow += Time.deltaTime;
            //Debug.Log("ネイチャーチェンジの値:" + bonus_nature_change);

            if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < nature_change_blue)
            {
                //射出性質変化 赤黄のオーラを消し青のオーラを発生
                if (bonus_nature_change_yellow == 1 && bonus_color_yellow < CHANGE_COLOR_DELAY_COUNT)
                {
                    characteristic_change_state = 2;
                    Debug.Log("ftftfytfyguh");
                    //Debug.Log(bonus_color);
                    GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                    foreach (GameObject obs in small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }
                    foreach (GameObject obs in blue_small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }


                }
                else
                {
                    characteristic_change_state = 1;
                    GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;

                    GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = true;
                    foreach (GameObject obs in small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }
                    foreach (GameObject obs in blue_small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }

                }
            }
            else if (GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude > nature_change_blue &&
                GameObject.Find("Player").GetComponent<Rigidbody2D>().velocity.magnitude < nature_change_yellow)
            {
                //赤の最弱で放った時に○○秒赤の性質変化を保持する。
                //射出性質変化 青黄オーラを消し赤のオーラを発生
                //Debug.Log(bonus_color);
                if (bonus_nature_change_red == 1 && bonus_color_red < CHANGE_COLOR_DELAY_COUNT)
                {
                    characteristic_change_state = 3;
                    Debug.Log("ftftfytfyguh");
                    //Debug.Log(bonus_color);
                    GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;
                    foreach (GameObject obs in small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = true;
                    }
                    foreach (GameObject obs in blue_small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = true;
                    }

                }
                else
                {
                    GameObject.Find("Player/player_difference/RED").GetComponent<SpriteRenderer>().enabled = false;
                    GameObject.Find("Player/player_difference/YELLOW").GetComponent<SpriteRenderer>().enabled = true;
                    GameObject.Find("Player/player_difference/BLUE").GetComponent<SpriteRenderer>().enabled = false;

                    characteristic_change_state = 2;
                    //射出性質変化 赤青オーラを消し黄のオーラを発生
                    foreach (GameObject obs in small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }
                    foreach (GameObject obs in blue_small)
                    {
                        obs.GetComponent<Collider2D>().isTrigger = false;
                    }

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
                blue_small = GameObject.FindGameObjectsWithTag("Blue_Block");
                foreach (GameObject obs in small)
                {
                    obs.GetComponent<Collider2D>().isTrigger = true;
                }
                foreach (GameObject obs in blue_small)
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
            { //ポーズカウントは1で初期化している
                pause_count += 1;
                //偶数時がポーズ
                if (pause_count % 2 == 0)
                {

                    //Pauser.Resume();
                    //時間を止める
                    Time.timeScale = 0.0f;

                    if (pause_se_flag == false)
                    {
                        pause_se_flag = true;
                        GetComponent<Sound_Manager>().SE();


                        GameObject.Find("Common/Canvas/pause_black/Retry").SetActive(true);
                        GameObject.Find("Common/Canvas/pause_black/Stage_Select").SetActive(true);
                        GameObject.Find("Common/Canvas/pause_black/Question").SetActive(true);


                    }

                    pause_freeze_flag = true;

                    //Pauser.Pause();
                    //Color pause_color = new Color(0, 0, 0, 0);
                    pause_black.gameObject.SetActive(true);
                    //Color pause_ = pause_black.gameObject.GetComponent<Image>().color;
                    //pause_black.GetComponent<Image>().color = 
                    //    new Color(pause_color.r, pause_color.g, pause_color.b, 0.7f);
                    //GameObject.Find("Retry").GetComponent<Image>().enabled = true;
                    //GameObject.Find("Select").GetComponent<Image>().enabled = true;
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
        if (sub.magnitude >= 19.5f)
        {
            //Debug.Log("aaaa");
            hold = new Vector2(float.MaxValue, float.MaxValue);
            Vector2 pos = arrow.transform.position;
            //Vector2 pos_tri = arrow_tri.transform.position;
            if (shake_state == 0)
            {
                hold = arrow.transform.position;
                //hold = arrow_tri.transform.position;

                //矢印揺れるスピード
                arrow_shake += 0.08f;
                pos.x += Random.Range(-0.5f, 0.5f);
                pos.y += arrow_shake;

                //arrow_tri_shake += 0.08f;
                //pos_tri.x += Random.Range(-0.5f, 0.5f);
                //pos_tri.y += arrow_tri_shake;
                if (arrow_shake > 0.3f)
                {
                    shake_state = 1;
                    arrow_shake = 0.0f;
                    //arrow_tri_shake = 0;
                }
                arrow.transform.position = pos;
            }
            else if (shake_state == 1)
            {
                hold = arrow.transform.position;
                //hold = arrow_tri.transform.position;


                arrow_shake += 0.08f;
                pos.x += Random.Range(-0.25f, 0.25f);
                pos.y -= arrow_shake;

                //arrow_tri_shake += 0.08f;
                //pos_tri.x += Random.Range(-0.5f, 0.5f);
                //pos_tri.y -= arrow_shake;
                if (arrow_shake > 0.3f)
                {
                    shake_state = 0;
                    arrow_shake = 0.0f;
                    //arrow_tri_shake = 0.0f;
                }
                arrow.transform.position = pos;
                //arrow_tri.transform.position = pos_tri;

            }

        }
    }

    //    void TouchObjectSearch(string name)
    //    {
    //        Vector2 point = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    //        Collider2D collition2d = Physics2D.OverlapPoint(point);
    //
    //        if (collition2d != null)
    //        {
    //            if (collition2d.gameObject.name == name)
    //            {
    //                    Debug.Log("aaa");
    //                    if(name == "pause")
    //                    {
    //                        if (retry_obj.gameObject.activeSelf == false)
    //                        {
    //                            retry_obj.SetActive(true);
    //                        }
    //                    }
    //                       
    //            }
    //        }
    //
    //    }
}
