using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeCamera : MonoBehaviour
{   //減衰の戻るスピード
    public float shake_decay = 0.002f;
    //ふり幅とか時間
    public float coef_shake_intensity = 0.3f;
    private Vector3 originPosition;
    private Quaternion originRotation;
    private float shake_intensity;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (shake_intensity > 0)
        {
            transform.position = originPosition + Random.insideUnitSphere * shake_intensity;
            transform.rotation = new Quaternion(
            originRotation.x,
            originRotation.y + Random.Range(-shake_intensity, shake_intensity) * 0.25f,
            originRotation.z,
            originRotation.w);
            shake_intensity -= shake_decay;

        }

    }
    public void Shake()
    {
        originPosition = transform.position;
        originRotation = transform.rotation;
        shake_intensity = coef_shake_intensity;
    }
}
//    void OnCollisionEnter2D(Collision2D coll)
//    {
//        if (coll.gameObject.tag == "Enemy")
//        {
//            Shake();
//        }

//    }
//}