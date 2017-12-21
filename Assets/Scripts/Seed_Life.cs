using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seed_Life : MonoBehaviour {

    //インスペクターからいじれるように
    //基本プログラム上ではいじらないこと！

    //ライフ
    public int MAXLIFE = 3;
    //初期サイズ
    public float MAXSIZE = 2.0f;
    //小さくなるまでの時間(１で1秒)
    public float MOVETIME = 1;

    private int life_seed;
    private float effect_scale;
    private float target_scale;
    private float now_movetime;
    private float between_scale;
    private int effect_state = 0;
    private float c = 1.0f;
	// Use this for initialization
	void Start () 
    {
        life_seed = MAXLIFE;
        transform.localScale = new Vector3(MAXSIZE, MAXSIZE, MAXSIZE);
        effect_scale = MAXSIZE;
        target_scale = effect_scale;
        between_scale = 0.0f;
        now_movetime = 0.0f;

    }
	
	// Update is called once per frame
	void Update () 
    {
        ParticleSystem.ColorOverLifetimeModule par = GetComponent<ParticleSystem>().colorOverLifetime;
        float temp = (transform.localScale.x * 1.0f) / 2.0f;
        par.color = new Color(temp, temp, temp);
        Debug.Log(temp);
        if (effect_state == 1){

            
            float deltatime = Time.deltaTime;
            now_movetime += deltatime;

            //（仮定として）１ミリ秒あたりの移動量　＝　（今の大きさ　－　ターゲット大きさ） / 秒数
            //間のミリ秒 * 移動量　＝　このフレームの移動量
            effect_scale -= (between_scale / MOVETIME) * deltatime;

            transform.localScale = new Vector3(effect_scale, effect_scale, effect_scale);

            if (now_movetime >= MOVETIME) {
                effect_state = 0;
            }
            if (effect_scale <= 0.0f) { Destroy(gameObject); }
        //effect_scale -= 1.0f;
        //transform.localScale = new Vector3(effect_scale, effect_scale, effect_scale);
		}

	}

    public void Seed_Life_Down()
    {

        if (life_seed > 0) { life_seed -= 1; }
        
            if(effect_state == 0){ effect_state = 1; }

            //どこまで小さくしたいか
            //初期サイズ　＊　（現在のライフ　/ 最大ライフ）
            target_scale = MAXSIZE * ((float)life_seed / (float)MAXLIFE);

            //間のサイズ
            between_scale = effect_scale - target_scale;
            now_movetime = 0.0f;

    }
}
