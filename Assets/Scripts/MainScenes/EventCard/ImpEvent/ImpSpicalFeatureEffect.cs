using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImpSpicalFeatureEffect : MonoBehaviour
{
    public TMPro.TMP_Text gamePhaseText;
    public GameObject ImpDashTip;
    public ActiveCardManager activeCardManager;
    public LoadData loadData;
    public GameObject ImplementationCardPrefab;
    public GameObject ImpCardPool;
    
    public bool isAdd = false;
    public int totalBg = 0;

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
            checkIsAdd();
        }
    }

    public void ImpCardEffect(string effect)
    { 

        //EventFinished = false;
        this.effect = effect;

        switch (effect)
        {
            // effect: add a interpretation card from card pool in Implementation area
            // if a (resource(policy)) in context card
            case "relevance":
                bool isCardInEffect = false;
                foreach (GameObject cardGameObj in activeCardManager.currentContextCards)
                {
                    if (cardGameObj == null) { continue; }
                    ContextCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (card.cardName == "Resource(policy)")
                    {
                        isCardInEffect = true;
                        break;
                    }
                }
                if (!isCardInEffect)
                {
                    gamePhaseText.text = "Please check if you need to remove or add the card";
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "You may add one interpretation card from Implementation pool";
                    ImpDashTip.gameObject.SetActive(true);
                    GameObject ActiveNewImplementationCard = GameObject.Instantiate(ImplementationCardPrefab, ImpCardPool.transform);
                    for (int i = 0; i < 16; i++)
                    {
                        if (i < 14 && loadData.ImplementationList[i].cardName == "Interpretation")
                        {
                            ActiveNewImplementationCard.GetComponent<ShowCard>().card = loadData.ImplementationList[i];
                        }
                        if(activeCardManager.currentImpCards[i] == null)
                        {
                            activeCardManager.ImpCardBgList[i].gameObject.SetActive(true);
                            totalBg++;
                        }
                    }
                    StartCoroutine(executeEffect());
                }
                break;
        }
    }



    public void checkIsAdd()
    {
        int currentBg = 0;
        for (int i = 0; i < 16; i++)
        {
            if(activeCardManager.ImpCardBgList[i].gameObject.activeInHierarchy)
            {
                currentBg++;
            }
        }
        if (currentBg != totalBg)
        {
            isAdd = true;
        }
    }

    public IEnumerator executeEffect()
    {
        yield return new WaitUntil(() => (isAdd));
        isAdd = false;
        totalBg = 0;
        for (int i = 0; i < 16; i++)
        {
            activeCardManager.ImpCardBgList[i].gameObject.SetActive(false);
        }
        ImpDashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";
    }
}

