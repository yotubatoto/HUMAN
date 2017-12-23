using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class GridTest : MonoBehaviour
{
    public float width = 10.0f;
    public float height = 10.0f;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmos()
    {
        Vector3 pos = new Vector3(0.0f, 0.0f, 89.0f);

        for (float y = pos.y - 5000.0f; y < pos.y + 5000.0f; y += height)
        {
            Gizmos.DrawLine(new Vector3(-100000.0f, y, pos.z),
            new Vector3(100000.0f, y, pos.z));
        }

        for (float x = pos.x - 5000.0f; x < pos.x + 5000.0f; x += width)
        {
            Gizmos.DrawLine(new Vector3(x, -100000.0f, pos.z),
            new Vector3(x, 100000.0f, pos.z));
        }
    }
}
 