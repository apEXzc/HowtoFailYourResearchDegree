using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingButton : MonoBehaviour
{
    public GameObject settingPanel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickQuitButton() {
        SceneManager.LoadScene("StartScenes");
    }

    public void OnClickSettingButton() {
        settingPanel.gameObject.SetActive(true);
    }

    public void OnClickBackButton() {

        settingPanel.gameObject.SetActive(false);
    }
}
