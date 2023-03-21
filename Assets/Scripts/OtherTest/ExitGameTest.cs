/*
using NUnit.Framework;
using UnityEngine;

public class ExitGameTests
{
    [Test]
    public void QuitGame_UnityEditor_IsPlayingSetToFalse()
    {
        // Arrange
        #if UNITY_EDITOR
        var originalPlayingValue = UnityEditor.EditorApplication.isPlaying;
        #endif

        var exitGame = new ExitGame();

        // Act
        exitGame.QuitGame();

        // Assert
        #if UNITY_EDITOR
        Assert.IsFalse(UnityEditor.EditorApplication.isPlaying);
        UnityEditor.EditorApplication.isPlaying = originalPlayingValue;
        #endif
    }

    [Test]
    public void QuitGame_NotUnityEditor_ApplicationQuitCalled()
    {
        // Arrange
        #if UNITY_EDITOR
        var originalPlayingValue = UnityEditor.EditorApplication.isPlaying;
        #endif

        var exitGame = new ExitGame();

        // Act
        exitGame.QuitGame();

        // Assert
        #if !UNITY_EDITOR
        Assert.IsTrue(Application.quitting);
        #endif
    }
}
*/