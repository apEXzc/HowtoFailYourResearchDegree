using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WriteUpSpecialEffect : MonoBehaviour
{
    public TMPro.TMP_Text gamePhaseText;
    public GameObject WriteUpDashTip;
    public ActiveCardManager activeCardManager;
    public LoadData loadData;
    public GameObject WriteUpCardPrefab;
    public GameObject WriteUpCardPool;

    public bool isAdd = false;
    public int totalBg = 0;
    public GameObject Ecard;

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

    public void WriteUpCardEffect(string effect)
    { 

        //EventFinished = false;
        this.effect = effect;

        switch (effect)
        {
            // effect: add a explanation card from card pool in Write-Up area
            case "proofreader":
                gamePhaseText.text = "You may add one explanation card from Write-Up card pool";
                WriteUpDashTip.gameObject.SetActive(true);
                GameObject ActiveNewWriteUpCard = GameObject.Instantiate(WriteUpCardPrefab, WriteUpCardPool.transform);
                for (int i = 0; i < 16; i++)
                {
                    if (i < 12 && loadData.WriteUpCardList[i].cardName == "Explanation")
                    {
                        ActiveNewWriteUpCard.GetComponent<ShowCard>().card = loadData.WriteUpCardList[i];
                        WriteUpCard card = ActiveNewWriteUpCard.GetComponent<ShowCard>().card as WriteUpCard;
                        card.prevent = true;
                        Ecard = ActiveNewWriteUpCard;
                    }
                    if(activeCardManager.currentWriteUpCards[i] == null)
                    {
                        activeCardManager.WriteUpCardBgList[i].gameObject.SetActive(true);
                        totalBg++;
                    }
                }
                StartCoroutine(executeEffect());
                break;
        }
    }

    public void checkIsAdd()
    {
        int currentBg = 0;
        for (int i = 0; i < 16; i++)
        {
            if(activeCardManager.WriteUpCardBgList[i].gameObject.activeInHierarchy)
            {
                currentBg++;
                activeCardManager.currentWriteUpCards[i] = Ecard;
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
            activeCardManager.WriteUpCardBgList[i].gameObject.SetActive(false);
        }
        WriteUpDashTip.gameObject.SetActive(false);
        gamePhaseText.text = "Good job! Please click next context event cards or finished event card draw";
        this.effect = "";
    }
}


