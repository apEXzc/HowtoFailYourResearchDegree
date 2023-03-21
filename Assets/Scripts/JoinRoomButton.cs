using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinRoomButton : MonoBehaviour
{
    private int defaultIndex = 0;
    public InputField inputField;
    // Start is called before the first frame update
    void Start()
    {
        inputField = GameObject.Find("JoinGroupName").GetComponent<InputField>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnStartGame(int sceneNumber)
        {
            SceneManager.LoadScene(sceneNumber);
        }

    public void SaveData()
    {
        if (string.IsNullOrEmpty(inputField.text))
        {
            inputField.text = "Group" + defaultIndex;
            defaultIndex++;
        }

        string username = inputField.text;
        PlayerPrefs.SetString("Username", username);
    }
}
