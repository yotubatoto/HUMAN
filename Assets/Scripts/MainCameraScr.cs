using UnityEngine;
using System.Collections;

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
		//int st = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerScr>().m_move_st;
		//if (st == 1 || st == 3) {
        if (touch_freeze_flag == false)
        {
			//if (Input.GetMouseButton(0))
			//{
			//    // タップしている間
			//    // マウスのスクリーン座標取得
			//    Vector3 mouse_screen_pos = Input.mousePosition;
			//    mouse_screen_pos.z = transform.position.z - Camera.main.transform.position.z;
			//    // マウスのワールド座標取得
			//    Vector3 mouse_world_pos = Camera.main.ScreenToWorldPoint(mouse_screen_pos);
			//    //// カメラは追いかける
			//    //Vector3 vec = (mouse_world_pos - transform.position).normalized;
			//    //vec *= 0.05f;
			//    //transform.position += new Vector3(vec.x, vec.y, 0.0f);
			//}
			if (player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f)
			{
                player.GetComponent<Rigidbody2D>().velocity = new Vector2(0,0);
				flag = false;
			}
            if(end_flag == true && player.GetComponent<Rigidbody2D>().velocity.magnitude <= 0.1f && GetComponent<Manager>().wave_flag == false)
            {
                state_move_flag = true;
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
					float ang = Mathf.Atan2(sub.y, sub.x) * Mathf.Rad2Deg;
					float angle = ang - 90.0f;
					player.transform.eulerAngles = new Vector3(0, 0, 180 + angle);
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
					player.GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
					player.GetComponent<Rigidbody2D>().AddForce((a.normalized * 900.0f) * temp * -1);
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
