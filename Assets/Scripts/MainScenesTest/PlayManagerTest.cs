/*using NUnit.Framework;

[TestFixture]
public class PlayManagerTests
{
    private PlayManager playManager;

    [SetUp]
    public void SetUp()
    {
        playManager = new PlayManager();
    }

    [Test]
    public void PhaseCheck_InitialState_ShouldBeGameStart()
    {
        // Arrange
        playManager.gamePhaseCount = 0;

        // Act
        playManager.PhaseCheck();

        // Assert
        Assert.AreEqual(GamePhase.gameStart, playManager.GamePhase);
        Assert.AreEqual("If you are ready, Please click the Round Button again to begin!", playManager.gamePhaseText.text);
    }

    [Test]
    public void PhaseCheck_WhenActiveDraw_ShouldBeCheckDeck()
    {
        // Arrange
        playManager.gamePhaseCount = 1;
        playManager.GamePhase = GamePhase.activeDraw;

        // Act
        playManager.PhaseCheck();

        // Assert
        Assert.AreEqual(GamePhase.checkDeck, playManager.GamePhase);
        Assert.AreEqual("Begin to draw active cards!!!", playManager.gamePhaseText.text);
    }

    [Test]
    public void PhaseCheck_WhenCheckDeck_ShouldBeActiveDraw()
    {
        // Arrange
        playManager.gamePhaseCount = 2;
        playManager.GamePhase = GamePhase.checkDeck;
        playManager.cardState = false;

        // Act
        playManager.PhaseCheck();

        // Assert
        Assert.AreEqual(GamePhase.activeDraw, playManager.GamePhase);
        Assert.AreEqual("Please check cards", playManager.gamePhaseText.text);
    }

    [Test]
    public void PhaseCheck_WhenEventDraw_ShouldBeCheckDeck()
    {
        // Arrange
        playManager.gamePhaseCount = 3;
        playManager.GamePhase = GamePhase.eventDraw;

        // Act
        playManager.PhaseCheck();

        // Assert
        Assert.AreEqual(GamePhase.checkDeck, playManager.GamePhase);
        Assert.AreEqual("Please click one event card", playManager.gamePhaseText.text);
    }

    [Test]
    public void PhaseCheck_WhenGameEnd_ShouldActivateResultButton()
    {
        // Arrange
        playManager.gamePhaseCount = 13;
        playManager.GamePhase = GamePhase.gameEnd;

        // Act
        playManager.PhaseCheck();

        // Assert
        Assert.AreEqual("Game over", playManager.gamePhaseText.text);
        Assert.IsTrue(playManager.ResultButton.gameObject.activeSelf);
    }
}
*/