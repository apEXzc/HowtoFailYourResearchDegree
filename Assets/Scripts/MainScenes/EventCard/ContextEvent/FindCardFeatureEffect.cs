using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FindCardFeatureEffect : MonoBehaviour
{

    public TMPro.TMP_Text gamePhaseText;
    public GameObject planDashTip;
    public GameObject contextDashTip;
    public ActiveCardManager activeCardManager;
    public RoundButton roundButton;

    public bool isDrop = false;
    public int dropIndex;   
    public string effect = "";
    
    // for ehical clearance card 
    public GameObject EthicalClearanceCard;
    public Transform[] PlanCardBgList = new Transform[8];

    // for sources win card
    public GameObject VeryRelevantArticle;
    public Transform[] ContextCardBgList = new Transform[16];
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (effect != "")
        {
            if(effect == "advicefromacademic")
            {
                checkPlanIsDrop();
            }
            else if(effect == "sourceswin")
            {
                checkContextIsDrop();
            }
        }
    }

    public void ContextCardEffect(string effect)
    {

        //EventFinished = false;
        this.effect = effect;

        switch (effect)
        {
            // effect: drop one (Ethical Clearance) cards in plan card pool
            // if no Ethical Clearance in plan card pool, then IGNORE effect
            case "advicefromacademic":
                // forloop to check if there is a Ethical clearance card in the plan card list
                bool satisfied1 = false;
                bool satisfied2 = false;
                for(int i = 0; i<8; i++)
                {
                    if(roundButton.PlanCardObjects[i] != null && !satisfied1)
                    {
                        PlanCard card = roundButton.PlanCardObjects[i].gameObject.GetComponent<ShowCard>().card as PlanCard;
                        if (card.cardName == "EthicalClearance")
                        {
                            satisfied1 = true;
                            EthicalClearanceCard = roundButton.PlanCardObjects[i];
                        }
                    }
                    if (activeCardManager.currentPlanCards[i] == null && !satisfied2)
                    {
                        satisfied2 = true;
                    }
                }
                if (satisfied1 && satisfied2)
                {
                    gamePhaseText.text = "Please drag a Ethical Clearance card to your plan card area.";
                    planDashTip.gameObject.SetActive(true);
                    for(int i = 0; i<8; i++)
                    {
                        // appear one Ethical Clearance card in the plan card pool, then hide all other cards
                        if(roundButton.PlanCardObjects[i] != null && roundButton.PlanCardObjects[i] != EthicalClearanceCard)
                        {
                            roundButton.PlanCardObjects[i].SetActive(false);
                        }

                        // appear all empty plan card area
                        if (activeCardManager.currentPlanCards[i] == null)
                        {
                            activeCardManager.PlanCardBgList[i].gameObject.SetActive(true);
                            PlanCardBgList[i] = activeCardManager.PlanCardBgList[i];
                        }
                    }
                    EthicalClearanceCard.GetComponent<DragAndDrop>().enabled = true;
                    StartCoroutine(executeAdvicefromacademicEffect());
                }
                else
                {
                    gamePhaseText.text = "Sorry! There is no Ethical Clearance card in your plan card area.";
                }
                break;
            
            // effect: drop one (very relevant article) cards in context card pool
            // if no very relevant article in context card pool, then IGNORE effect
            case "sourceswin":
                // forloop to check if there is a very relevant article card in the context card list
                satisfied1 = false;
                satisfied2 = false;
                for(int i = 0; i<16; i++)
                {
                    if(roundButton.ContextCardObjects[i] != null && !satisfied1)
                    {
                        ContextCard card = roundButton.ContextCardObjects[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if (card.cardName == "VeryRelevantArticle")
                        {
                            satisfied1 = true;
                            VeryRelevantArticle = roundButton.ContextCardObjects[i];
                        }
                    }
                    if (activeCardManager.currentContextCards[i] == null && !satisfied2)
                    {
                        satisfied2 = true;
                    }
                }
                if (satisfied1 && satisfied2)
                {
                    gamePhaseText.text = "Please drag a Very Relevant Article card to your context card area.";
                    contextDashTip.gameObject.SetActive(true);
                    for(int i = 0; i<16; i++)
                    {
                        // appear one Very Relevant Article card in the context card pool, then hide all other cards
                        if(roundButton.ContextCardObjects[i] != null && roundButton.ContextCardObjects[i] != VeryRelevantArticle)
                        {
                            roundButton.ContextCardObjects[i].SetActive(false);
                        }

                        // appear all empty context card area
                        if (activeCardManager.currentContextCards[i] == null)
                        {
                            activeCardManager.ContextCardBgList[i].gameObject.SetActive(true);
                            ContextCardBgList[i] = activeCardManager.ContextCardBgList[i];
                        }
                    }
                    VeryRelevantArticle.GetComponent<DragAndDrop>().enabled = true;
                    StartCoroutine(executeSourceswinEffect());
                }
                else
                {
                    gamePhaseText.text = "Sorry! There is no Very Relevant Article card in your context card area.";
                }
                break;
        }
    }



    public void checkPlanIsDrop()
    {
        int i = 0;
        foreach(Transform PlanCardBg in PlanCardBgList)
        {
            if (PlanCardBg != null && !PlanCardBg.gameObject.activeInHierarchy)
            {
                isDrop = true;
                dropIndex = i;
            }
            i++;
        }
        
    }
    
    public void checkContextIsDrop()
    {
        int i = 0;
        foreach(Transform ContextCardBg in ContextCardBgList)
        {
            if (ContextCardBg != null && !ContextCardBg.gameObject.activeInHierarchy)
            {
                isDrop = true;
                dropIndex = i;
            }
            i++;
        }
        
    }

    public IEnumerator executeAdvicefromacademicEffect()
    {
        yield return new WaitUntil(() => (isDrop == true));
        isDrop = false;
        planDashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Great! Please click next context event cards or finished event card draw !";
        PlanCardBgList = new Transform[8];
        activeCardManager.currentPlanCards[dropIndex] = EthicalClearanceCard;
        dropIndex = -1;
        this.effect = "";

        for (int i = 0; i < 8; i++)
        {
            if (roundButton.PlanCardObjects[i] != null && roundButton.PlanCardObjects[i] != EthicalClearanceCard)
            {
                roundButton.PlanCardObjects[i].SetActive(true);
            }
            else if (roundButton.PlanCardObjects[i] == EthicalClearanceCard)
            {
                roundButton.PlanCardObjects[i] = null;
            }
        }
    }
    
    public IEnumerator executeSourceswinEffect()
    {
        yield return new WaitUntil(() => (isDrop == true));
        isDrop = false;
        contextDashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Great! Please click next context event cards or finished event card draw !";
        ContextCardBgList = new Transform[16];
        activeCardManager.currentContextCards[dropIndex] = VeryRelevantArticle;
        dropIndex = -1;
        this.effect = "";

        for (int i = 0; i < 8; i++)
        {
            if (roundButton.ContextCardObjects[i] != null && roundButton.ContextCardObjects[i] != VeryRelevantArticle)
            {
                roundButton.ContextCardObjects[i].SetActive(true);
            }
            else if (roundButton.ContextCardObjects[i] == VeryRelevantArticle)
            {
                roundButton.ContextCardObjects[i] = null;
            }
        }
    }
}
