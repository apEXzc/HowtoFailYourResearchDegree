/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[TestFixture]
public class ShowCardTests
{
    private ShowCard showCard;
    private Image background;

    [SetUp]
    public void SetUp()
    {
        showCard = new ShowCard();
        background = new Image();
        showCard.background = background;
    }

    [Test]
    public void CardDisplay_PlanCard_SetsBackgroundSprite()
    {
        var planCard = new PlanCard();
        planCard.background = new Sprite();
        showCard.card = planCard;

        showCard.CardDisplay();

        Assert.AreEqual(planCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_ContextCard_SetsBackgroundSprite()
    {
        var contextCard = new ContextCard();
        contextCard.background = new Sprite();
        showCard.card = contextCard;

        showCard.CardDisplay();

        Assert.AreEqual(contextCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_ImplementationCard_SetsBackgroundSprite()
    {
        var ImplementationCard = new ImplementationCard();
        contextCard.background = new Sprite();
        showCard.card = ImplementationCard;

        showCard.CardDisplay();

        Assert.AreEqual(ImplementationCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_WriteUpCard_SetsBackgroundSprite()
    {
        var WriteUpCard = new WriteUpCard();
        WriteUpCard.background = new Sprite();
        showCard.card = WriteUpCard;

        showCard.CardDisplay();

        Assert.AreEqual(WriteUpCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_EventContextCard_SetsBackgroundSprite()
    {
        var EventContextCard = new EventContextCard();
        EventContextCard.background = new Sprite();
        showCard.card = EventContextCard;

        showCard.CardDisplay();

        Assert.AreEqual(EventContextCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_EventImplementationCard_SetsBackgroundSprite()
    {
        var EventImplementationCard = new EventImplementationCard();
        EventImplementationCard.background = new Sprite();
        showCard.card = EventImplementationCard;

        showCard.CardDisplay();

        Assert.AreEqual(EventImplementationCard.background, background.sprite);
    }

    [Test]
    public void CardDisplay_EventWriteUpCard_SetsBackgroundSprite()
    {
        var EventWriteUpCard = new EventWriteUpCard();
        EventWriteUpCard.background = new Sprite();
        showCard.card = EventWriteUpCard;

        showCard.CardDisplay();

        Assert.AreEqual(EventWriteUpCard.background, background.sprite);
    }
}
*/