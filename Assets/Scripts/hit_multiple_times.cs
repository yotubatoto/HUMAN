using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hit_multiple_times : MonoBehaviour
{
    public int hit_count = 0;
    public int number = 0;
    public int break_count = 0;
    public Sprite[] block_sprite = new Sprite[2];
    public GameObject fireworks_prefab;
    private GameObject obj;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    private void OnCollisionEnter2D(Collision2D coll)
    {
        if(coll.gameObject.tag == "Player")
        {
            number += 1;
            break_count += 1;

            if(number == 2)
            {
                number = 0;
            }

            if(break_count == 2)
            {
                Destroy(gameObject);
            }

            obj = Instantiate(fireworks_prefab, transform.position, Quaternion.identity);
            gameObject.GetComponent<SpriteRenderer>().sprite = block_sprite[number];
        }
    }
}
