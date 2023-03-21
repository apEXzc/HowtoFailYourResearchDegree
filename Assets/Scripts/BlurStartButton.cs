using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlurStartButton : MonoBehaviour
{
    public GameObject inputField;

    public void OnStartGame(int sceneNumber)
    {
        
        if (inputField != null)
        {
            PlayerPrefs.SetString("Username", inputField.GetComponent<Text>().text);
        }
        SceneManager.LoadScene(sceneNumber);
    }
    
}
