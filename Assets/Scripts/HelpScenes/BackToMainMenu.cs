using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BackToMainMenu : MonoBehaviour
{
    public void GoToCardGuide()
    {
        SceneManager.LoadScene("HelpScenes");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene("StartScenes");
    }
    
}
