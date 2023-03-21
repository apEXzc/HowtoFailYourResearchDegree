using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * This file trying to create a series of game phase:
 * PhaseCheck() is to change round when user click round button each time
 * -----------------------------------------------------------------------------------------
 * gameStart
 * planCardDraw---checkDeck
 * contextCardDraw----checkDeck----eventContextCardDraw----checkDeck
 * ImpCardDraw----checkDeck----eventImpCardDraw----checkDeck
 * writeUpCardDraw----checkDeck----eventwriteUpCardDraw----checkDeck
 * gameEnd → active result button
 * -----------------------------------------------------------------------------------------
 */



public static class Extensions
{
    // Create a 'next()' function for GamePhase
    public static T next<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) + 1;
        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }

    // Create a 'prev()' function for GamePhase
    public static T prev<T>(this T src) where T : struct
    {
        if (!typeof(T).IsEnum) throw new ArgumentException(String.Format("Argument {0} is not an Enum", typeof(T).FullName));

        T[] Arr = (T[])Enum.GetValues(src.GetType());
        int j = Array.IndexOf<T>(Arr, src) - 1;
        return (Arr.Length == j) ? Arr[0] : Arr[j];
    }

    // transfer euum to int type
    public static int toInt(this System.Enum e)
    {
        return e.GetHashCode();
    }

}


public enum GamePhase {

    gameStart,
    planDraw, checkPlan,
    contextDraw, checkContext, eventContextDraw, checkEventContext,
    ImpDraw, checkImp, eventImpDraw, checkEventImp,
    writeUpDraw, checkWriteUp, eventWriteUpDraw, checkEventWriteUp,
    gameEnd
}


public class PlayManager : MonoBehaviour
{

    public GamePhase gamePhase = GamePhase.gameStart;
    public TMPro.TMP_Text gamePhaseText;

    public GameObject ResultButton;

    // Start is called before the first frame update
    void Start()
    {
        //test();
    }

    // Update is called once per frame
    void Update()
    {
        
    }



    public void PhaseUpdate() {

        if (gamePhase != GamePhase.gameEnd) {
            gamePhase = gamePhase.next();
        }

        switch (gamePhase)
        {
            //--------------------------------------------------------
            case GamePhase.planDraw:
                gamePhaseText.text = "Begin to draw plan cards!!!";
                break;
            case GamePhase.checkPlan:
                gamePhaseText.text = "Please check your plan cards";
                break;
            //--------------------------------------------------------
            case GamePhase.contextDraw:
                gamePhaseText.text = "Begin to draw context cards!!!";
                break;
            case GamePhase.checkContext:
                gamePhaseText.text = "Please check your context cards";
                break;
            case GamePhase.eventContextDraw:
                gamePhaseText.text = "Please click context event cards";
                break;
            case GamePhase.checkEventContext:
                gamePhaseText.text = "Please check your context cards again";
                break;
            //--------------------------------------------------------
            case GamePhase.ImpDraw:
                gamePhaseText.text = "Begin to draw implementation cards!!!";
                break;
            case GamePhase.checkImp:
                gamePhaseText.text = "Please check your implementation cards";
                break;
            case GamePhase.eventImpDraw:
                gamePhaseText.text = "Please click event implementation cards";
                break;
            case GamePhase.checkEventImp:
                gamePhaseText.text = "Please check your implementation cards again";
                break;
            //--------------------------------------------------------
            case GamePhase.writeUpDraw:
                gamePhaseText.text = "Begin to draw write-up cards!!!";
                break;
            case GamePhase.checkWriteUp:
                gamePhaseText.text = "Please check your write-up cards";
                break;
            case GamePhase.eventWriteUpDraw:
                gamePhaseText.text = "Please click event write-up cards";
                break;
            case GamePhase.checkEventWriteUp:
                gamePhaseText.text = "Please check your write-up cards again";
                break;
            //--------------------------------------------------------
            case GamePhase.gameEnd:
                gamePhaseText.text = "Game over";
                ResultButton.gameObject.SetActive(true);
                break;
        }
    }

    //public void test()
    //{

    //    PhaseCheck();
    //    Debug.Log(gamePhaseCount.ToString() + "      " + GamePhase.ToString());
    //}



}

