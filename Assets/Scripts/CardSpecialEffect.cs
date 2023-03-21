using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class CardSpecialEffect : MonoBehaviour
{
    public ActiveCardManager activeCardManager;
    public List<GameObject> worklates = new List<GameObject>();

    // Start is called before the first frame update
    void Start()
    {
        activeCardManager.GetAllBackgroundObj();
        for (int j = 0; j < 16; j++)
        {
            if (j <= 3)
            {
                AddEffect(worklates[j]);
            }
            if (j <= 7)
            {
                AddEffect(activeCardManager.PlanCardBgList[j].gameObject);
            }
            AddEffect(activeCardManager.ContextCardBgList[j].gameObject);
            AddEffect(activeCardManager.ImpCardBgList[j].gameObject);
            AddEffect(activeCardManager.WriteUpCardBgList[j].gameObject);
        }
    }

    // Update is called once per frame

    public void AddEffect(GameObject g)
    {
        UnityAction<BaseEventData, GameObject> callback1 = new UnityAction<BaseEventData, GameObject>(MouseEnterActive);
        UnityAction<BaseEventData, GameObject> callback2 = new UnityAction<BaseEventData, GameObject>(MouseExitActive);
        
        EventTrigger trigger = g.GetComponent<EventTrigger>();
        if (trigger == null)
            trigger = g.AddComponent<EventTrigger>();

        EventTrigger.Entry entry1 = new EventTrigger.Entry();
        entry1.eventID = EventTriggerType.PointerEnter;
        entry1.callback.AddListener((eventData) => callback1(eventData, g));
        trigger.triggers.Add(entry1);
        
        EventTrigger.Entry entry2 = new EventTrigger.Entry();
        entry2.eventID = EventTriggerType.PointerExit;
        entry2.callback.AddListener((eventData) => callback2(eventData, g));
        trigger.triggers.Add(entry2);
    }
    
    public void MouseEnterActive(BaseEventData b,GameObject g)
    {
        g.transform.localScale += new Vector3((float)0.15, (float)0.15) ;
    }

    public void MouseExitActive(BaseEventData b,GameObject g)
    {
        g.transform.localScale -= new Vector3((float)0.15, (float)0.15) ;
        
    }
}
