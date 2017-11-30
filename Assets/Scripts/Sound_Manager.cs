using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound_Manager : MonoBehaviour {

	// Use this for initialization
	private AudioSource m_audio;
    public AudioClip enemy_coll_se;
    public AudioClip resin_coll_se;
    public AudioClip block_coll_se;
    public AudioClip gimic_coll_se;
    public AudioClip choice_coll_se;
    public AudioClip decision_coll_se;
    public AudioClip pause_coll_se;
    public AudioClip obstance_coll_se;




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
    public void Block_Second_SE()
    {
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(block_coll_se);
    }
    public void Gimic_SE()
    {
        //m_audio.volume = 0.05f;
        m_audio.PlayOneShot(gimic_coll_se);
    }
    public void Stage_Choice_SE()
    {
        m_audio.PlayOneShot(choice_coll_se);

    }
    public void Decision_SE()
    {
        m_audio.PlayOneShot(decision_coll_se);

    }
    public void pause_SE()
    {
        m_audio.PlayOneShot(pause_coll_se);

    }
    public void Obstance_SE()
    {
        m_audio.PlayOneShot(obstance_coll_se);

    }
}
