using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMusic : MonoBehaviour
{


    void Awake()
    {
        GameObject[] musicObject = GameObject.FindGameObjectsWithTag("Music");
        if (musicObject.Length > 1)
        { Destroy(gameObject); }


        DontDestroyOnLoad(this.gameObject);

    }
}