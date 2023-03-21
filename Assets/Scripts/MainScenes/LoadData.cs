using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

/*
 * This file trying to load all card picture from Resources
 */

    public class LoadData : MonoBehaviour
{

    // store all card object loading from Resources
    public List<PlanCard> PlanCardList = new List<PlanCard>();
    public List<ContextCard> ContextCardList = new List<ContextCard>();
    public List<ImplementationCard> ImplementationList = new List<ImplementationCard>();
    public List<WriteUpCard> WriteUpCardList = new List<WriteUpCard>();
    public List<EventContextCard> EventContextCardList = new List<EventContextCard>();
    public List<EventImplementationCard> EventImplementationList = new List<EventImplementationCard>();
    public List<EventWriteUpCard> EventWriteUpList = new List<EventWriteUpCard>();

    public GameObject Photo;
    public GameObject name;


    // Start is called before the first frame update
    void Start()
    {
        LoadCardData();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //Load active and event cards from Resources
    public void LoadCardData()
    {
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/ActiveCard/PlanCard"))
        {
            PlanCard planCard = gameObject.AddComponent<PlanCard>();
            planCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            planCard.cardName = fileNames[1];
            string arrow = fileNames[2];
            if (arrow.IndexOf("L") == 0)
            {
                planCard.Left = true;
            }
            if (arrow.IndexOf("R") == 1)
            {
                planCard.Right = true;
            }
            if (arrow.IndexOf("U") == 2)
            {
                planCard.Up = true;
            }

            PlanCardList.Add(planCard);
        }
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/ActiveCard/ContextCard"))
        {
            ContextCard contextCard = gameObject.AddComponent<ContextCard>();
            contextCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            contextCard.cardName = fileNames[1];
            string arrow = fileNames[2];
            if (arrow.IndexOf("L") == 0)
            {
                contextCard.Left = true;
            }
            if (arrow.IndexOf("R") == 1)
            {
                contextCard.Right = true;
            }
            if (arrow.IndexOf("U") == 2)
            {
                contextCard.Up = true;
            }
            if (arrow.IndexOf("D") == 3)
            {
                contextCard.Down = true;
            }
            ContextCardList.Add(contextCard);
        }
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/ActiveCard/ImplementationCard"))
        {
            ImplementationCard implementationCard = gameObject.AddComponent<ImplementationCard>();
            implementationCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            implementationCard.cardName = fileNames[1];
            string arrow = fileNames[2];
            if (arrow.IndexOf("L") == 0)
            {
                implementationCard.Left = true;
            }
            if (arrow.IndexOf("R") == 1)
            {
                implementationCard.Right = true;
            }
            if (arrow.IndexOf("U") == 2)
            {
                implementationCard.Up = true;
            }
            if (arrow.IndexOf("D") == 3)
            {
                implementationCard.Down = true;
            }
            ImplementationList.Add(implementationCard);
        }

        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/ActiveCard/WriteUpCard"))
        {
            WriteUpCard writeUpCard = gameObject.AddComponent<WriteUpCard>();
            writeUpCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            writeUpCard.cardName = fileNames[1];
            string arrow = fileNames[2];
            if (arrow.IndexOf("L") == 0)
            {
                writeUpCard.Left = true;
            }
            if (arrow.IndexOf("R") == 1)
            {
                writeUpCard.Right = true;
            }
            if (arrow.IndexOf("T") == 2)
            {
                writeUpCard.Thesis = true;
            }
            if (arrow.IndexOf("D") == 3)
            {
                writeUpCard.Down = true;
                if (bg.name.LastIndexOf("T") == bg.name.Length - 2) // check whether this write-up card has thesis title
                {
                    writeUpCard.hasThesis = true;
                }
                WriteUpCardList.Add(writeUpCard);
            }
        }
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/EventCard/EventContextCard"))
        {
            EventContextCard eventContextCard = gameObject.AddComponent<EventContextCard>();
            eventContextCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            eventContextCard.effect = fileNames[2];
            EventContextCardList.Add(eventContextCard);
        }
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/EventCard/EventImplementationCard"))
        {
            EventImplementationCard eventImplementationCard = gameObject.AddComponent<EventImplementationCard>();
            eventImplementationCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            eventImplementationCard.effect = fileNames[2];
            EventImplementationList.Add(eventImplementationCard);
        }
        foreach (var bg in Resources.LoadAll<Sprite>("CardPng/EventCard/EventWriteUpCard"))
        {
            EventWriteUpCard eventWriteUpCard = gameObject.AddComponent<EventWriteUpCard>();
            eventWriteUpCard.background = bg;
            String[] fileNames = bg.name.Split("_");
            eventWriteUpCard.effect = fileNames[2];
            EventWriteUpList.Add(eventWriteUpCard);
        }
        
        //Load profile
        Sprite[] avatars = new Sprite[12];
        for (int i = 0; i < 12; i++)
        {
            avatars[i] = Resources.Load<Sprite>("AvatarJPG/pic" + (i + 1));
        }

        // Get the saved avatar index and display the corresponding avatar
        int avatarIndex = PlayerPrefs.GetInt("AvatarIndex", 0);
        Photo.gameObject.GetComponent<Image>().sprite = avatars[avatarIndex];

        // Get the saved username and display it in the Text component
        string username = PlayerPrefs.GetString("Username", "");
        name.GetComponent<Text>().text = username;
        
    }


    // return a number of rondom cards from x
    public PlanCard[] RandomPlanCards = new PlanCard[8];
    public ContextCard[] RandomContextCards = new ContextCard[16];
    public ImplementationCard[] RandomImpCards = new ImplementationCard[16];
    public WriteUpCard[] RandomWriteUpCards = new WriteUpCard[16];

    public EventContextCard[] RandomEventContextCards = new EventContextCard[3];
    public EventImplementationCard[] RandomEventCImpCards = new EventImplementationCard[3];
    public EventWriteUpCard[] RandomEventCWriteUpCards = new EventWriteUpCard[3];

    public Card[] RandomCard(GamePhase gamePhase)
    {
        // create random active card
        for (int i = 0; i < 16; i++) {
            switch (gamePhase) {
                case GamePhase.planDraw:
                    if (i > 7){ return RandomPlanCards; }
                    PlanCard temp = PlanCardList[Random.Range(0, PlanCardList.Count)];
                    RandomPlanCards[i] = gameObject.AddComponent<PlanCard>();
                    RandomPlanCards[i].set(temp.background, temp.cardName, temp.Up, temp.Down, temp.Left, temp.Right);
                    break;
                case GamePhase.contextDraw:
                    ContextCard temp1 = ContextCardList[Random.Range(0, ContextCardList.Count)];
                    RandomContextCards[i] = gameObject.AddComponent<ContextCard>();
                    RandomContextCards[i].set(temp1.background, temp1.cardName, temp1.Up, temp1.Down, temp1.Left, temp1.Right);
                    if (i == 15) { return RandomContextCards; }
                    break;
                case GamePhase.ImpDraw:
                    ImplementationCard temp2 = ImplementationList[Random.Range(0, ImplementationList.Count)];
                    RandomImpCards[i] = gameObject.AddComponent<ImplementationCard>();
                    RandomImpCards[i].set(temp2.background, temp2.cardName, temp2.Up, temp2.Down, temp2.Left, temp2.Right);
                    if (i == 15) { return RandomImpCards; }
                    break;
                case GamePhase.writeUpDraw:
                    WriteUpCard temp3 = WriteUpCardList[Random.Range(0, WriteUpCardList.Count)];
                    RandomWriteUpCards[i] = gameObject.AddComponent<WriteUpCard>();
                    RandomWriteUpCards[i].set(temp3.background, temp3.cardName, temp3.Thesis, temp3.Down, temp3.Left, temp3.Right);
                    if (i == 15) { return RandomWriteUpCards; }
                    break;
            }
        }

        //create random event card
        for (int i = 0; i < 3; i++)
        {
            switch (gamePhase) {
                case GamePhase.eventContextDraw:
                    RandomEventContextCards[i] = EventContextCardList[Random.Range(0, EventContextCardList.Count)];
                    if (i == 2) { return RandomEventContextCards; }
                    break;
                case GamePhase.eventImpDraw:
                    RandomEventCImpCards[i] = EventImplementationList[Random.Range(0, EventImplementationList.Count)];
                    if (i == 2) { return RandomEventCImpCards; }
                    break;
                case GamePhase.eventWriteUpDraw:
                    RandomEventCWriteUpCards[i] = EventWriteUpList[Random.Range(0, EventWriteUpList.Count)];
                    if (i == 2) { return RandomEventCWriteUpCards; }
                    break;
            }
                
        }
        return null;
    }

}
