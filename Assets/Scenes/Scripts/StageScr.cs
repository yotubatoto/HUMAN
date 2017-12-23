using UnityEngine;
using System.Collections;

public class StageScr : MonoBehaviour {
    public GameObject stage_select;
    public float speed = 2;
    Vector2 vec; 


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
		// 現在座標の取得
		Vector3 pos = transform.position;
     
		// カメラ座標の取得
		Vector3 cam_pos = GameObject.FindWithTag ("MainCamera").transform.position;

		// 手前
		transform.Find ("Belt_001").transform.position = new Vector3(cam_pos.x * -3.0f, pos.y, pos.z);
		// 中間
		transform.Find ("Belt_002").transform.position = new Vector3(cam_pos.x * -1.0f, pos.y, pos.z);
		// 奥
		transform.Find ("Belt_003").transform.position = new Vector3(cam_pos.x * -0.75f, pos.y, pos.z);
		transform.Find ("Belt_004").transform.position = new Vector3(cam_pos.x * -0.75f, pos.y, pos.z);
		transform.Find ("Belt_005").transform.position = new Vector3(cam_pos.x * -0.25f, pos.y, pos.z);
		transform.Find ("Belt_006").transform.position = new Vector3(cam_pos.x * 0.1f, pos.y, pos.z);
		transform.Find ("Belt_007").transform.position = new Vector3(cam_pos.x * 0.2f, pos.y, pos.z);
		// 最奥
		transform.Find ("Belt_008").transform.position = new Vector3(cam_pos.x * 0.2f, pos.y, pos.z);
		transform.Find ("Belt_009").transform.position = new Vector3(cam_pos.x * 0.2f, pos.y, pos.z);
		transform.Find ("Belt_010").transform.position = new Vector3(cam_pos.x * 0.2f, pos.y, pos.z);
	}
}
