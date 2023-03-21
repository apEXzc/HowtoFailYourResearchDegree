using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class RemindWindow : MonoBehaviour
{

    public ActiveCardManager activeCardManager;
    public GameObject remindPanel;
    public PlayManager playManager;
    public RoundButton roundButton;
    public BlockFeatureEffect blockFeatureEffect;

    public bool remindUncorrectCard()
    {
        // shows tips when player doesn't remove uncorrect active card and stop to enter next game phase.
        if (activeCardManager.removeCards.Count > 0)
        {
            remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please remove all uncorrect Active Card !";
            remindPanel.gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    public bool checkHasCardInBg()
    {
        bool hasCard = false;
        switch (playManager.gamePhase)
        {
            case GamePhase.planDraw:
                foreach(GameObject card in activeCardManager.currentPlanCards){
                    if (card != null) {
                        return false;
                    }
                }
                hasCard = true;
                break;
            case GamePhase.contextDraw:
                foreach (GameObject card in activeCardManager.currentContextCards)
                {
                    if (card != null)
                    {
                        return false;
                    }
                }
                hasCard = true;
                break;
            case GamePhase.ImpDraw:
                foreach (GameObject card in activeCardManager.currentImpCards)
                {
                    if (card != null)
                    {
                        return false;
                    }
                }
                hasCard = true;
                break;
            case GamePhase.writeUpDraw:
                foreach (GameObject card in activeCardManager.currentWriteUpCards)
                {
                    if (card != null)
                    {
                        return false;
                    }
                }
                hasCard = true;
                break;
        }

        if (hasCard) {
            remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please draw at least one Active Card !";
            remindPanel.gameObject.SetActive(true);
            return true;
        }
        return false;
    }

    public void remindGameOver()
    {

        remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "The game fails!";
        remindPanel.gameObject.transform.Find("BackButton").gameObject.SetActive(false);
        remindPanel.gameObject.transform.Find("GameFailButtons").gameObject.SetActive(true);
        remindPanel.gameObject.SetActive(true);

    }

    public void OnClickNewGameButton() {
        SceneManager.LoadScene("MainScenes");
    }

    public void OnClickQuitButton()
    {
        SceneManager.LoadScene("StartScenes");
    }

    public bool remindClickEventCard() {

        switch (playManager.gamePhase) {

            case GamePhase.eventContextDraw:
                if ((roundButton.EventContextCardObjects[1].GetComponent<RectTransform>().anchoredPosition == new UnityEngine.Vector2(0, 0))
                    || (roundButton.EventContextCardObjects[0].GetComponent<Button>().IsActive()))
                {
                    remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please click all event context card!";
                    remindPanel.gameObject.SetActive(true);
                    return true;
                }
                break;
            case GamePhase.eventImpDraw:
                if ((roundButton.EventImpCardObjects[1].GetComponent<RectTransform>().anchoredPosition == new UnityEngine.Vector2(0, 0))
                     || (roundButton.EventImpCardObjects[0].GetComponent<Button>().IsActive()))
                {
                    remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please click all event implementation card!";
                    remindPanel.gameObject.SetActive(true);
                    return true;
                }
                break;
            case GamePhase.eventWriteUpDraw:
                if ((roundButton.EventWriteUpObjects[1].GetComponent<RectTransform>().anchoredPosition == new UnityEngine.Vector2(0, 0))
                    || (roundButton.EventWriteUpObjects[0].GetComponent<Button>().IsActive()))
                {
                    remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please click all event write up card!";
                    remindPanel.gameObject.SetActive(true);
                    return true;
                }
                break;
        }
        return false;
    }

    //public bool remindClickEventOnebyOne() {

    //    if (!eventCardEffect.EventFinished && !roundButton.EventContextCover.activeInHierarchy) {
    //        remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text = "Please Finish this event card first!";
    //        remindPanel.gameObject.SetActive(true);
    //        return false;
    //    }
    //    return true;
    //}
}
