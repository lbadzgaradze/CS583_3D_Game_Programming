using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class UI_Singleton : MonoBehaviour
{
    private static UI_Singleton instance = null;

    public static UI_Singleton Instance
    {
        get { return instance; }

    }


    public void Awake()
    {
        if (instance == null)
        {
            DontDestroyOnLoad(this);
            instance = this;
        }
        else
        {
            if (instance != this)
            {
                Destroy(gameObject);
            }
        }
    }
}
