/*
using NUnit.Framework;
using UnityEngine;

public class ResultButtonTests
{
    [Test]
    public void OnClick_PassesCorrectThesisDataToNextScene()
    {
        // Arrange
        var gameObject = new GameObject();
        var activeCardManager = gameObject.AddComponent<ActiveCardManager>();
        var resultButton = gameObject.AddComponent<ResultButton>();
        activeCardManager.currentWriteUpCards = new GameObject[3];
        activeCardManager.currentWriteUpCards[0] = CreateWriteUpCard(true);
        activeCardManager.currentWriteUpCards[1] = CreateWriteUpCard(false);
        activeCardManager.currentWriteUpCards[2] = CreateWriteUpCard(true);

        // Act
        resultButton.OnClick();

        // Assert
        Assert.AreEqual(2, MainSceneGameData.Instance.thesisNumber);
    }

    private GameObject CreateWriteUpCard(bool isThesis)
    {
        var gameObject = new GameObject();
        var writeUpCard = gameObject.AddComponent<WriteUpCard>();
        writeUpCard.Thesis = isThesis;
        gameObject.AddComponent<ShowCard>();
        return gameObject;
    }
}
*/