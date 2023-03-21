using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;


/*
 * This file trying to control round button, including all game phase
 */

public class RoundButton : MonoBehaviour
{

    //GameObject means it will bind with the unity object.
    public GameObject PlanCardPool; // the place cards appear
    public GameObject ContextCardPool;
    public GameObject ImpCardPool;
    public GameObject WriteUpCardPool;
    public GameObject RemoveBoard;

    // a lot of card prefab
    public GameObject PlanCardPrefab;
    public GameObject ContextCardPrefab;
    public GameObject ImplementationCardPrefab;
    public GameObject WriteUpCardPrefab;

    public GameObject EventContextCardPrefab;
    public GameObject EventContextCardPool;
    public GameObject EventImplementaionCardPrefab;
    public GameObject EventImplementationCardPool;
    public GameObject EventWriteUpCardPrefab;
    public GameObject EventWriteUpCardPool;

    public GameObject PlanBackGround;
    public GameObject ContextBackGround;
    public GameObject ImplementationBackground;
    public GameObject WriteUpBackground;

    public GameObject EventContextCover;
    public GameObject EventImpCover;
    public GameObject EventWriteUpCover;

    public PlayManager playManager;
    public LoadData loadData;
    public ActiveCardManager activeCardManager;
    public RemindWindow remindWindow;

    // The list of all active card objects generated.
    public List<GameObject> PlanCardObjects = new List<GameObject>();
    public List<GameObject> ContextCardObjects = new List<GameObject>();
    public List<GameObject> ImpCardObjects = new List<GameObject>();
    public List<GameObject> WriteUpCardObjects = new List<GameObject>();

    // The list of all event card objects generated.
    public List<GameObject> EventContextCardObjects = new List<GameObject>();
    public List<GameObject> EventImpCardObjects = new List<GameObject>();
    public List<GameObject> EventWriteUpObjects = new List<GameObject>();

    public List<GameObject> dashs = new List<GameObject>();
    public GameObject dashTip1;
    public GameObject dashTip2;
    public GameObject dashTip3;
    public GameObject dashTip4;
    public GameObject dashTip5;

    public GameObject clickAudio;
    public GameObject dotLine;
    public GameObject dotLine1;
    public GameObject dotLine3;
    public GameObject dotLine4;
    
    public GameObject dotLine2;


    // Start is called before the first frame update
    void Start()
    {
        loadData = GetComponent<LoadData>();
        dashs.Add(dashTip1);
        dashs.Add(dashTip2);
        dashs.Add(dashTip3);
        dashs.Add(dashTip4);
        dashs.Add(dashTip5);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //when click round button
    public void Onclick() {

        if (remindWindow.remindUncorrectCard()) { return; }
        if (remindWindow.checkHasCardInBg()) { return; }
        if (activeCardManager.checkActiveRowIsEmpty())
        {
            remindWindow.remindGameOver();
            return;
        }
        if (remindWindow.remindClickEventCard()) { return; };

        playManager.PhaseUpdate();

        int phaseCount = playManager.gamePhase.toInt();
        if (phaseCount < 14 && (phaseCount % 2) != 0) //draw active card phase
        {
            foreach (GameObject dash in dashs)
            {
                if (dash.activeInHierarchy)
                {
                    dash.SetActive(false);
                }
            }
            
            RemoveBoard.gameObject.SetActive(false);
            dotLine2.SetActive(false);
            Card[] randomCard = loadData.RandomCard(playManager.gamePhase);

            if (randomCard[0] is ActiveCardBase)
            {
                //In order to recover event card background
                if (playManager.gamePhase == GamePhase.ImpDraw)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Destroy(EventContextCardObjects[i].gameObject);
                        EventImplementationCardPool.SetActive(true);
                        EventWriteUpCardPool.SetActive(true);
                    }
                }
                else if (playManager.gamePhase == GamePhase.writeUpDraw)
                {
                    for (int i = 0; i < 3; i++)
                    {
                        Destroy(EventImpCardObjects[i].gameObject);
                        EventContextCardPool.SetActive(true);
                        EventWriteUpCardPool.SetActive(true);
                    }
                }

                for (int i = 0; i < 16; i++)
                {
                    switch (playManager.gamePhase)
                    {
                        case GamePhase.planDraw:
                            if (i > 7) { break; }
                            GameObject ActiveNewPlanCard = GameObject.Instantiate(PlanCardPrefab, PlanCardPool.transform);
                            ActiveNewPlanCard.GetComponent<ShowCard>().card = randomCard[i];
                            PlanCardObjects.Add(ActiveNewPlanCard);
                            dotLine.SetActive(true);
                            break;
                        case GamePhase.contextDraw:
                            GameObject ActiveNewContextCard = GameObject.Instantiate(ContextCardPrefab, ContextCardPool.transform);
                            ActiveNewContextCard.GetComponent<ShowCard>().card = randomCard[i];
                            ContextCardObjects.Add(ActiveNewContextCard);
                            dotLine.SetActive(false);
                            dotLine1.SetActive(true);
                            break;
                        case GamePhase.ImpDraw:
                            GameObject ActiveNewImplementationCard = GameObject.Instantiate(ImplementationCardPrefab, ImpCardPool.transform);
                            ActiveNewImplementationCard.GetComponent<ShowCard>().card = randomCard[i];
                            ImpCardObjects.Add(ActiveNewImplementationCard);
                            dotLine1.SetActive(false);
                            dotLine3.SetActive(true);
                            break;
                        case GamePhase.writeUpDraw:
                            GameObject ActiveNewWriteUpCard = GameObject.Instantiate(WriteUpCardPrefab, WriteUpCardPool.transform);
                            ActiveNewWriteUpCard.GetComponent<ShowCard>().card = randomCard[i];
                            WriteUpCardObjects.Add(ActiveNewWriteUpCard);
                            dotLine3.SetActive(false);
                            dotLine4.SetActive(true);
                            break;
                    }
                }

            }
            else if (randomCard[0] is EventCardBase)
            {
                for (int i = 0; i < 3; i++)
                {
                    switch (playManager.gamePhase)
                    {
                        case GamePhase.eventContextDraw:
                            EventContextCover.SetActive(true);
                            GameObject EventNewContextCard = GameObject.Instantiate(EventContextCardPrefab, EventContextCardPool.transform);
                            EventNewContextCard.GetComponent<ShowCard>().card = randomCard[i];
                            AddAudioSource(EventNewContextCard);
                            EventContextCardObjects.Add(EventNewContextCard);
                            break;
                        case GamePhase.eventImpDraw:
                            EventImpCover.SetActive(true);
                            GameObject EventNewImplementationCard = GameObject.Instantiate(EventImplementaionCardPrefab, EventImplementationCardPool.transform);
                            EventNewImplementationCard.GetComponent<ShowCard>().card = randomCard[i];
                            EventNewImplementationCard.SetActive(true);
                            AddAudioSource(EventNewImplementationCard);
                            EventImpCardObjects.Add(EventNewImplementationCard);
                            break;
                        case GamePhase.eventWriteUpDraw:
                            EventWriteUpCover.SetActive(true);
                            GameObject EventNewWriteUpCard = GameObject.Instantiate(EventWriteUpCardPrefab, EventWriteUpCardPool.transform);
                            EventNewWriteUpCard.GetComponent<ShowCard>().card = randomCard[i];
                            EventNewWriteUpCard.SetActive(true);
                            AddAudioSource(EventNewWriteUpCard);
                            EventWriteUpObjects.Add(EventNewWriteUpCard);
                            break;
                    }

                }
            }

        }
        else if (phaseCount < 14 && (phaseCount % 2) == 0)
        { // check active card phase
            activeCardManager.clearBgAndCardsInPool();
            if (phaseCount >= 2)
            {
                RemoveBoard.gameObject.SetActive(true);
                dotLine2.SetActive(true);
            }
        }
        else if (playManager.gamePhase == GamePhase.gameEnd)
        {
            foreach (GameObject dash in dashs)
            {
                if (dash.activeInHierarchy)
                {
                    dash.SetActive(false);
                }
            }
            for (int i = 0; i < 3; i++)
            {
                Destroy(EventWriteUpObjects[i].gameObject);
                EventImplementationCardPool.SetActive(true);
                EventContextCardPool.SetActive(true);
            }
            dotLine4.SetActive(false);
        }
    }

    public void PlayClickAudio(BaseEventData b){
        clickAudio.GetComponent<AudioSource>().Play();
    }

    public void AddAudioSource(GameObject g)
    {
        EventTrigger eventTrigger = g.GetComponent<EventTrigger>();
        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerDown;
        UnityAction<BaseEventData> callback = new UnityAction<BaseEventData>(PlayClickAudio);
        entry.callback.AddListener(callback);
        eventTrigger.triggers.Add(entry);
    }
}
