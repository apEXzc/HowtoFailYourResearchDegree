using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class RemoveImpFeatureEffect : MonoBehaviour
{
    public GameObject RemoveBoard;

    public TMPro.TMP_Text gamePhaseText;
    public GameObject ImpDashTip;
    public GameObject PlanDashTip;
    public GameObject ContextDashTip;
    public ActiveCardManager activeCardManager;

    public int hasRemovedList = 0;
    public int currentImpCardNum = 0;
    public int currentContextCardNum = 0;
    public int currentPlanCardNum = 0;

    public string[] currentImpCards;
    
    public string effect = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (effect != "")
        {  
            if (effect == "brokenfridge")
            {
                checkBrokenfridgeClick();
                return;
            }
            else if(effect == "cantuseit")
            {
                checkCantuseitClick();
                return;
            }
            else if (effect == "fire")
            {
                checkFireClick();
                return;
            }
            else if (effect == "flood")
            {
                checkFloodClick();
            }
            else if (effect == "philosophy")
            {
                checkPhilosophyClick();
            }
            else if( effect == "resources")
            {
                checkContextIsClick();
            }
            else if (effect == "statistics")
            {
                checkStatisticsIsClick();
            }
            else if (effect == "theory")
            {
                checkTheoryClick();
            }
            else 
            {
                checkIsClick();
            }
        }
    }

    public void ImpCardEffect(string effect)
    {
        this.effect = effect;
        switch (effect)
        {
            // effect: remove three cards in Implementation card area
            // if a (Research data management strategy) in plan card, then IGNORE effect
            case "bluescreen":
                bool isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ResearchDataManagementStrategy")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove THREE cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectThree());

                }
                break;

            // effect: remove three （Data） cards AND （Results OR Great results）in Implementation card area
            case "brokenfridge":
                gamePhaseText.text = "Please remove Three Data AND One (Results OR Great results) in Implementation area";
                
                // copy currentImpCards to currentImpCards
                currentImpCards = new string[16];
                for(int i = 0; i<16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                        currentImpCards[i] = card.cardName;
                    }
                }
                ImpDashTip.gameObject.SetActive(true);
                RemoveBoard.gameObject.SetActive(true);
                for (int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if(card.cardName == "Data" || card.cardName == "Results" || card.cardName == "GreatResults")
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentImpCardNum++;
                    }
                }
                StartCoroutine(executeBrokenfridgeEffect());
                break;
            
            // effect: remove one （great resources） cards AND （resource（any））in Implementation card area
            case "cantuseit":
                
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ExpertiseTraining")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove Great resources AND resource(any) in Context or Implementation area";
                    ImpDashTip.gameObject.SetActive(true);
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if(card.cardName == "GreatResources")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                        if(activeCardManager.currentContextCards[i] != null)
                        {
                            ContextCard card = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                            if(card.cardName == "Resource(archive)" ||
                               card.cardName == "Resource(interviews)" ||
                               card.cardName == "Resource(data)" ||
                               card.cardName == "Resource(lab)" ||
                               card.cardName == "Resource(objects)" ||
                               card.cardName == "Resource(rawData)" ||
                               card.cardName == "Resource(policy)")
                            {
                                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeCantuseitEffect());

                }
                break;
            
            // effect: remove Results OR Great results cards in Implementation card area
            // if a (great resources) in Context card, then IGNORE effect
            case "competition":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "GreatResources")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove Results OR Great results card in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if(card.cardName == "Results" || card.cardName == "GreatResults")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove two cards in Implementation card area
            // if a (Milestones) in plan card, then remove one card
            case ("distraction"):
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please remove ONE cards in Implementation cards area";
                        ImpDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentImpCards[i] != null)
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentImpCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove TWO cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;

            // effect: remove two cards in Implementation card area
            // if a (Refine Research questions) in plan card, then IGNORE effect
            case "dotoomuch":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "RefineResearchQuestions")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove Two cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove Four cards in Implementation card area
            // if a (ethical clearance) in plan card, then IGNORE effect
            case "ethics":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "EthicalClearance")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove FOUR cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectFour());

                }
                break;
            
            // effect: remove three （Data） cards OR Results OR Analysis OR interpretation in Implementation card area
            case "fire":
                gamePhaseText.text = "Please remove Three Data OR One Results OR One Analysis OR One interpretation cards";
                
                // copy currentImpCards to currentImpCards
                currentImpCards = new string[16];
                for(int i = 0; i<16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                        currentImpCards[i] = card.cardName;
                    }
                }
                ImpDashTip.gameObject.SetActive(true);
                RemoveBoard.gameObject.SetActive(true);
                for (int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if(card.cardName == "Data" || card.cardName == "Results" || card.cardName == "Analysis" || card.cardName == "Interpretation")
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentImpCardNum++;
                    }
                }
                StartCoroutine(executeFireEffect());
                break;
            
            // effect: remove One （great resources） cards AND （ Two Results OR Great results）in Implementation card area
            case "flood":
                gamePhaseText.text = "Please remove One (great resources) cards AND (Two Results OR Great results) in Implementation area";
                
                // copy currentImpCards to currentImpCards
                currentImpCards = new string[16];
                for(int i = 0; i<16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                        currentImpCards[i] = card.cardName;
                    }
                }
                ImpDashTip.gameObject.SetActive(true);
                RemoveBoard.gameObject.SetActive(true);
                for (int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentImpCards[i] != null)
                    {
                        ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if(card.cardName == "GreatResources" || card.cardName == "Results" || card.cardName == "GreatResults")
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentImpCardNum++;
                    }
                }
                StartCoroutine(executeFloodEffect());
                break;
            
            // effect: remove one cards in Implementation card area
            // if a (holiday time) in plan card, then IGNORE effect
            case "lostenthus":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "HolidayTime")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove Two interpretation cards in Implementation card area
            // if a (research data management strategy) in plan card, then IGNORE effect
            case "metadatafail":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ResearchDataManagementStrategy")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove TWO interpretation cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if (card.cardName == "Interpretation")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove One （results）AND interpretation in Implementation card area
            // if a (Expertise) in plan card, then IGNORE effect
            case "philosophy":
                
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ExpertiseTraining")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }

                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE Results AND One interpretation cards";
                
                    // copy currentImpCards to currentImpCards
                    currentImpCards = new string[16];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[i] = card.cardName;
                        }
                    }
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if(card.cardName == "Results" || card.cardName == "Interpretation")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executePhilosophyEffect());
                }
                break;
            
            // effect: remove One resource(any) in context card area
            // if a (Discussion with experts) in Context card, then IGNORE effect
            case "resources":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "DiscussionWithExperts")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE resource(any) card in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            ContextCard card = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                            if(card.cardName == "Resource(archive)" ||
                               card.cardName == "Resource(interviews)" ||
                               card.cardName == "Resource(data)" ||
                               card.cardName == "Resource(lab)" ||
                               card.cardName == "Resource(objects)" ||
                               card.cardName == "Resource(rawData)" ||
                               card.cardName == "Resource(policy)")
                            {
                                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeContextEffectOne());

                }
                break;
            
            // effect: remove two cards in Implementation card area
            // if a (Contingency Time) in plan card, then IGNORE effect and TurnOver the card
            case "sick":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ContingencyTime")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        cardGameObj.transform.Find("TurnOver").gameObject.SetActive(true);
                        card.cardName = "null";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove Two cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove one cards in Implementation card area
            // if a (Contingency Time) in plan card, then IGNORE effect and TurnOver the card
            case "sisterwedding":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ContingencyTime")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        cardGameObj.transform.Find("TurnOver").gameObject.SetActive(true);
                        card.cardName = "null";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove One cards in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove One （results）AND (analysis) in Implementation card area
            // if a (Expertise) in plan card, then IGNORE effect
            case "statistics":
                
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ExpertiseTraining")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }

                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE Results AND One Analysis cards";
                
                    // copy currentImpCards to currentImpCards
                    currentImpCards = new string[16];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[i] = card.cardName;
                        }
                    }
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if(card.cardName == "Results" || card.cardName == "Analysis")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeStatisticsEffect());
                }
                break;
            
            // effect: remove two (interpretation) cards OR (analysis) in Implementation card area
            // if Three (relevant) OR One (very relevant) in Context card, then IGNORE effect
            case "theory":
                
                isCardInEffect = true;
                int relevantNum = 0;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (relevantNum == 3)
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "VeryRelevantArticle" || relevantNum == 3 )
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    } else if (relevantNum < 3 && card.cardName == "RelevantArticle")
                    {
                        relevantNum++;
                    }
                }

                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove Two Interpretation OR One Analysis cards";
                    // copy currentImpCards to currentImpCards
                    currentImpCards = new string[16];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[i] = card.cardName;
                        }
                    }
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                            if(card.cardName == "Interpretation" || card.cardName == "Analysis")
                            {
                                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeTheoryEffect());
                }
                break;
            
            // effect: remove one cards in Implementation card area
            // if a (meeting with supervisor) in plan card
            // OR a (discussion with experts) in context card
            // OR a (refine research questions) in context card，then IGNORE effect
            case "tunnelvision":
                isCardInEffect = true;
                for(int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentContextCards[i] != null)
                    {
                        ContextCard contextCard = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if (contextCard.cardName == "DiscussionWithExperts" || contextCard.cardName == "RefineResearchQuestions")
                        {
                            gamePhaseText.text = "Please check if you need to remove the card";
                            isCardInEffect = false;
                            break;
                        }
                    }
                    if(activeCardManager.currentPlanCards[i] != null)
                    {
                        PlanCard planCard = activeCardManager.currentPlanCards[i].gameObject.GetComponent<ShowCard>().card as PlanCard;
                        if (planCard.cardName == "MeetingsWithSupervisor")
                        {
                            gamePhaseText.text = "Please check if you need to remove the card";
                            isCardInEffect = false;
                            break;
                        }
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE card in Implementation cards area";
                    ImpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentImpCards[i] != null)
                        {
                            activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentImpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
        }
    }


    public void checkContextIsClick()
    {
        int count = 0;
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                count++;
            }
        }
        if (currentContextCardNum > count)
        {
            hasRemovedList++;
            currentContextCardNum--;
        }
    }
    public void checkIsClick()
    {
        int count = 0;
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                count++;
            }
        }
        if (currentImpCardNum > count)
        {
            hasRemovedList++;
            currentImpCardNum--;
        }
    }
    
    
    
    

    public int clickNum1 = 0;
    public bool isClickCondition2 = false;
    public void checkBrokenfridgeClick()
    {
        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (currentImpCards[i] == "Data" && clickNum1 < 3)
                {
                    clickNum1++;
                    
                    // copy currentImpCards to currentImpCards
                    for(int x = 0; x<16; x++)
                    {
                        if (activeCardManager.currentImpCards[x] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[x].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[x] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[x] = "";
                        }
                    }
                    
                    break;
                }
                else if (( currentImpCards[i] == "Results" || currentImpCards[i] == "GreatResults") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeBrokenfridgeEffect()
    {
        yield return new WaitUntil(() => (clickNum1 == 3 && isClickCondition2));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        clickNum1 = 0;
        isClickCondition2 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public bool clickNum2 = false;
    public bool clickNum3 = false;
    public void checkCantuseitClick()
    {
        int count1 = 0;
        int count2 = 0;
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                count1++;
            }
            if(activeCardManager.currentImpCards[i] != null)
            {
                count2++;
            }
        }
        if (currentContextCardNum > count1)
        {
            clickNum2 = true;
        }
        if (currentImpCardNum > count2)
        {
            clickNum3 = true;
        }
    }
    public IEnumerator executeCantuseitEffect()
    {
        yield return new WaitUntil(() => (clickNum2 && clickNum3));
        currentImpCardNum = 0;
        currentContextCardNum = 0;
        clickNum2 = false;
        clickNum3 = false;
        ContextDashTip.gameObject.SetActive(false);
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";
        
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
            if(activeCardManager.currentContextCards[i] != null)
            {
                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
   public void checkFireClick()
    {
        if (isClickCondition2)
        {
            return;
        }
        if (clickNum1 == 3)
        {
            isClickCondition2 = true;
            return;
        }

        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (currentImpCards[i] == "Data" && clickNum1 < 3)
                {
                    clickNum1++;
                    
                    // copy currentImpCards to currentImpCards
                    for(int x = 0; x<16; x++)
                    {
                        if (activeCardManager.currentImpCards[x] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[x].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[x] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[x] = "";
                        }
                    }
                    
                    break;
                }
                else if (( currentImpCards[i] == "Results" || currentImpCards[i] == "Analysis" || currentImpCards[i] == "Interpretation") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeFireEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        clickNum1 = 0;
        isClickCondition2 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public bool isClickCondition3 = false;
    public void checkFloodClick()
    {
        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (currentImpCards[i] == "Results" && clickNum1 < 2)
                {
                    clickNum1++;
                    
                    // copy currentImpCards to currentImpCards
                    for(int x = 0; x<16; x++)
                    {
                        if (activeCardManager.currentImpCards[x] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[x].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[x] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[x] = "";
                        }
                    }
                    
                    break;
                }
                else if (( currentImpCards[i] == "GreatResources") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
                else if (( currentImpCards[i] == "GreatResults") && !isClickCondition3)
                {
                    isClickCondition3 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeFloodEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2 && ((clickNum1 == 2)|| isClickCondition3)));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        clickNum1 = 0;
        isClickCondition2 = false;
        isClickCondition3 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    
    public void checkPhilosophyClick()
    {
        if (isClickCondition2 && isClickCondition3)
        {
            return;
        }

        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (( currentImpCards[i] == "Results") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
                else if ((currentImpCards[i] == "Interpretation") && !isClickCondition3)
                {
                    isClickCondition3 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executePhilosophyEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2 && isClickCondition3));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        isClickCondition2 = false;
        isClickCondition3 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public void checkStatisticsIsClick()
    {
        if (isClickCondition2 && isClickCondition3)
        {
            return;
        }

        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (( currentImpCards[i] == "Results") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
                else if ((currentImpCards[i] == "Analysis") && !isClickCondition3)
                {
                    isClickCondition3 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeStatisticsEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2 && isClickCondition3));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        isClickCondition2 = false;
        isClickCondition3 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
     public void checkTheoryClick()
    {
        if (isClickCondition2 || (clickNum1==2))
        {
            return;
        }

        string[] changedImpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                ImplementationCard card = activeCardManager.currentImpCards[i].GetComponent<ShowCard>().card as ImplementationCard;
                changedImpCards[i] = card.cardName;
            }
            else
            {
                changedImpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentImpCards.Length == 0)
            {
                break;
            }
            if (currentImpCards[i] != changedImpCards[i])
            {
                if (currentImpCards[i] == "Interpretation" && clickNum1 < 2)
                {
                    clickNum1++;
                    
                    // copy currentImpCards to currentImpCards
                    for(int x = 0; x<16; x++)
                    {
                        if (activeCardManager.currentImpCards[x] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[x].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[x] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[x] = "";
                        }
                    }
                    
                    break;
                }
                else if ((currentImpCards[i] == "Analysis") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentImpCards to currentImpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentImpCards[j] != null)
                        {
                            ImplementationCard card = activeCardManager.currentImpCards[j].GetComponent<ShowCard>().card as ImplementationCard;
                            currentImpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentImpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeTheoryEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2 || (clickNum1==2)));
        hasRemovedList = 0;
        currentImpCardNum = 0;
        clickNum1 = 0;
        isClickCondition2 = false;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    
    
    
    public IEnumerator executeContextEffectOne()
    {
        yield return new WaitUntil(() => hasRemovedList == 1);
        hasRemovedList = 0;
        currentContextCardNum = 0;
        ContextDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    public IEnumerator executeEffectOne()
    {
        yield return new WaitUntil(() => hasRemovedList == 1);
        hasRemovedList = 0;
        currentImpCardNum = 0;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectTwo()
    {
        yield return new WaitUntil(() => hasRemovedList == 2);
        hasRemovedList = 0;
        currentImpCardNum = 0;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectThree()
    {
        yield return new WaitUntil(() => hasRemovedList == 3);
        hasRemovedList = 0;
        currentImpCardNum = 0;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public IEnumerator executeEffectFour()
    {
        yield return new WaitUntil(() => hasRemovedList == 4);
        hasRemovedList = 0;
        currentImpCardNum = 0;
        ImpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Implementation event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentImpCards[i] != null)
            {
                activeCardManager.currentImpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
}
  

