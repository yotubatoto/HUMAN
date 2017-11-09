using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour {

	// Use this for initialization
	private AudioSource m_audio;
    public AudioClip enemy_coll_se;
    public AudioClip resin_coll_se;
    public AudioClip item_up_coll_se;
    public AudioClip gimic_coll_se;


    void Start ()
    {
		m_audio = gameObject.GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update ()
    {
    }
	public void SE()
	{
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(enemy_coll_se);
	}
    public void Resin_SE()
    {
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(resin_coll_se);
    }
    public void Item_UP_SE()
    {
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(item_up_coll_se);
    }
    public void Gimic_SE()
    {
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(gimic_coll_se);
    }
}
