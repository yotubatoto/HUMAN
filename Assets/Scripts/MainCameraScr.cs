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
    public bool end_flag = false;
    public bool state_move_flag = false;
    public GameObject semitransparentPrefab;
    private bool prediction_flag = false;
    private GameObject obj = null;
    private int time = 0;
    private float old_angle = 0.0f;
	private Vector2 force_ = Vector2.zero;
	//public Text debug_test;
    /* --------------------------------------------------
	 * @パラメータ初期化
	*/
    void Start () {
		Application.targetFrameRate = 60;
		Camera.main.orthographicSize = 25.0f;
	}



	/* --------------------------------------------------
	 * @毎フレーム更新
	*/
	void Update ()
	{
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

        if (touch_freeze_flag == false)
        {
	
			if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.8f)
			{
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
				flag = false;
			}
            if(end_flag == true && player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f && GetComponent<Manager>().wave_flag == false)
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
					Color color = arrow.GetComponent<SpriteRenderer>().color;
                    arrow.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);
                    arrow.transform.localScale = new Vector3(1,1, 1);

				}
				if (info == TouchInfo.Moved)
				{
                    Color color = arrow.GetComponent<SpriteRenderer>().color;

                    arrow.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 1.0f);
					movePos = AppUtil.GetTouchWorldPosition(Camera.main);
					Vector2 sub = movePos - startPos;
                    // sub.magn大きさ　と　arrowのサイズをいい感じに比例させる
                    // 数値を最大値で悪と0~1の間になる
                    float testes = sub.magnitude;
                    if (testes > 12)
                        testes = 12.0f;
                    testes = (testes) / 12;
                    arrow.transform.localScale = new Vector3(testes+0.5f, testes+0.5f, 1.0f);

                    //if (sub == Vector2.zero)
                    //{
                    //    info = TouchInfo.None;
                    //    arrow.GetComponent<SpriteRenderer>().enabled = false;

                    //}
                    float temp = sub.magnitude;
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
                                    foreach(GameObject _obj in a)
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
                    if(test > 1.1f || test < -1.1f)
                    {
                        prediction_flag = false;
                    }
                    player.transform.eulerAngles = new Vector3(0, 0, 180 + angle);

                    old_angle = ang;
                }
				if (info == TouchInfo.Ended)
                {
                    end_flag = true;
                    //arrow.GetComponent<SpriteRenderer>().enabled = false;
                    Color color = arrow.GetComponent<SpriteRenderer>().color;
                    arrow.GetComponent<SpriteRenderer>().color = new Color(color.r, color.g, color.b, 0.0f);
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
			}
            //// カメラは追いかける
            //Vector3 vec = (player.transform.position - transform.position).normalized;
            //vec *= 1.0f;
            //transform.position += new Vector3(vec.x, vec.y, 0.0f);
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
}
