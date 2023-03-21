using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine.UI;

public class RemoveWriteUpFeatureEffect : MonoBehaviour
{
    public GameObject RemoveBoard;

    public TMPro.TMP_Text gamePhaseText;
    public GameObject WriteUpDashTip;
    public GameObject PlanDashTip;
    public GameObject ContextDashTip;
    public ActiveCardManager activeCardManager;

    public int hasRemovedList = 0;
    public int currentWriteUpCardNum = 0;
    public int currentContextCardNum = 0;
    public int currentPlanCardNum = 0;

    public string[] currentWriteUpCards;
    public string[] hasRemovedWriteUpCards;
    
    public List<GameObject> hasRemovedWriteUpCardObjects = new List<GameObject>();

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
            if (effect == "distraction" || 
                effect == "distraction2" || 
                effect == "dotoomuch" || 
                effect == "fitforpurpose" ||
                effect == "jargon" ||
                effect == "lostvoice" ||
                effect == "uncriticalwriting")
            {
               checkNonAdjcentIsClick();
            }
            else if (effect == "disagreement" || 
                     effect == "sowhat")
            {
                checkDisagreementClick();
            }
            else if (effect == "regurgitation")
            {
                checkThreeNonAdjcentIsClick();
            }
            else
            {
                checkIsClick();
            }
        }
    }

    public void WriteUpCardEffect(string effect)
    {
        this.effect = effect;
        switch (effect)
        {
            // effect: remove one cards with thesis in Write-Up card area
            // if a (reference management system) in context card, then IGNORE effect
            case "bibliography":
                bool isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "ReferenceManagementSystem")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE card with thesis in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.Thesis)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove one cards with thesis in Write-Up card area
            // if a (contingency time) in plan card, then IGNORE effect and TurnOver the card
            case "brotherswedding":
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
                    gamePhaseText.text = "Please remove ONE card with thesis in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.Thesis)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;

            // effect: remove one cards with thesis in Write-Up card area
            // if a (reference management system) in context card, then IGNORE effect
            case "references":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "ReferenceManagementSystem")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE card with thesis in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.Thesis)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
            
            // effect: remove one cards with thesis in Write-Up card area
            // if a (revisit research question) in Write-Up card, then IGNORE effect
            case "tunnelvision":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentWriteUpCards)
                {
                    if (cardGameObj == null) { continue; }
                    WriteUpCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                    if (card.cardName == "RevisitResearchQuestions")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove ONE card with thesis in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.Thesis)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectOne());

                }
                break;
           
            // effect: remove three cards in Write-Up card area
            // if a (Research data management strategy) in plan card, then IGNORE effect
            case "bluescreen":
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
                    gamePhaseText.text = "Please remove THREE cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectThree());

                }
                break;
            
            // effect: remove three cards in Write-Up card area
            // if a (Research data management strategy) in plan card, then IGNORE effect
            case "doesitwork":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentWriteUpCards)
                {
                    if (cardGameObj == null) { continue; }
                    WriteUpCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                    if (card.cardName == "Evaluation")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove THREE cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectThree());

                }
                break;
            
            // effect: remove Four cards in Write-Up card area
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
                    gamePhaseText.text = "Please remove FOUR cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectFour());

                }
                break;
            
            // effect: remove two cards in Write-Up card area
            // if a (Support From Family And Friends) in Write-Up card, then IGNORE effect
            case "lostenthus":
                isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentWriteUpCards)
                {
                    if (cardGameObj == null) { continue; }
                    WriteUpCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                    if (card.cardName == "SupportFromFamilyAndFriends")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please remove TWO card in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two cards in Write-Up card area
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
                    gamePhaseText.text = "Please remove Two cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two non-adjacent cards in Write-Up card area
            // if a (Milestones) in plan card, then remove one card
            case ("distraction"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please remove ONE cards in Write-Up cards area";
                        WriteUpDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentWriteUpCards[i] != null)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentWriteUpCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO non-adjacent cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two non-adjacent cards in Write-Up card area
            // if a (Milestones) in plan card, then remove one card
            case ("distraction2"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please remove ONE cards in Write-Up cards area";
                        WriteUpDashTip.gameObject.SetActive(true);
                        RemoveBoard.gameObject.SetActive(true);
                        for (int i = 0; i < 16; i++)
                        {
                            if (activeCardManager.currentWriteUpCards[i] != null)
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentWriteUpCardNum++;
                            }
                        }
                        StartCoroutine(executeEffectOne());
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO non-adjacent cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two non-adjacent cards in Write-Up card area
            // if a (Refine Research questions) in context card or a (revisit research questions) in write-up card, then IGNORE effect 
            case ("dotoomuch"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "RefineResearchQuestions")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        return;
                    }
                }
                foreach (GameObject cardGameObj in activeCardManager.currentWriteUpCards)
                {
                    if (cardGameObj == null) { continue; }
                    WriteUpCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                    if (card.cardName == "RevisitResearchQuestions")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        return;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO non-adjacent cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two non-adjacent cards in Write-Up card area
            // if a (2+ methodology) or a (very relevant methodology) in context card , then IGNORE effect 
            case ("fitforpurpose"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                int methodNum = 0;
                bool isVeryRelevant = false;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (methodNum == 2 || isVeryRelevant)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "Methodology")
                    {
                        methodNum++;
                    }
                    else if(card.cardName == "VeryRelevantMethodology")
                    {
                        isVeryRelevant = true;
                    }
                }
                
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO non-adjacent cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two (sound conclusions) cards or one (conclusions) in Write-Up card area
            // if a (Very relevant article) AND a (very relevant methodology) in context card , then IGNORE effect 
            case ("disagreement"):
                isCardInEffect = true;
                bool isVeryRelevantArticle = false;
                bool isVeryRelevantMethodology = false;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if(isVeryRelevantArticle && isVeryRelevantMethodology)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "VeryRelevantArticle")
                    {
                        isVeryRelevantArticle = true;
                    }
                    else if(card.cardName == "VeryRelevantMethodology")
                    {
                        isVeryRelevantMethodology = true;
                    }
                    
                }
                
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO Sound Conclusions cards OR Conclusions in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        { 
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.cardName == "SoundConclusions" || card.cardName == "Conclusions")
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentWriteUpCardNum++;
                            }
                        }
                    }
                    StartCoroutine(executeDisagreementEffect());

                }
                break;
            
            // effect: remove two (sound conclusions) cards or one (conclusions) in Write-Up card area
            // if a ( 2+ Very relevant article) in context card , then IGNORE effect 
            case ("sowhat"):
                isCardInEffect = true;
                int veryRelevantArticleNum = 0;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if(veryRelevantArticleNum == 2)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "VeryRelevantArticle")
                    {
                        veryRelevantArticleNum++;
                    }
                }
                
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO Sound Conclusions cards OR Conclusions in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        { 
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            if (card.cardName == "SoundConclusions" || card.cardName == "Conclusions")
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                                currentWriteUpCardNum++;
                            }
                        }
                    }
                    StartCoroutine(executeDisagreementEffect());

                }
                break;
            
            // effect: remove one critical writing cards with thesis in Write-Up card area
            case "waffle":
                gamePhaseText.text = "Please remove ONE Critical writing card in Write-Up cards area";
                WriteUpDashTip.gameObject.SetActive(true);
                RemoveBoard.gameObject.SetActive(true);
                for (int i = 0; i < 16; i++)
                {
                    if (activeCardManager.currentWriteUpCards[i] != null)
                    {
                        WriteUpCard card = activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                        if (card.cardName == "CriticalWriting")
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                        }
                        currentWriteUpCardNum++;
                    }
                }
                StartCoroutine(executeEffectOne());
                break;
            
            // effect: remove two non-adjacent cards in Write-Up card area
            // if a (support from family/friends) or (proofreader) in write-up card, then IGNORE effect 
            case ("jargon"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                foreach (GameObject cardGameObj in activeCardManager.currentWriteUpCards)
                {
                    if (cardGameObj == null) { continue; }
                    WriteUpCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as WriteUpCard;

                    if (card.prevent)
                    {
                        gamePhaseText.text = "You got a explanation card(from proofreader event) which prevent you from removing cards!";
                        return;
                    }

                    if (card.cardName == "SupportFromFamilyAndFriends" || card.cardName == "Proofreader")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove TWO non-adjacent cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove two non-adjacent (critical writing) (explanation) cards in Write-Up card area
            // if a (2+ interpretation) in Implementation card, then IGNORE effect 
            case ("lostvoice"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                int interpretationNum = 0;
                foreach (GameObject cardGameObj in activeCardManager.currentImpCards)
                {
                    if(interpretationNum == 2)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ImplementationCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                    if (card.cardName == "Interpretation")
                    {
                        interpretationNum++;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove non-adjacent Critical writing AND Explanation cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card2 = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            if (card2.cardName == "CriticalWriting" || card2.cardName == "Explanation")
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;
            
            // effect: remove three non-adjacent with thesis cards in Write-Up card area
            // if a (3+ Analysis) OR interpretation in Implementation card, then IGNORE effect 
            case ("regurgitation"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                int analysisNum = 0;
                bool hasInterpretation = false;
                foreach (GameObject cardGameObj in activeCardManager.currentImpCards)
                {
                    if(analysisNum == 3 || hasInterpretation)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ImplementationCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                    if (card.cardName == "Analysis")
                    {
                        analysisNum++;
                    } 
                    else if (card.cardName == "Interpretation")
                    {
                        hasInterpretation = true;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[3];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove THREE non-adjacent with thesis cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card2 = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectThree());

                }
                break;
            
            // effect: remove two non-adjacent (critical writing) (explanation) cards in Write-Up card area
            // if a (3+ relevant article) OR (very relevant article )in context card, then IGNORE effect 
            case ("uncriticalwriting"):
                isCardInEffect = true;
                hasRemovedWriteUpCardObjects = new List<GameObject>();
                int relevantArticleNum = 0;
                bool hasVeryRelevantArticle = false;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if(relevantArticleNum == 3 || hasVeryRelevantArticle)
                    {
                        isCardInEffect = false;
                        gamePhaseText.text = "Please check if you need to remove the card";
                        break;
                    }
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "RelevantArticle")
                    {
                        relevantArticleNum++;
                    } 
                    else if(card.cardName == "VeryRelevantArticle")
                    {
                        hasVeryRelevantArticle = true;
                    }
                }
                if (isCardInEffect)
                {
                    currentWriteUpCards = new string[16];
                    hasRemovedWriteUpCards = new string[2];
                    for(int i = 0; i<16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[i] = card.cardName;
                        }
                    }
                    gamePhaseText.text = "Please remove non-adjacent Critical writing AND Explanation cards in Write-Up cards area";
                    WriteUpDashTip.gameObject.SetActive(true);
                    RemoveBoard.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (activeCardManager.currentWriteUpCards[i] != null)
                        {
                            WriteUpCard card2 = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                            if (card2.cardName == "CriticalWriting" || card2.cardName == "Explanation")
                            {
                                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 1;
                            }
                            currentWriteUpCardNum++;
                        }
                    }
                    StartCoroutine(executeEffectTwo());

                }
                break;

        }
    }

    public void checkIsClick()
    {
        int count = 0;
        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                count++;
            }
        }
        if (currentWriteUpCardNum > count)
        {
            hasRemovedList++;
            currentWriteUpCardNum--;
        }
    }

    public void checkNonAdjcentIsClick()
    {
        if (hasRemovedList == 2) { return;;}
        string[] changedWriteUpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                changedWriteUpCards[i] = card.cardName;
            }
            else
            {
                changedWriteUpCards[i] = "";
            }
        }
        for(int i = 0; i < 16; i++)
        {
            if(currentWriteUpCards.Length == 0)
            {
                break;
            }
            if (currentWriteUpCards[i] != null)
            {
                GameObject card = activeCardManager.currentWriteUpCards[i];
                if ((currentWriteUpCards[i] != changedWriteUpCards[i]) && (!hasRemovedWriteUpCardObjects.Contains(card)))
                {
                    hasRemovedWriteUpCardObjects.Add(card);
                    hasRemovedList++;
                    if (i > 0)
                    {
                        if (activeCardManager.currentWriteUpCards[i - 1] != null)
                        {
                            activeCardManager.currentWriteUpCards[i-1].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
                        }
                    }
                    if (i < 15)
                    {
                        if (activeCardManager.currentWriteUpCards[i + 1] != null)
                        {
                            activeCardManager.currentWriteUpCards[i+1].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
                        }
                    }
                    
                }
            }
        }
    }
    
    public void checkThreeNonAdjcentIsClick()
    {
        if (hasRemovedList == 3) { return;;}
        string[] changedWriteUpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                changedWriteUpCards[i] = card.cardName;
            }
            else
            {
                changedWriteUpCards[i] = "";
            }
        }
        for(int i = 0; i < 16; i++)
        {
            if(currentWriteUpCards.Length == 0)
            {
                break;
            }
            if (currentWriteUpCards[i] != null)
            {
                GameObject card = activeCardManager.currentWriteUpCards[i];
                if ((currentWriteUpCards[i] != changedWriteUpCards[i]) && (!hasRemovedWriteUpCardObjects.Contains(card)))
                {
                    hasRemovedWriteUpCardObjects.Add(card);
                    hasRemovedList++;
                    if (i > 0)
                    {
                        if (activeCardManager.currentWriteUpCards[i - 1] != null)
                        {
                            activeCardManager.currentWriteUpCards[i-1].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
                        }
                    }
                    if (i < 15)
                    {
                        if (activeCardManager.currentWriteUpCards[i + 1] != null)
                        {
                            activeCardManager.currentWriteUpCards[i+1].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
                        }
                    }
                    
                }
            }
        }
    }
    
    
    public int clickNum1 = 0;
    public bool isClickCondition2 = false;
    public void checkDisagreementClick()
    {
        if (isClickCondition2 || (clickNum1==2))
        {
            return;
        }

        string[] changedWriteUpCards = new string[16];
        for(int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                WriteUpCard card = activeCardManager.currentWriteUpCards[i].GetComponent<ShowCard>().card as WriteUpCard;
                changedWriteUpCards[i] = card.cardName;
            }
            else
            {
                changedWriteUpCards[i] = "";
            }
        }
        
        for (int i = 0; i < 16; i++)
        {
            if(currentWriteUpCards.Length == 0)
            {
                break;
            }
            if (currentWriteUpCards[i] != changedWriteUpCards[i])
            {
                if (currentWriteUpCards[i] == "SoundConclusions" && clickNum1 < 2)
                {
                    clickNum1++;
                    
                    // copy currentWriteUpCards to currentWriteUpCards
                    for(int x = 0; x<16; x++)
                    {
                        if (activeCardManager.currentWriteUpCards[x] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[x].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[x] = card.cardName;
                        }
                        else
                        {
                            currentWriteUpCards[x] = "";
                        }
                    }
                    
                    break;
                }
                else if ((currentWriteUpCards[i] == "Conclusions") && !isClickCondition2)
                {
                    isClickCondition2 = true;
                    
                    // copy currentWriteUpCards to currentWriteUpCards
                    for(int j = 0; j<16; j++)
                    {
                        if (activeCardManager.currentWriteUpCards[j] != null)
                        {
                            WriteUpCard card = activeCardManager.currentWriteUpCards[j].GetComponent<ShowCard>().card as WriteUpCard;
                            currentWriteUpCards[j] = card.cardName;
                        }
                        else
                        {
                            currentWriteUpCards[j] = "";
                        }
                    }
                    
                    break;
                }
            }
        }
    }
    public IEnumerator executeDisagreementEffect()
    {
        yield return new WaitUntil(() => (isClickCondition2 || (clickNum1==2)));
        hasRemovedList = 0;
        currentWriteUpCardNum = 0;
        clickNum1 = 0;
        isClickCondition2 = false;
        WriteUpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next WriteUp event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    
    
    public IEnumerator executeContextEffectOne()
    {
        yield return new WaitUntil(() => hasRemovedList == 1);
        hasRemovedList = 0;
        currentContextCardNum = 0;
        currentWriteUpCards = new string[16];
        hasRemovedWriteUpCards = new string[3];
        ContextDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Write-Up event cards or finished event card draw";
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
        currentWriteUpCardNum = 0;
        currentWriteUpCards = new string[16];
        hasRemovedWriteUpCards = new string[3];
        WriteUpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Write-Up event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectTwo()
    {
        yield return new WaitUntil(() => hasRemovedList == 2);
        hasRemovedList = 0;
        currentWriteUpCards = new string[16];
        hasRemovedWriteUpCards = new string[3];
        currentWriteUpCardNum = 0;
        WriteUpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Write-Up event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }

    public IEnumerator executeEffectThree()
    {
        yield return new WaitUntil(() => hasRemovedList == 3);
        hasRemovedList = 0;
        currentWriteUpCards = new string[16];
        hasRemovedWriteUpCards = new string[3];
        currentWriteUpCardNum = 0;
        WriteUpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Write-Up event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
    
    public IEnumerator executeEffectFour()
    {
        yield return new WaitUntil(() => hasRemovedList == 4);
        hasRemovedList = 0;
        currentWriteUpCards = new string[16];
        hasRemovedWriteUpCards = new string[3];
        currentWriteUpCardNum = 0;
        WriteUpDashTip.gameObject.SetActive(false);
        RemoveBoard.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next Write-Up event cards or finished event card draw";
        this.effect = "";

        for (int i = 0; i < 16; i++)
        {
            if (activeCardManager.currentWriteUpCards[i] != null)
            {
                activeCardManager.currentWriteUpCards[i].gameObject.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }
    }
}
  

