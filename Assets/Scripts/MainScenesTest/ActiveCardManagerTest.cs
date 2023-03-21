/*
using NUnit.Framework;
using UnityEngine;

[TestFixture]
public class ActiveCardManagerTests
{
    private ActiveCardManager activeCardManager;
    private PlayManager playManager;
    private LoadData loadData;

    [SetUp]
    public void SetUp()
    {
        playManager = new PlayManager();
        loadData = new LoadData();
        activeCardManager = new ActiveCardManager
        {
            playManager = playManager,
            loadData = loadData
        };
    }

    [Test]
    public void GetAllBackgroundObj_ShouldAddAllChildTransformsToLists()
    {
        activeCardManager.GetAllBackgroundObj();
        Assert.That(activeCardManager.PlanCardBgList.Count, Is.EqualTo(16));
        Assert.That(activeCardManager.ContextCardBgList.Count, Is.EqualTo(16));
        Assert.That(activeCardManager.ImpCardBgList.Count, Is.EqualTo(16));
        Assert.That(activeCardManager.WriteUpCardBgList.Count, Is.EqualTo(16));
    }

    [Test]
    public void ActiveCardPositionUpdate_ShouldAssignCurrentCardsCorrectlyForPhase1()
    {
        playManager.GamePhase = GamePhase.checkDeck;
        playManager.gamePhaseCount = 1;
        for (int i = 0; i < 16; i++)
        {
            loadData.RandomPlanCards[i] = new PlanCard();
        }
        activeCardManager.activeCardPositionUpdate();
        Assert.That(activeCardManager.currentPlanCards[0], Is.EqualTo(loadData.RandomPlanCards[7]));
        Assert.That(activeCardManager.currentPlanCards[1], Is.EqualTo(loadData.RandomPlanCards[6]));
        Assert.That(activeCardManager.currentPlanCards[2], Is.EqualTo(loadData.RandomPlanCards[5]));
        Assert.That(activeCardManager.currentPlanCards[3], Is.EqualTo(loadData.RandomPlanCards[4]));
        Assert.That(activeCardManager.currentPlanCards[4], Is.EqualTo(loadData.RandomPlanCards[3]));
        Assert.That(activeCardManager.currentPlanCards[5], Is.EqualTo(loadData.RandomPlanCards[2]));
        Assert.That(activeCardManager.currentPlanCards[6], Is.EqualTo(loadData.RandomPlanCards[1]));
        Assert.That(activeCardManager.currentPlanCards[7], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[8], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[9], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[10], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[11], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[12], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[13], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[14], Is.EqualTo(loadData.RandomPlanCards[0]));
        Assert.That(activeCardManager.currentPlanCards[15], Is.EqualTo(loadData.RandomPlanCards[0]));
    }

    [Test]
    public void ActiveCardPositionUpdate_ShouldAssignCurrentCardsCorrectlyForPhase3()
    {
        playManager.GamePhase = GamePhase.checkDeck;
        playManager.gamePhaseCount = 3;
        for (int i = 0; i < 16; i++)
        {
            loadData.RandomContextCards[i] = new ContextCard();
        }
        activeCardManager.activeCardPositionUpdate();
        Assert.That(activeCardManager.currentContextCards[0], Is.EqualTo(loadData.RandomContextCards[15]));
        Assert.That(activeCardManager.currentContextCards[1], Is.EqualTo(loadData.RandomContextCards[14]));
        Assert.That(activeCardManager.currentContextCards[2], Is.EqualTo(loadData.RandomContextCards[13]));
        Assert.That(activeCardManager.currentContextCards[3], Is.EqualTo(loadData.RandomContextCards[12]));
        Assert.That(activeCardManager.currentContextCards[4], Is.EqualTo(loadData.RandomContextCards[11]));
        Assert.That(activeCardManager.currentContextCards[5], Is.EqualTo(loadData.RandomContextCards[10]));
        Assert.That(activeCardManager.currentContextCards[6], Is.EqualTo(loadData.RandomContextCards[9]));
        Assert.That(activeCardManager.currentContextCards[7], Is.EqualTo(loadData.RandomContextCards[8]));
        Assert.That(activeCardManager.currentContextCards[8], Is.EqualTo(loadData.RandomContextCards[7]));
        Assert.That(activeCardManager.currentContextCards[9], Is.EqualTo(loadData.RandomContextCards[6]));
        Assert.That(activeCardManager.currentContextCards[10], Is.EqualTo(loadData.RandomContextCards[5]));
        Assert.That(activeCardManager.currentContextCards[11], Is.EqualTo(loadData.RandomContextCards[4]));
        Assert.That(activeCardManager.currentContextCards[12], Is.EqualTo(loadData.RandomContextCards[3]));
        Assert.That(activeCardManager.currentContextCards[13], Is.EqualTo(loadData.RandomContextCards[2]));
        Assert.That(activeCardManager.currentContextCards[14], Is.EqualTo(loadData.RandomContextCards[1]));
        Assert.That(activeCardManager.currentContextCards[15], Is.EqualTo(loadData.RandomContextCards[0]));
    }

    [Test]
    public void ActiveCardPositionUpdate_ShouldAssignCurrentCardsCorrectlyForPhase7()
    {
        playManager.GamePhase = GamePhase.checkDeck;
        playManager.gamePhaseCount = 7;
        for (int i = 0; i < 16; i++)
        {
            loadData.RandomImplementationCard[i] = new ImplementationCard();
        }
        activeCardManager.activeCardPositionUpdate();
        Assert.That(activeCardManager.currentImplementationCard[0], Is.EqualTo(loadData.RandomImplementationCard[15]));
        Assert.That(activeCardManager.currentImplementationCard[1], Is.EqualTo(loadData.RandomImplementationCard[14]));
        Assert.That(activeCardManager.currentImplementationCard[2], Is.EqualTo(loadData.RandomImplementationCard[13]));
        Assert.That(activeCardManager.currentImplementationCard[3], Is.EqualTo(loadData.RandomImplementationCard[12]));
        Assert.That(activeCardManager.currentImplementationCard[4], Is.EqualTo(loadData.RandomImplementationCard[11]));
        Assert.That(activeCardManager.currentImplementationCard[5], Is.EqualTo(loadData.RandomImplementationCard[10]));
        Assert.That(activeCardManager.currentImplementationCard[6], Is.EqualTo(loadData.RandomImplementationCard[9]));
        Assert.That(activeCardManager.currentImplementationCard[7], Is.EqualTo(loadData.RandomImplementationCard[8]));
        Assert.That(activeCardManager.currentImplementationCard[8], Is.EqualTo(loadData.RandomImplementationCard[7]));
        Assert.That(activeCardManager.currentImplementationCard[9], Is.EqualTo(loadData.RandomImplementationCard[6]));
        Assert.That(activeCardManager.currentImplementationCard[10], Is.EqualTo(loadData.RandomImplementationCard[5]));
        Assert.That(activeCardManager.currentImplementationCard[11], Is.EqualTo(loadData.RandomImplementationCard[4]));
        Assert.That(activeCardManager.currentImplementationCard[12], Is.EqualTo(loadData.RandomImplementationCard[3]));
        Assert.That(activeCardManager.currentImplementationCard[13], Is.EqualTo(loadData.RandomImplementationCard[2]));
        Assert.That(activeCardManager.currentImplementationCard[14], Is.EqualTo(loadData.RandomImplementationCard[1]));
        Assert.That(activeCardManager.currentImplementationCard[15], Is.EqualTo(loadData.RandomImplementationCard[0]));
    }

    [Test]
    public void ActiveCardPositionUpdate_ShouldAssignCurrentCardsCorrectlyForPhase11()
    {
        playManager.GamePhase = GamePhase.checkDeck;
        playManager.gamePhaseCount = 11;
        for (int i = 0; i < 16; i++)
        {
            loadData.RandomWriteUpCard[i] = new WriteUpCard();
        }
        activeCardManager.activeCardPositionUpdate();
        Assert.That(activeCardManager.currentWriteUpCard[0], Is.EqualTo(loadData.RandomWriteUpCard[15]));
        Assert.That(activeCardManager.currentWriteUpCard[1], Is.EqualTo(loadData.RandomWriteUpCard[14]));
        Assert.That(activeCardManager.currentWriteUpCard[2], Is.EqualTo(loadData.RandomWriteUpCard[13]));
        Assert.That(activeCardManager.currentWriteUpCard[3], Is.EqualTo(loadData.RandomWriteUpCard[12]));
        Assert.That(activeCardManager.currentWriteUpCard[4], Is.EqualTo(loadData.RandomWriteUpCard[11]));
        Assert.That(activeCardManager.currentWriteUpCard[5], Is.EqualTo(loadData.RandomWriteUpCard[10]));
        Assert.That(activeCardManager.currentWriteUpCard[6], Is.EqualTo(loadData.RandomWriteUpCard[9]));
        Assert.That(activeCardManager.currentWriteUpCard[7], Is.EqualTo(loadData.RandomWriteUpCard[8]));
        Assert.That(activeCardManager.currentWriteUpCard[8], Is.EqualTo(loadData.RandomWriteUpCard[7]));
        Assert.That(activeCardManager.currentWriteUpCard[9], Is.EqualTo(loadData.RandomWriteUpCard[6]));
        Assert.That(activeCardManager.currentWriteUpCard[10], Is.EqualTo(loadData.RandomWriteUpCard[5]));
        Assert.That(activeCardManager.currentWriteUpCard[11], Is.EqualTo(loadData.RandomWriteUpCard[4]));
        Assert.That(activeCardManager.currentWriteUpCard[12], Is.EqualTo(loadData.RandomWriteUpCard[3]));
        Assert.That(activeCardManager.currentWriteUpCard[13], Is.EqualTo(loadData.RandomWriteUpCard[2]));
        Assert.That(activeCardManager.currentWriteUpCard[14], Is.EqualTo(loadData.RandomWriteUpCard[1]));
        Assert.That(activeCardManager.currentWriteUpCard[15], Is.EqualTo(loadData.RandomWriteUpCard[0]));
    }
}
*/