using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stage : MonoBehaviour
{
    public string stage_name_all_clear;
    public List<string> stage_name_clear = new List<string>();
    int all_clear_flag = 0;
    public List<int> clear_flag = new List<int>();
    public int stage_nmber = 0;
    private int total_count = 0;
    public string total_count_stage_name;
    // Use this for initialization
    void Start ()
    {
        //// ステージ全体
        //all_clear_flag = Save_Load.Load(stage_name_all_clear);
        //if(all_clear_flag == 1)
        //{
        //    // 透過処理
        //    // タッチきかなくする処理
        //}

        //// ステージにぶら下がっているやつ(1-1とか)
        //for(int i=0;i<stage_nmber;i++)
        //{
        //    clear_flag.Add(Save_Load.Load(stage_name_clear[i]));
        //    if(clear_flag[i] == 1)
        //    {
        //        // 透過処理
        //        // タッチきかなくする処理
        //    }

        //    // 総レジン数を読み込みする
        //    total_count = Save_Load.Load(total_count_stage_name);
        //}
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
