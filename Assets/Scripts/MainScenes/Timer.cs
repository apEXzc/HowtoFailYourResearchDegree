using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public float startingTime = 60f;
    public float currentTime = 0;
    public Text timerText;
    public bool runTimer = false;
    public GameObject timerSlider;
    public GameObject restartButton;
    public Image timerButton;
    public bool resetTimer = false;
    public GameObject timerGif;



    // Update is called once per frame
    void Start(){
    }
    
    void Update()
    {
        if(runTimer){
            if(currentTime > 0){
                currentTime -= 1 * Time.deltaTime;
                timerSlider.SetActive(false);
                timerButton.sprite = Resources.Load<Sprite>("ScenesPng/MainScenesPng/pause");
                restartButton.SetActive(true);
                timerGif.SetActive(true);
            }
            else{
                currentTime = 0;
                runTimer = false;
            }
            DisplayTime(currentTime);
        }
    }

    void DisplayTime(float timeToDisplay){
        if(timeToDisplay < 0){
            timeToDisplay = 0;
        }
        else if(timeToDisplay > 0){
            timeToDisplay += 1;
        }

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    public void ToggleTimer(){
        if(runTimer){
            runTimer = false;
            timerGif.SetActive(false);
            timerButton.sprite = Resources.Load<Sprite>("ScenesPng/MainScenesPng/continue");
        }
        else{
            if(currentTime <= 0 || resetTimer){
                  currentTime = startingTime;
                  resetTimer = false;
            }
            
            runTimer = true;
        }
    }
    
    public void ResetTimer()
    {
        currentTime = startingTime-1;
        runTimer = false;
        timerSlider.SetActive(true);
        timerButton.sprite = Resources.Load<Sprite>("ScenesPng/MainScenesPng/timer");
        resetTimer = true;
        DisplayTime(currentTime);
        restartButton.SetActive(false);
        timerGif.SetActive(false);
    }

    public void ChangeMaxTime(float maxTime){
        startingTime = maxTime;
    }
}
