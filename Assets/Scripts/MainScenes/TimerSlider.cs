using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerSlider : MonoBehaviour
{
    public Slider timeSlide;
    //public float newTimeValue;
    [SerializeField] public Timer timeToUpdate;

    public int time;
    public Text timerText;
    
    public void Start(){ 
        time = (int)timeToUpdate.startingTime;
        timerText.text = string.Format("{0:00}:{1:00}", 1, 0);
    }
    
    public void Update(){
        while(time != (int)timeToUpdate.startingTime){
            time = (int)timeToUpdate.startingTime;
            float minutes = Mathf.FloorToInt(time / 60);
            float seconds = Mathf.FloorToInt(time % 60);

            timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
        }
    }

    public void OnSliderChanged(float value){
        float slideVal = timeSlide.value;
        timeToUpdate.startingTime = 60 + slideVal * 30;
    }
}
