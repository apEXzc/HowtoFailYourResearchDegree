using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockFeatureEffect : MonoBehaviour
{

    public TMPro.TMP_Text gamePhaseText;
    public GameObject dashTip;
    public ActiveCardManager activeCardManager;

    //public bool EventFinished = true;

    public bool isClick1 = false;
    public bool isClick2 = false;
    public List<Transform> hasBlockedList = new List<Transform>();

    public string effect = "";

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(effect != "")
        {
            checkIsClick();
        }
    }

    public void ContextCardEffect(string effect)
    {

        //EventFinished = false;
        this.effect = effect;

        switch (effect)
        {
            // effect: block one card background in both Implementation and Write-Up area
            // if a (Milestone) AND (Meeting with supervisor) in plan card, then IGNORE effect
            case "writersblock":
                bool isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones" || card.cardName == "MeetingsWithSupervisor")
                    {
                        foreach (GameObject cardGameObj2 in activeCardManager.currentPlanCards)
                        {
                            if (cardGameObj2 == null) { continue; }
                            PlanCard card2 = cardGameObj2.gameObject.GetComponent<ShowCard>().card as PlanCard;
                            if ((card2.cardName == "Milestones") && (card.cardName == "MeetingsWithSupervisor")
                                || (card.cardName == "Milestones") && (card2.cardName == "MeetingsWithSupervisor"))
                            {
                                gamePhaseText.text = "Please check if you need to remove the card";
                                isCardInEffect = false;
                                break;
                            }
                        }
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please block one card background in both Implementation and Write-Up area";
                    dashTip.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (!activeCardManager.ImpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.ImpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;

                        }
                        if (!activeCardManager.WriteUpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.WriteUpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;
                        }
                    }
                    StartCoroutine(executeEffect());

                }
                break;

            // effect: block one card background in both Implementation and Write-Up area
            // if a (refine research questions ) OR 2+(very relevant article) in context card, then IGNORE effect
            case "litreviewparadox":
                bool isCardInEffect1 = true;
                int x = 0;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "RefineResearchQuestions")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect1 = false;
                        break;
                    }
                    else if (card.cardName == "VeryRelevantArticle")
                    {
                        int y = 0;
                        foreach (GameObject cardGameObj2 in activeCardManager.currentContextCards)
                        {
                            if (cardGameObj2 == null) { continue; }
                            ContextCard card2 = cardGameObj2.gameObject.GetComponent<ShowCard>().card as ContextCard;
                            if ((x != y)
                                && (card2.cardName == "VeryRelevantArticle")
                                && (card.cardName == "VeryRelevantArticle"))
                            {
                                gamePhaseText.text = "Please check if you need to remove the card";
                                isCardInEffect1 = false;
                                break;
                            }
                            y++;
                        }
                    }
                    x++;
                }
                if (isCardInEffect1)
                {
                    gamePhaseText.text = "Please block one card background in both Implementation and Write-Up area";
                    dashTip.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (!activeCardManager.ImpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.ImpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;

                        }
                        if (!activeCardManager.WriteUpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.WriteUpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;
                        }
                    }
                    StartCoroutine(executeEffect());

                }
                break;

            // effect: block one card background in both Implementation and Write-Up area
            // if a (contingency time ) in plan card, then IGNORE effect and Turn over the card
            case "shoddynotes":
                bool isCardInEffect2 = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "ContingencyTime")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        cardGameObj.transform.Find("TurnOver").gameObject.SetActive(true);
                        card.cardName = "null";
                        isCardInEffect2 = false;
                        break;
                    }
                }
                if (isCardInEffect2)
                {
                    gamePhaseText.text = "Please block one card background in both Implementation and Write-Up area";
                    dashTip.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
                        if (!activeCardManager.ImpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.ImpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;

                        }
                        if (!activeCardManager.WriteUpCardBgList[i].gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy)
                        {
                            activeCardManager.WriteUpCardBgList[i].gameObject.GetComponent<Button>().enabled = true;
                        }
                    }

                    StartCoroutine(executeEffect());

                }
                break;

        }
    }



    public void checkIsClick()
    {

        for (int i = 0; i < 16; i++)
        {
            Transform ImpCardBg = activeCardManager.ImpCardBgList[i];
            if (!isClick1 && ImpCardBg.gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy && !hasBlockedList.Contains(ImpCardBg))
            {
                isClick1 = true;

                hasBlockedList.Add(ImpCardBg);
                ImpCardBg.gameObject.GetComponent<MapManager>().id = 100;

                foreach (Transform card in activeCardManager.ImpCardBgList)
                {
                    card.gameObject.GetComponent<Button>().enabled = false;
                }

                break;
            }

            Transform writeUpCardBg = activeCardManager.WriteUpCardBgList[i];
            if (!isClick2 && writeUpCardBg.gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy && !hasBlockedList.Contains(writeUpCardBg))
            {
                isClick2 = true;

                hasBlockedList.Add(writeUpCardBg);
                writeUpCardBg.gameObject.GetComponent<MapManager>().id = 100;

                foreach (Transform card in activeCardManager.WriteUpCardBgList)
                {
                    card.gameObject.GetComponent<Button>().enabled = false;
                }

                break;
            }
        }
    }

    public IEnumerator executeEffect()
    {
        yield return new WaitUntil(() => ((isClick1 == true) && (isClick2 == true)));
        isClick1 = false;
        isClick2 = false;
        dashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";
        //EventFinished = true;
    }
}
