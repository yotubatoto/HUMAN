using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Save_Load : MonoBehaviour
{
    static public bool Save(string key, int i)
    {
        PlayerPrefs.SetInt(key, i);
        return true;
    }

    static public int Load(string key)
    {
        return PlayerPrefs.GetInt(key);
    }
}
