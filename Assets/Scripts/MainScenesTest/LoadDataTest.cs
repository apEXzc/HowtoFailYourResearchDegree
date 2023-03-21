/*
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;
[TestFixture]
public class LoadDataTests
{
    private LoadData loadData;

    [SetUp]
    public void SetUp()
    {
        // Create a new instance of LoadData for each test
        loadData = new GameObject().AddComponent<LoadData>();
    }

    [Test]
    public void TestLoadCardData()
    {
        // Make sure each of the card lists are initially empty
        Assert.AreEqual(0, loadData.PlanCardList.Count);
        Assert.AreEqual(0, loadData.ContextCardList.Count);
        Assert.AreEqual(0, loadData.ImplementationList.Count);
        Assert.AreEqual(0, loadData.WriteUpCardList.Count);
        Assert.AreEqual(0, loadData.EventContextCardList.Count);
        Assert.AreEqual(0, loadData.EventImplementationList.Count);
        Assert.AreEqual(0, loadData.EventWriteUpList.Count);

        // Call LoadCardData
        loadData.LoadCardData();

        // Make sure each of the card lists are now populated with at least one card
        Assert.GreaterOrEqual(loadData.PlanCardList.Count, 1);
        Assert.GreaterOrEqual(loadData.ContextCardList.Count, 1);
        Assert.GreaterOrEqual(loadData.ImplementationList.Count, 1);
        Assert.GreaterOrEqual(loadData.WriteUpCardList.Count, 1);
        Assert.GreaterOrEqual(loadData.EventContextCardList.Count, 1);
        Assert.GreaterOrEqual(loadData.EventImplementationList.Count, 1);
        Assert.GreaterOrEqual(loadData.EventWriteUpList.Count, 1);
    }
}
*/