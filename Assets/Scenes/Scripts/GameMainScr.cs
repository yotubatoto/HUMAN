using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GameMainScr : MonoBehaviour {

	// 定数宣言
	public int SCORE_MAX = 50;

	// 変数宣言
	int m_cnt;
	// BGM
	public AudioClip m_se_start;
	AudioSource m_se_source;
	// ステージロゴ
	public Sprite m_stage_logo_1;

	// テキスト
	public Text m_text_1;
	public Text m_text_2;
	public Text m_text_3;
	public int m_scene = 0;
	/* --------------------------------------------------
	 * @パラメータ初期化
	*/
	void Start () {
	
		// パラメータ初期化
		m_cnt = 0;

		AudioSource[] audio_sources = gameObject.GetComponents<AudioSource> ();
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update () {

		// 
		Vector3 c_pos = GameObject.FindGameObjectWithTag("MainCamera").transform.position;
		transform.position = new Vector3 (c_pos.x, c_pos.y, 0.0f);

		// ------------------------------
		// シーン遷移
		// ------------------------------
		if (m_scene == 0) {

			// タイトル

			// カウントの加算
			m_cnt++;
			if (m_cnt > 120) {
				m_cnt = 0;
			}

			// マウスをクリックしたならば
			if (Input.GetMouseButtonUp (0)) 
			{

				//// SE再生
				//m_se_source.clip = m_se_start;
				//if (m_se_source.isPlaying == false) {
				//	m_se_source.Play ();
				//}

				// 次のシーンへ
				m_scene = 1;
			}

		} else if (m_scene == 1) {

			// メインシーン導入

			// カウントの加算
			m_cnt++;

			// 次のステージへ
			if (m_cnt > 300) {
				m_cnt = 0;
			}
		
		} 

	}
}
