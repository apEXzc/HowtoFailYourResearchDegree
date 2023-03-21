using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


/*
 * This file is trying to make card(object) move, with DragAndDrop.cs
*/


public class MapManager : MonoBehaviour, IDropHandler
{

    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public int id; // In order to confirm whether this background object and moving card are matched.
    public int RemoveId;

    public bool reLoad = false;

    public void OnDrop(PointerEventData eventData)
    {
        //Debug.Log("On the background!");
        //Debug.Log(id + "-----" + "Drag id is " + eventData.pointerDrag.GetComponent<DragAndDrop>().id);
        //Debug.Log(id);          
        //gameObject.SetActive(true);
        try
        {
            if (eventData.pointerDrag.GetComponent<DragAndDrop>().id == id)
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                //Debug.Log(eventData.pointerDrag.GetComponent<DragAndDrop>().id);
                if (eventData.pointerDrag.GetComponent<DragAndDrop>().id != 50)
                {
                    gameObject.SetActive(false);// hidden background aviod card different corner
                    //eventData.pointerDrag.GetComponent<DragAndDrop>().enabled = false;// unactive card moving fuction, once card drop
                }
                else if((eventData.pointerDrag.GetComponent<DragAndDrop>().id == 50)) {
                    eventData.pointerDrag.SetActive(false);
                    gameObject.transform.Find("WorkLateTile").gameObject.SetActive(true);
                    gameObject.GetComponent<MapManager>().enabled = false;
                    gameObject.GetComponent<ShowCard>().changeCardArrows();
                }
            }
            else
            {
                eventData.pointerDrag.GetComponent<DragAndDrop>().ResetPosition();//move card back to original position
            }

            // Add remove function
            int temp = eventData.pointerDrag.GetComponent<DragAndDrop>().RemoveId ;
            if (( temp == 1) && (temp == RemoveId))
            {
                eventData.pointerDrag.GetComponent<RectTransform>().position = GetComponent<RectTransform>().position;
                Destroy(eventData.pointerDrag.gameObject);
                reLoad = true;
            }

        }
        catch (Exception e)
        {

        }
        
    }
}
