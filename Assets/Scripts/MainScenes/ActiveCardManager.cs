using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UIElements;

/*
 * This script try to obtain all active card background object from the main scene(GetAllBackgroundObj method), 
 * continuously update the position of the active card objects(activeCardPositionUpdate method).
 */

public class ActiveCardManager : MonoBehaviour
{

    public PlayManager playManager;
    public RoundButton roundButton;
    public RemindWindow remindWindow;

    // All background object
    public List<Transform> PlanCardBgList = new List<Transform>();
    public List<Transform> ContextCardBgList = new List<Transform>();
    public List<Transform> ImpCardBgList = new List<Transform>();
    public List<Transform> WriteUpCardBgList = new List<Transform>();

    // The position of all active card objects
    public GameObject[] currentPlanCards = new GameObject[16];
    public GameObject[] currentContextCards = new GameObject[16];
    public GameObject[] currentImpCards = new GameObject[16];
    public GameObject[] currentWriteUpCards = new GameObject[16];

    public List<GameObject> removeCards = new List<GameObject>();

    // control the show time of remove board
    public GameObject removeBoard;

    // Start is called before the first frame update
    void Start()
    {
        GetAllBackgroundObj();
    }

    // Update is called once per frame
    void Update()
    {
        int phaseCount = playManager.gamePhase.toInt();
        if (phaseCount < 14 && (phaseCount % 2) != 0)
        {
            // removeBoard.gameObject.SetActive(false);
            activeCardPositionUpdate(); // Real-time update
        }
        else if (phaseCount < 14 && (phaseCount % 2) == 0)// check active card phase
        {
            checkArrows();
        }
    }

    public void GetAllBackgroundObj()
    {
        int count = 0;
        foreach (Transform allChild in this.transform) // 'this.transform' is the game object of ActiveCardGrid
        {
            foreach (Transform child in allChild)
            {
                if (count == 0)
                {
                    PlanCardBgList.Add(child);
                }
                else if (count == 1)
                {
                    ContextCardBgList.Add(child);
                }
                else if (count == 2)
                {
                    ImpCardBgList.Add(child);
                }
                else
                {
                    WriteUpCardBgList.Add(child);
                }

            }
            count++;
        }
    }

    public int count = 0; // Each draw active card phase, count the number of 'random cards' which has been drawing, second one is total random cards currently
    public GamePhase currentPhase;
    public void activeCardPositionUpdate()
    {
        if (currentPhase != playManager.gamePhase)  //if phase has been changed, count returns to zero.
        {
            count = 0;
            currentPhase = playManager.gamePhase;
        }

        for (int i = 0; i < 16; i++)
        {
            switch (playManager.gamePhase)
            {
                case GamePhase.planDraw:
                    if (i > 7) { break; }
                    if ((!PlanCardBgList[i].gameObject.activeInHierarchy) && (currentPlanCards[i] == null)) // when background is not active and the position of that active card is null,
                    {                                                                                       // put that random card to the 'currentPlanCards', 
                        currentPlanCards[i] = roundButton.PlanCardObjects[7 - count];                          // reversed because the cards will be generated from the bottom up
                        roundButton.PlanCardObjects[7 - count] = null;
                        count++;
                    }
                    break;
                case GamePhase.contextDraw:
                    if ((!ContextCardBgList[i].gameObject.activeInHierarchy) && (currentContextCards[i] == null))
                    {
                        currentContextCards[i] = roundButton.ContextCardObjects[15 - count];
                        roundButton.ContextCardObjects[15 - count] = null;
                        count++;
                    }
                    break;
                case GamePhase.ImpDraw:
                    if ((!ImpCardBgList[i].gameObject.activeInHierarchy) && (currentImpCards[i] == null))
                    {
                        currentImpCards[i] = roundButton.ImpCardObjects[15 - count];
                        roundButton.ImpCardObjects[15 - count] = null;
                        count++;
                    }
                    break;
                case GamePhase.writeUpDraw:
                    if ((!WriteUpCardBgList[i].gameObject.activeInHierarchy) && (currentWriteUpCards[i] == null))
                    {
                        currentWriteUpCards[i] = roundButton.WriteUpCardObjects[15 - count];
                        roundButton.WriteUpCardObjects[15 - count] = null;
                        count++;
                    }
                    break;
            }
        }

    }

    public void clearBgAndCardsInPool()
    {
        for (int i = 0; i < 16; i++)
        {
            switch (playManager.gamePhase)
            {
                case GamePhase.checkPlan:
                    if (i > 7) { break; }
                    PlanCardBgList[i].gameObject.SetActive(false); // inactive all card background
                    if (roundButton.PlanCardObjects[7 - i] != null)
                    {
                        roundButton.PlanCardObjects[7 - i].gameObject.GetComponent<DragAndDrop>().enabled = false;
                        // Destroy(roundButton.PlanCardObjects[7 - i]);
                    }
                    break;
                case GamePhase.checkContext:
                    ContextCardBgList[i].gameObject.SetActive(false);
                    if (roundButton.ContextCardObjects[15 - i] != null)
                    {
                        roundButton.ContextCardObjects[15 - i].gameObject.GetComponent<DragAndDrop>().enabled = false;
                        // Destroy(roundButton.ContextCardObjects[15 - i]);
                    }
                    break;
                case GamePhase.checkImp:
                    ImpCardBgList[i].gameObject.SetActive(false);
                    if (roundButton.ImpCardObjects[15 - i] != null)
                    {
                        roundButton.ImpCardObjects[15 - i].gameObject.GetComponent<DragAndDrop>().enabled = false;
                        // Destroy(roundButton.ImpCardObjects[15 - i]);
                    }
                    break;
                case GamePhase.checkWriteUp:
                    WriteUpCardBgList[i].gameObject.SetActive(false);
                    if (roundButton.WriteUpCardObjects[15 - i] != null)
                    {
                        roundButton.WriteUpCardObjects[15 - i].gameObject.GetComponent<DragAndDrop>().enabled = false;
                        // Destroy(roundButton.WriteUpCardObjects[15 - i]);
                    }
                    break;
            }
        }
    }

    public void checkArrows()
    {

        foreach (GameObject card in removeCards)
        {
            if (card != null)
            {
                card.gameObject.transform.Find("needToBeDestoyed").gameObject.SetActive(false);
                //card.gameObject.GetComponent<MapManager>().enabled = true;
                card.gameObject.transform.GetComponent<DragAndDrop>().RemoveId = 0;
            }
        }

        removeCards = new List<GameObject>();

        checkSpcicalArrows();

        for (int i = 0; i < 16; i++)
        {
            switch (playManager.gamePhase)
            {
                case GamePhase.checkContext:

                    if ((i == 0) || (currentContextCards[i] == null)) { continue; }
                    ContextCard currentContextCard = currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                    if (currentContextCard.Left && currentContextCards[i - 1] != null)
                    {
                        ContextCard preContextCard = currentContextCards[i - 1].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if (!preContextCard.Right)
                        {
                            if (!removeCards.Contains(currentContextCards[i - 1]))
                            {
                                removeCards.Add(currentContextCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentContextCards[i]))
                            {
                                removeCards.Add(currentContextCards[i]);
                            }
                        }
                    }
                    else if (!currentContextCard.Left && currentContextCards[i - 1] != null)
                    {
                        ContextCard preContextCard = currentContextCards[i - 1].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if (preContextCard.Right)
                        {
                            if (!removeCards.Contains(currentContextCards[i - 1]))
                            {
                                removeCards.Add(currentContextCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentContextCards[i]))
                            {
                                removeCards.Add(currentContextCards[i]);
                            }
                        }
                    }

                    //----------------------------------------------------------------------------------
                    if (i > 3 && currentContextCard.Down && currentPlanCards[i - 4] != null)
                    {
                        PlanCard planCard = currentPlanCards[i - 4].gameObject.GetComponent<ShowCard>().card as PlanCard;
                        if (!planCard.Up)
                        {
                            if (!removeCards.Contains(currentPlanCards[i - 4]))
                            {
                                removeCards.Add(currentPlanCards[i - 4]);
                            }
                            if (!removeCards.Contains(currentContextCards[i]))
                            {
                                removeCards.Add(currentContextCards[i]);
                            }
                        }
                    }
                    else if (i <= 3 && currentContextCard.Down) //---------------------------------------------------------------------
                    {
                        if (!currentContextCard.Right) //--------------------------------------------------------- ←card card→---------
                        {
                            if (!removeCards.Contains(currentContextCards[i]))//----------------------------------------←card→---------
                            {
                                removeCards.Add(currentContextCards[i]);//-----------------------------------------------i<=3----------
                            }
                        }
                    }
                    else if (i > 3 && currentContextCard.Down && currentPlanCards[i - 4] == null )
                    {
                        if ( i < 16 && currentPlanCards[i - 3] != null) { 
                            if (!currentContextCard.Right) 
                            {//----------------------------------------------------------------------------------------- ←card card→
                                if (!removeCards.Contains(currentContextCards[i])) //-----------------------------------------←card→ ←--i-3
                                {
                                    removeCards.Add(currentContextCards[i]);
                                }
                            }
                        }
                        else if (i >= 5 && currentPlanCards[i - 5] != null)
                        {
                            if (!currentContextCard.Left)//---------------------------------------------------------------←card card→
                            {//--------------------------------------------------------------------------------   i-5--→  ←card→
                                if (!removeCards.Contains(currentContextCards[i]))//-------------------------------------------------
                                {
                                    removeCards.Add(currentContextCards[i]);
                                }
                            }
                        }

                    }
                    break;

                case GamePhase.checkImp:

                    if ((i == 0) || (currentImpCards[i] == null)) { continue; }
                    ImplementationCard currentImpCard = currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;

                    if (currentImpCard.Left && currentImpCards[i - 1] != null)
                    {
                        ImplementationCard preImpCard = currentImpCards[i - 1].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if (!preImpCard.Right)
                        {
                            if (!removeCards.Contains(currentImpCards[i - 1]))
                            {
                                removeCards.Add(currentImpCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentImpCards[i]))
                            {
                                removeCards.Add(currentImpCards[i]);
                            }
                        }
                    }
                    else if (!currentImpCard.Left && currentImpCards[i - 1] != null)
                    {
                        ImplementationCard preImpCard = currentImpCards[i - 1].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if (preImpCard.Right)
                        {
                            if (!removeCards.Contains(currentImpCards[i - 1]))
                            {
                                removeCards.Add(currentImpCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentImpCards[i]))
                            {
                                removeCards.Add(currentImpCards[i]);
                            }
                        }
                    }
                    //----------------------------------------------------------------------------------
                    if (currentImpCard.Down && currentContextCards[i] != null)
                    {
                        ContextCard contextCard = currentContextCards[i].gameObject.GetComponent<ShowCard>().card as ContextCard;
                        if (!contextCard.Up)
                        {
                            if (!removeCards.Contains(currentContextCards[i]))
                            {
                                removeCards.Add(currentContextCards[i]);
                            }
                            if (!removeCards.Contains(currentImpCards[i]))
                            {
                                removeCards.Add(currentImpCards[i]);
                            }
                            removeCards.Add(currentContextCards[i]);
                        }
                    }
                    else if (currentImpCard.Down && currentContextCards[i] == null)
                    {
                        if (i < 15)
                        {
                            if (currentContextCards[i + 1] != null)
                            {
                                if ( i < 16 && !currentImpCard.Right)
                                {//------------------------------------------------------------------------------------------ ←card card→
                                    if (!removeCards.Contains(currentImpCards[i])) //----------------------------------------------←card→
                                    {
                                        removeCards.Add(currentImpCards[i]);
                                    }
                                }
                            }
                        }
                        else if (i > 0 && currentContextCards[i - 1] != null)
                        {
                            if (!currentImpCard.Left)//---------------------------------------------------------------←card card→
                            {//------------------------------------------------------------------------------         ←card→
                                if (!removeCards.Contains(currentImpCards[i]))//-------------------------------------------------
                                {
                                    removeCards.Add(currentImpCards[i]);
                                }
                            }
                        }

                    }
                    break;

                case GamePhase.checkWriteUp:

                    if ((i == 0) || (currentWriteUpCards[i] == null)) { continue; }
                    WriteUpCard currentWriteUpCard = currentWriteUpCards[i].gameObject.GetComponent<ShowCard>().card as WriteUpCard;

                    if (currentWriteUpCard.Left && currentWriteUpCards[i - 1] != null)
                    {
                        WriteUpCard preWriteUpCard = currentWriteUpCards[i - 1].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                        if (!preWriteUpCard.Right)
                        {
                            if (!removeCards.Contains(currentWriteUpCards[i - 1]))
                            {
                                removeCards.Add(currentWriteUpCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentWriteUpCards[i]))
                            {
                                removeCards.Add(currentWriteUpCards[i]);
                            }
                        }
                    }
                    else if (!currentWriteUpCard.Left && currentWriteUpCards[i - 1] != null)
                    {
                        WriteUpCard preWriteUpCard = currentWriteUpCards[i - 1].gameObject.GetComponent<ShowCard>().card as WriteUpCard;
                        if (preWriteUpCard.Right)
                        {
                            if (!removeCards.Contains(currentWriteUpCards[i - 1]))
                            {
                                removeCards.Add(currentWriteUpCards[i - 1]);
                            }
                            if (!removeCards.Contains(currentWriteUpCards[i]))
                            {
                                removeCards.Add(currentWriteUpCards[i]);
                            }
                        }
                    }
                    //----------------------------------------------------------------------------------
                    if (currentWriteUpCard.Down && currentImpCards[i] != null)
                    {
                        ImplementationCard implementationCard = currentImpCards[i].gameObject.GetComponent<ShowCard>().card as ImplementationCard;
                        if (!implementationCard.Up)
                        {
                            if (!removeCards.Contains(currentImpCards[i]))
                            {
                                removeCards.Add(currentImpCards[i]);
                            }
                            if (!removeCards.Contains(currentWriteUpCards[i]))
                            {
                                removeCards.Add(currentWriteUpCards[i]);
                            }
                        }
                    }
                    else if (currentWriteUpCard.Down && currentImpCards[i] == null)
                    {
                        if ( i < 15)
                        {
                            if (currentImpCards[i + 1] != null)
                            {
                                if (!currentWriteUpCard.Right)
                                {//------------------------------------------------------------------------------------------ ←card card→
                                    if (!removeCards.Contains(currentWriteUpCards[i])) //------------------------------------------←card→
                                    {
                                        removeCards.Add(currentWriteUpCards[i]);
                                    }
                                }
                            }
                        }
                        else if (i > 0)
                        {
                            if (currentImpCards[i - 1] != null)
                            {
                                if (!currentWriteUpCard.Left)//---------------------------------------------------------------←card card→
                                {//----------------------------------------------------------------------------------         ←card→
                                    if (!removeCards.Contains(currentWriteUpCards[i]))//-------------------------------------------------
                                    {
                                        removeCards.Add(currentWriteUpCards[i]);
                                    }
                                }
                            }
                        }

                    }
                    break;
            }
        }

        foreach (GameObject x in removeCards)
        {
            x.gameObject.transform.Find("needToBeDestoyed").gameObject.SetActive(true);
            //x.gameObject.GetComponent<MapManager>().enabled = false;
            x.gameObject.transform.GetComponent<DragAndDrop>().RemoveId = 1;
        }

    }
    //                                                     ---------
    // check whether there are part of cards in a row,like| ←card→  |-------←card→←card→←card→---------←card→←card→
    public void checkSpcicalArrows()    //                 ---------
    {
        List<GameObject> cardsFragment = new List<GameObject>();
        List<List<GameObject>> row= new List<List<GameObject>>();
        List<List<GameObject>> removeList = new List<List<GameObject>>();
        List<int> firstCardPositions = new List<int>();

        // Plan cards check, do not remove!!!!!!!!
        ////----------------------------------------------------------------------------
        //// First find each card fragment, store in cardsFragment. Then store each fragment in row,
        //// meanwhile store the position of frist card for each fragment in firstCardPositions
        //for (int i = 0; i < 8; i++)
        //{

        //    if (currentPlanCards[i] != null)
        //    {
        //        if (cardsFragment.Count == 0)
        //        {
        //            cardsFragment.Add(currentPlanCards[i]);
        //            firstCardPositions.Add(i);
        //        }
        //        else if (i > 0 && currentPlanCards[i - 1] == cardsFragment[cardsFragment.Count - 1])
        //        {
        //            cardsFragment.Add(currentPlanCards[i]);
        //        }

        //        if (currentPlanCards[i + 1] == null)
        //        {
        //            row.Add(cardsFragment);
        //            cardsFragment = new List<GameObject>();
        //        }
        //    }
        //}

        //// Store that fragemet to removeList if no one cards connect with the card below
        //if (row.Count > 1)
        //{
        //    List<GameObject> cards = row[0];
        //    for (int i = 0; i < row.Count; i++)
        //    {
        //        if (row[i].Count >= cards.Count)
        //        {
        //            cards = row[i];
        //        }
        //    }
        //    foreach (GameObject card in cards)
        //    {
        //        if (!removeCards.Contains(card))
        //        {
        //            removeCards.Add(card);
        //        }
        //    }
        //}


        //----------------------------------------------------------------------------
        // First find each card fragment, store in cardsFragment. Then store each fragment in row,
        // meanwhile store the position of frist card for each fragment in firstCardPositions
        row = new List<List<GameObject>>();
        firstCardPositions = new List<int>();
        removeList = new List<List<GameObject>>();
        for (int i = 0; i < 16; i++)
        {

            if (currentContextCards[i] != null)
            {
                if (cardsFragment.Count == 0)
                {
                    cardsFragment.Add(currentContextCards[i]);
                    firstCardPositions.Add(i);
                }
                else if (i > 0 && currentContextCards[i - 1] == cardsFragment[cardsFragment.Count - 1])
                {
                    cardsFragment.Add(currentContextCards[i]);
                }

                if ((i == 15) || (i < 15 && currentContextCards[i + 1] == null))
                {
                    row.Add(cardsFragment);
                    cardsFragment = new List<GameObject>();
                }
            }
        }

        // Store that fragemet to removeList if no one cards connect with the card below
        if (row.Count >= 1)
        {
            for (int x = 0; x < row.Count; x++)
            {
                List<GameObject> cards = row[x];
                int y = 0;
                while (y < cards.Count)
                {
                    int index = firstCardPositions[x] + y - 4;
                    if (index < 0)
                    {
                        y++;
                        continue;
                    }
                    else if (index >= 0 && currentPlanCards[index] != null)
                    {
                        if (y == cards.Count)
                        {
                            y--;
                        }
                        break;
                    }
                    y++;
                }
                if (y == cards.Count)
                {
                    foreach (GameObject card in row[x]) {
                        if (!removeCards.Contains(card))
                        {
                            removeCards.Add(card);
                        }
                    }
                        
                }
            }
        }

        //----------------------------------------------------------------------------
        // First find each card fragment, store in cardsFragment. Then store each fragment in row,
        // meanwhile store the position of frist card for each fragment in firstCardPositions
        row = new List<List<GameObject>>();
        firstCardPositions = new List<int>();
        removeList = new List<List<GameObject>>();
        cardsFragment = new List<GameObject>();
        for (int i = 0; i < 16; i++)
        {

            if (currentImpCards[i] != null)
            {
                if (cardsFragment.Count == 0)
                {
                    cardsFragment.Add(currentImpCards[i]);
                    firstCardPositions.Add(i);
                }
                else if (i > 0 && currentImpCards[i - 1] == cardsFragment[cardsFragment.Count - 1])
                {
                    cardsFragment.Add(currentImpCards[i]);
                }

                if ((i == 15) || (i < 15 && currentImpCards[i + 1] == null))
                {
                    row.Add(cardsFragment);
                    cardsFragment = new List<GameObject>();
                }
            }
        }

        // Store that fragemet to removeList if no one cards connect with the card below
        if (row.Count >= 1)
        {
            for (int x = 0; x < row.Count; x++)
            {
                List<GameObject> cards = row[x];
                int y = 0;
                while (y < cards.Count)
                {
                    int index = firstCardPositions[x] + y;
                    if (currentContextCards[index] != null)
                    {
                        if (y == cards.Count)
                        {
                            y--;
                        }
                        break;
                    }
                    y++;
                }
                if (y == cards.Count)
                {
                    foreach (GameObject card in row[x])
                    {
                        if (!removeCards.Contains(card))
                        {
                            removeCards.Add(card);
                        }
                    }

                }
            }
        }

        //----------------------------------------------------------------------------
        // First find each card fragment, store in cardsFragment. Then store each fragment in row,
        // meanwhile store the position of frist card for each fragment in firstCardPositions
        row = new List<List<GameObject>>();
        firstCardPositions = new List<int>();
        removeList = new List<List<GameObject>>();
        cardsFragment = new List<GameObject>();
        for (int i = 0; i < 16; i++)
        {

            if (currentWriteUpCards[i] != null)
            {
                if (cardsFragment.Count == 0)
                {
                    cardsFragment.Add(currentWriteUpCards[i]);
                    firstCardPositions.Add(i);
                }
                else if (i > 0 && currentWriteUpCards[i - 1] == cardsFragment[cardsFragment.Count - 1])
                {
                    cardsFragment.Add(currentWriteUpCards[i]);
                }

                if ((i == 15) || (i < 15 && currentWriteUpCards[i + 1] == null))
                {
                    row.Add(cardsFragment);
                    cardsFragment = new List<GameObject>();
                }
            }
        }

        // Store that fragemet to removeList if no one cards connect with the card below
        if (row.Count >= 1)
        {
            for (int x = 0; x < row.Count; x++)
            {
                List<GameObject> cards = row[x];
                int y = 0;
                while (y < cards.Count)
                {
                    int index = firstCardPositions[x] + y;
                    if (currentImpCards[index] != null)
                    {
                        if (y == cards.Count)
                        {
                            y--;
                        }
                        break;
                    }
                    y++;
                }
                if (y == cards.Count)
                {
                    foreach (GameObject card in row[x])
                    {
                        if (!removeCards.Contains(card))
                        {
                            removeCards.Add(card);
                        }
                    }

                }
            }
        }


    }

    // check if a rwo is empty, which means no card in that row
    public bool checkActiveRowIsEmpty()
    {
        for (int i = 0; i < 16; i++)
        {
            if (playManager.gamePhase == GamePhase.checkContext)
            {
                //if (i < 8 && currentPlanCards[i] != null)
                //{
                //    return false;
                //}
                if (currentContextCards[i] != null)
                {
                    return false;
                }
            }
            else if (playManager.gamePhase == GamePhase.checkImp)
            {
                if (currentImpCards[i] != null)
                {
                    return false;
                }
            }
            else if (playManager.gamePhase == GamePhase.checkWriteUp)
            {
                if (currentWriteUpCards[i] != null)
                {
                    return false;
                }
            }
            else
            {

                return false;
            }
        }
        return true;
    }
}
