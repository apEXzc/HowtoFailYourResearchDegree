using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseMove : MonoBehaviour
{

    public RectTransform rectTransform;
    public RectTransform pointer;
    public Vector2 temp;

    // Update is called once per frame


    public void MouseEnter()
    {
        temp = rectTransform.anchoredPosition;
        rectTransform.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x+20, rectTransform.anchoredPosition.y);
        if (pointer != null)
        {
            pointer.gameObject.SetActive(true);
            pointer.anchoredPosition = new Vector2(rectTransform.anchoredPosition.x-250, rectTransform.anchoredPosition.y);
        }
    }

    public void MouseExit()
    {
        if (pointer != null)
        {
            pointer.gameObject.SetActive(false);
        }
        rectTransform.anchoredPosition = temp;
    }
    
    public void MouseEnterActive(BaseEventData b)
    {
        temp = transform.localScale;
        gameObject.transform.localScale += new Vector3((float)0.15, (float)0.15) ;
    }

    public void MouseExitActive(BaseEventData b)
    {
        gameObject.transform.localScale -= new Vector3((float)0.15, (float)0.15) ;
        
    }
}






