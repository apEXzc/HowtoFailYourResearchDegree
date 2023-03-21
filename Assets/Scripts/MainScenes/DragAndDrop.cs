using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

/*
 * This file is trying to make card(object) move, with MapManager.cs
*/


public class DragAndDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    private RectTransform rectTras;
    private CanvasGroup canvasGroup;
    private Vector2 startPos;

    public int id; // In order to confirm whether background object and this object are matched.
    public int RemoveId;

    Vector3 offPos;

    private void Start()
    {
        rectTras = GetComponent<RectTransform>(); //get object current position
        canvasGroup = GetComponent<CanvasGroup>(); // trying to ignore parent-child layer,
                                                   // then make background object can check whether this object on it
        startPos = this.transform.position; // get object start position
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin to move");
        offPos = transform.position - Input.mousePosition; // mouse offset
        canvasGroup.blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Debug.Log("moving");
        transform.position = offPos + Input.mousePosition; // make object moving
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        // Avoid work late tile droping in the card when card is in the card pool
        // When card has already droped in the card grid, the mapManager.cs will be added to the card object.
        if ((startPos.x != this.transform.position.x) && (startPos.y != this.transform.position.y)) {
            transform.AddComponent<MapManager>();
            transform.GetComponent<MapManager>().id = 50;
            transform.GetComponent<MapManager>().RemoveId = 0;
        }

        // Avoid card back to the card pool when card has already droped in the card grid
        startPos = this.transform.position;

        canvasGroup.blocksRaycasts = true;

    }


    // when user move object to wrong positon, move object to original position
    public void ResetPosition() {

        this.transform.position = startPos;

    }

}
