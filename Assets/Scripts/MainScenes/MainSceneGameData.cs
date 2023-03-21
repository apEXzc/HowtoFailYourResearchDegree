using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

/*
 * Keep the data in this Scene, avoid destory
 */

public class MainSceneGameData : MonoBehaviour
{
    public static MainSceneGameData Instance { get; private set; }
    public int thesisNumber { get; set; } = 0;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
