using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * This file trying to show cards on unity
 */



public class ShowCard : MonoBehaviour
{
    public Image background;

    public Card card;

    // Start is called before the first frame update
    void Start()
    {
        CardDisplay();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void CardDisplay()
    {

        if (card is PlanCard)
        {
            var PlanCard = card as PlanCard;
            background.sprite = PlanCard.background;
        }
        else if (card is ContextCard)
        {
            var ContextCard = card as ContextCard;
            background.sprite = ContextCard.background;
        }
        else if (card is ImplementationCard)
        {
            var ImplementationCard = card as ImplementationCard;
            background.sprite = ImplementationCard.background;
        }
        else if (card is WriteUpCard)
        {
            var WriteUpCard = card as WriteUpCard;
            background.sprite = WriteUpCard.background;
        }
        else if (card is EventContextCard)
        {
            var EventContextCard = card as EventContextCard;
            background.sprite = EventContextCard.background;
        }
        else if (card is EventImplementationCard)
        {
            var EventImplementationCard = card as EventImplementationCard;
            background.sprite = EventImplementationCard.background;
        }
        else if (card is EventWriteUpCard)
        {
            var EventWriteUpCard = card as EventWriteUpCard;
            background.sprite = EventWriteUpCard.background;
        }


    }

    public void changeCardArrows()
    {
        if (card is PlanCard)
        {
            PlanCard planCard = card as PlanCard;
            planCard.Up = true;
            planCard.Down = true;
            planCard.Left = true;
            planCard.Right = true;
        }
        else if (card is ContextCard)
        {
            ContextCard contextCard = card as ContextCard;
            contextCard.Up = true;
            contextCard.Down = true;
            contextCard.Left = true;
            contextCard.Right = true;
        }
        else if (card is ImplementationCard)
        {
            ImplementationCard implementationCard = card as ImplementationCard;
            implementationCard.Up = true;
            implementationCard.Down = true;
            implementationCard.Left = true;
            implementationCard.Right = true;
        }
        else if (card is WriteUpCard)
        {
            WriteUpCard writeUpCard = card as WriteUpCard;
            writeUpCard.Down = true;
            writeUpCard.Left = true;
            writeUpCard.Right = true;
        }

    }
}
