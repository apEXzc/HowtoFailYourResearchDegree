/*
using NUnit.Framework;

[TestFixture]
public class RemindWindowTests
{
    [Test]
    public void RemindUncorrectCard_ShouldShowRemindPanel_WhenRemoveCardsCountIsGreaterThanZero()
    {
        // Arrange
        var remindWindow = new RemindWindow();
        var activeCardManager = new ActiveCardManager();
        activeCardManager.removeCards.Add(new GameObject()); // add an uncorrect active card
        remindWindow.activeCardManager = activeCardManager;

        // Act
        var result = remindWindow.remindUncorrectCard();

        // Assert
        Assert.That(result, Is.True);
        Assert.That(remindWindow.remindPanel.activeSelf, Is.True);
        Assert.That(remindWindow.remindPanel.gameObject.transform.Find("Text").gameObject.GetComponent<Text>().text, Is.EqualTo("Please remove all uncorrect Active Card !"));
    }

    [Test]
    public void RemindUncorrectCard_ShouldNotShowRemindPanel_WhenRemoveCardsCountIsZero()
    {
        // Arrange
        var remindWindow = new RemindWindow();
        var activeCardManager = new ActiveCardManager();
        remindWindow.activeCardManager = activeCardManager;

        // Act
        var result = remindWindow.remindUncorrectCard();

        // Assert
        Assert.That(result, Is.False);
        Assert.That(remindWindow.remindPanel.activeSelf, Is.False);
    }
}
*/