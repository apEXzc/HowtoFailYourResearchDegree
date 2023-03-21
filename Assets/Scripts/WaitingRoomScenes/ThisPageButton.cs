using UnityEngine.SceneManagement;
using UnityEngine;

public class ThisPageButton : MonoBehaviour
{
    
    public void TurnScene(int sceneNumber)
    {
        SceneManager.LoadScene(sceneNumber);
    }
}
