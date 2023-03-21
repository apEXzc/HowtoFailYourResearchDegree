using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Animation : MonoBehaviour
{
    private Button button;
    private Sprite[] animationSprites;
    private int currentIndex = 0;
    private GameObject jumpToMain;

    private void Start()
    {
        button = GameObject.Find("AnimationButton").GetComponent<Button>();
        jumpToMain = GameObject.Find("JumpToMain");
        jumpToMain.SetActive(false);
        animationSprites = new Sprite[8];
        for (int i = 0; i < 8; i++)
        {
            animationSprites[i] = Resources.Load<Sprite>("Intro/Comic" + (i + 1));
        }
        button.image.sprite = animationSprites[currentIndex];
    }

    public void OnButtonClick()
    {
        currentIndex = (currentIndex + 1) % 8;
        button.image.sprite = animationSprites[currentIndex];
        if (currentIndex == 7)
        {
            jumpToMain.SetActive(true);
        }
        
    }
}