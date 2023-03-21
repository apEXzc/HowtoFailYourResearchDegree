using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlockImpFeatureEffect : MonoBehaviour
{
    public TMPro.TMP_Text gamePhaseText;
    public GameObject writeUpDashTip;
    public ActiveCardManager activeCardManager;

    public List<Transform> hasClickList = new List<Transform>();
    public int clickCount = 0;
    
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

    public void ImpCardEffect(string effect)
    { 

        //EventFinished = false;
        this.effect = effect;

        switch (effect)
        {
            // effect: block two card background in Write-Up area
            // if a (Milestone) in plan card, then IGNORE effect
            case "supervisorsick":
                bool isCardInEffect = true;
                foreach (GameObject cardGameObj in activeCardManager.currentPlanCards)
                {
                    if (cardGameObj == null) { continue; }
                    PlanCard card = cardGameObj.gameObject.GetComponent<ShowCard>().card as PlanCard;
                    if (card.cardName == "Milestones")
                    {
                        gamePhaseText.text = "Please check if you need to remove the card";
                        isCardInEffect = false;
                        break;
                    }
                }
                if (isCardInEffect)
                {
                    gamePhaseText.text = "Please block two card background in Write-Up area";
                    writeUpDashTip.gameObject.SetActive(true);
                    for (int i = 0; i < 16; i++)
                    {
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
            Transform writeUpCardBg = activeCardManager.WriteUpCardBgList[i];
            if (writeUpCardBg.gameObject.transform.Find("BlockBg").gameObject.activeInHierarchy && !hasClickList.Contains(writeUpCardBg))
            {
                writeUpCardBg.gameObject.GetComponent<MapManager>().id = 100;
                hasClickList.Add(writeUpCardBg);
                clickCount++;
            }
            if (clickCount == 2)
            {
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
        yield return new WaitUntil(() => (clickCount == 2));
        clickCount = 0;
        writeUpDashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";
    }
}
