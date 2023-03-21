using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RemoveFeatureEffect : MonoBehaviour
{
    public GameObject RemoveBoard;

    public TMPro.TMP_Text gamePhaseText;
    public GameObject ContextDashTip;
    public GameObject PlanDashTip;
    public ActiveCardManager activeCardManager;

    public int hasRemovedList = 0;
    public int currentContextCardNum = 0;
    public int currentPlanCardNum = 0;
    public int specialMentorleavesEffectCount = 0;

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
            if (effect == "mentorleaves")
            {
                checkPlanIsClick();
            }
            else
            {
                checkIsClick();

            }
        }
    }

    public void ContextRemoveCardEffect(string effect)
    {
        this.effect = effect;
        switch (effect)
        {
            // effect: remove three cards in Context card area
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
                    gamePhaseText.text = "Please remove THREE cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectThree());

                }
                break;

            // effect: remove two cards in Context card area
            // if a (Milestones) in plan card, then remove one card
            case ("distraction"):
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please remove ONE cards in Context cards area";
                        ContextDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentContextCards[i] != null)
                            {
                                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentContextCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove TWO cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;

            // effect: remove two cards in Context card area
            // if a (Milestones) in plan card, then remove one card
            case ("distraction2"):
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please remove ONE cards in Context cards area";
                        ContextDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentContextCards[i] != null)
                            {
                                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentContextCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove TWO cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;

            // effect: remove two cards in Context card area
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
                    gamePhaseText.text = "Please remove Two cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove (Relevant article) OR (Very relevant article) in Context card area
            // if a (contingency time) in plan card, then IGNORE effect and TurnOver the card
            case "hasmybook":
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
                    gamePhaseText.text = "Please remove Relevant OR Very relevant article card in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] == null) { continue;}
                        ContextCard card = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if ((card.cardName == "RelevantArticle" || card.cardName == "VeryRelevantArticle"))
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentContextCardNum++;
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove (Relevant article) OR (Very relevant article) in Context card area
            // if a (contingency time) in plan card, then IGNORE effect and TurnOver the card
            case "loandelay":
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
                    gamePhaseText.text = "Please remove Relevant OR Very relevant article card in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] == null) { continue;}
                        ContextCard card = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if ((card.cardName == "RelevantArticle" || card.cardName == "VeryRelevantArticle"))
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentContextCardNum++;
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove one cards in Context card area
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
                    gamePhaseText.text = "Please remove ONE card in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove one cards in Context card area
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
                    gamePhaseText.text = "Please remove ONE card in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove two cards in Context card area
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
                    gamePhaseText.text = "Please remove Two cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove one cards in Context card area
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
                    gamePhaseText.text = "Please remove One cards in Context cards area";
                    ContextDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentContextCards[i] != null)
                        {
                            activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentContextCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove two cards in Context card area
            case "sourcesfail":
                gamePhaseText.text = "Please remove Two cards in Context cards area";
                ContextDashTip.gameObject.SetActive(true);
                RemoveBoard.gameObject.SetActive(true);
                for (int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentContextCards[i] != null)
                    {
                        activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        currentContextCardNum++;
                    }
                }
                StartCoroutine(executeEffectTwo());
                break;
            
            // effect: remove one (useless article) cards in Context card area if it has
            case "advicespecialist":
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "UselessArticle")
                    {
                        gamePhaseText.text = "Please remove ONE Useless Article in Context cards area";
                        ContextDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentContextCards[i] != null)
                            {
                                ContextCard contextCard = activeCardManager.currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                                if (contextCard.cardName == "UselessArticle")
                                {
                                    activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                }
                                currentContextCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                            break;
                    }
                    gamePhaseText.text = "Please check if you need to remove the card";
                }
                
                break;
            
            // effect: remove all (meetings with supervisor) cards in Context card area if it has
            case "mentorleaves":
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "MeetingsWithSupervisor")
                    {
                        gamePhaseText.text = "Please remove ALL meetings with supervisor in Plan cards area";
                        PlanDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentPlanCards[i] != null)
                            {
                                PlanCard planCard = activeCardManager.currentPlanCards[i].gameObject.GetComponent<ShowCard>().card as PlanCard;
                                if (planCard.cardName == "MeetingsWithSupervisor")
                                {
                                    activeCardManager.currentPlanCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                    specialMentorleavesEffectCount++;
                                }
                                currentPlanCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectSpcial());
                        break;
                    }
                    gamePhaseText.text = "Please check if you need to remove the card";
                }
                
                break;
        }
    }



    public void checkIsClick()
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
    
    public void checkPlanIsClick()
    {
        int count = 0;
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentPlanCards[i] != null)
            {
                count++;
            }
        }
        if (currentPlanCardNum > count)
        {
            hasRemovedList++;
            currentPlanCardNum--;
        }
    }

    public IEnumerator executeEffectOne()
    {
        yield return new WaitUntil(() => hasRemovedList == 1);
        hasRemovedList = 0;
        currentContextCardNum = 0;
        ContextDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectTwo()
    {
        yield return new WaitUntil(() => hasRemovedList == 2);
        hasRemovedList = 0;
        currentContextCardNum = 0;
        ContextDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectThree()
    {
        yield return new WaitUntil(() => hasRemovedList == 3);
        hasRemovedList = 0;
        currentContextCardNum = 0;
        ContextDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentContextCards[i] != null)
            {
                activeCardManager.currentContextCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public IEnumerator executeEffectSpcial()
    {
        yield return new WaitUntil(() => hasRemovedList == specialMentorleavesEffectCount);
        hasRemovedList = 0;
        currentPlanCardNum = 0;
        PlanDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentPlanCards[i] != null)
            {
                activeCardManager.currentPlanCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
}
  
