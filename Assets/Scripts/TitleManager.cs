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
	/* --------------------------------------------------
	 * @パラメータ初期化
	*/
	void Start()
	{

		// パラメータ初期化
		m_scene = 0;
		m_past_scene = 0;
		m_white_score = 0;
		m_gold_score = 0;
		m_black_score = 0;
		m_cnt = 0;
		al = 0;
		// 
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update()
	{

		// ----------------------
		// ※デバック※
		// ----------------------
		if (Input.GetKey(KeyCode.Space))
		{
			m_score++;
		}
		else if (Input.GetKey(KeyCode.R))
		{
			m_score = 0;
		}
		// ----------------------

		// 
		Vector3 c_pos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		transform.position = new Vector3(c_pos.x, c_pos.y, 0.0f);

		// ------------------------------
		// シーン遷移
		// ------------------------------
		if (m_scene == 0)
		{

			// タイトル

			// カウントの加算
			m_cnt++;
			if (m_cnt > 120)
			{
				m_cnt = 0;
			}

			// タップスタートの点滅
			if (m_cnt < 60)
			{
				Color cl = transform.Find("TapStart").GetComponent<SpriteRenderer>().color;
				cl.a = 1.0f;
				transform.Find("TapStart").GetComponent<SpriteRenderer>().color = cl;
			}
			else
			{
				Color cl = transform.Find("TapStart").GetComponent<SpriteRenderer>().color;
				cl.a = 0.0f;
				transform.Find("TapStart").GetComponent<SpriteRenderer>().color = cl;
			}

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
                GameObject.Find("GameMain").GetComponent<Now_Loading>().Load_NextScene_Title();
                //GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().color 
                //    = new Color(1.0f, 1.0f, 1.0f, 1.0f);
                //GameObject.Find("Now_Loading").GetComponent<SpriteRenderer>().sortingOrder = 10000;
                GameObject.Find("Canvas/Now_Loading").GetComponent<Image>().enabled = true;
                GameObject.Find("Canvas/title").GetComponent<Image>().color = new Color(0.0f, 0.0f, 0.0f, 0.0f);
                GameObject.Find("Canvas/tap start").GetComponent<Text>().enabled = false;



 
				//
				m_color = transform.Find("TitleLogo").GetComponent<SpriteRenderer>().color;
                
				GameObject obj = transform.Find("TapStart").gameObject;
				Destroy(obj);

				

				// 次のシーンへ
				m_scene = 1;
               
			}

		}
		else if (m_scene == 1)
		{

            
            // タップスタートの非表示
			// メインシーン導入

			// カウントの加算
			m_cnt++;

			// 
			m_color.a = 1.0f - ((float)m_cnt / 300.0f);
			transform.Find("TitleLogo").GetComponent<SpriteRenderer>().color = m_color;

			// 次のステージへ
			if (m_cnt > 200)
			{
				filterWhite.GetComponent<Image>().color = new Color(1, 1, 1, al += 0.01f);
				if (al >= 1)
				{
					SceneManager.LoadScene("StageSelect_Scene");
                   
				}
				Debug.Log(al);
			}

		}
	}
}
