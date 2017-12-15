using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
	// 変数宣言
	public int m_scene;
	int m_past_scene;
	public int m_score;
	public int m_white_score;
	public int m_gold_score;
	public int m_black_score;

	public AudioClip m_se_start;
	public AudioSource m_se_source;

	private int m_cnt;
	Color m_color;
	public GameObject filterWhite;
    public GameObject now_loading;
    public GameObject title;
    public Text a;
	private float al;
	private Image tap;
	private int state = 0;
    public float tap_speed;
    public float title_count = 0.0f;
	/* --------------------------------------------------
	 * @パラメータ初期化
	*/
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
	void Start()
	{
        //マルチタッチ無効
        Input.multiTouchEnabled = false;
		// パラメータ初期化
		m_scene = 0;
		m_past_scene = 0;
		m_white_score = 0;
		m_gold_score = 0;
		m_black_score = 0;
		m_cnt = 0;
		al = 0;
		// 
		tap = GameObject.Find("Tap").gameObject.GetComponent<Image>();
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update()
	{
        //実機の場合のみ○○秒連打防止
#if !UNITY_EDITOR
        title_count += Time.deltaTime;
        if (title_count < 1.0f)
            return;
#endif
        //マルチタッチ無効
        Input.multiTouchEnabled = false;

        // エスケープキー取得
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            // アプリケーション終了
            Application.Quit();
            return;
        }
        // ----------------------
        //タップトゥスタートの透明、不透明　値など
        state = _Utility.Flashing(tap, tap_speed, state);

        // ------------------------------
        // シーン遷移
        // ------------------------------
        if (m_scene == 0)
        {
            // マウスをクリックしたならば
            if (Input.GetMouseButtonUp(0))
            {
                    
                // SE再生
                if (m_se_source.isPlaying == false)
                {

                    m_se_source.clip = m_se_start;
                    m_se_source.Play();
                    m_se_source.loop = false;
                }
                GameObject.Find("GameMain").GetComponent<Now_Loading>().Load_NextScene_Des();
                //GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color 
                //    = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                //GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().sortingOrder = 10000;
                now_loading.GetComponent<Image>().enabled = true;
                // 次のシーンへ
                m_scene = 1;

            }

        }
        else if (m_scene == 1)
        {

        }
    }

      
}
