using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Exit game function, link to the exit button in start scenes
 */

public class ExitGame : MonoBehaviour
{

    public void QuitGame()
    {

    #if UNITY_EDITOR

    UnityEditor.EditorApplication.isPlaying = false;

    #else

    Application.Quit();

    #endif

    }

}
