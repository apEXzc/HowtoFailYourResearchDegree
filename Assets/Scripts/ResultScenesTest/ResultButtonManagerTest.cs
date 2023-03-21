/*
using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ResultButtonManagerTest
{
    [Test]
    public void OnClickReviewButton_ShouldSetActiveImageReview()
    {
        // Arrange
        var gameObject = new GameObject();
        var resultButtonManager = gameObject.AddComponent<ResultButtonManager>();
        var imageReview = new GameObject().AddComponent<Image>();
        resultButtonManager.imageReview = imageReview.gameObject;

        // Act
        resultButtonManager.OnClickReviewButton();

        // Assert
        Assert.IsTrue(imageReview.gameObject.activeSelf);
    }

    [Test]
    public void OnClickNewGameButton_ShouldLoadMainScenes()
    {
        // Arrange
        var gameObject = new GameObject();
        var resultButtonManager = gameObject.AddComponent<ResultButtonManager>();

        // Act
        resultButtonManager.OnClickNewGameButton();

        // Assert
        Assert.AreEqual("MainScenes", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void OnClickQuitButton_ShouldLoadStartScenes()
    {
        // Arrange
        var gameObject = new GameObject();
        var resultButtonManager = gameObject.AddComponent<ResultButtonManager>();

        // Act
        resultButtonManager.OnClickQuitButton();

        // Assert
        Assert.AreEqual("StartScenes", SceneManager.GetActiveScene().name);
    }

    [Test]
    public void DeleteScreenshot_ShouldDeleteFileIfExists()
    {
        // Arrange
        var gameObject = new GameObject();
        var resultButtonManager = gameObject.AddComponent<ResultButtonManager>();
        var filePath = Application.dataPath + "/Assets/Resources/Screenshot_result.png";
        File.WriteAllText(filePath, "test");

        // Act
        resultButtonManager.DeleteScreenshot();

        // Assert
        Assert.IsFalse(File.Exists(filePath));
    }

    [Test]
    public void DeleteScreenshot_ShouldNotDeleteFileIfDoesNotExist()
    {
        // Arrange
        var gameObject = new GameObject();
        var resultButtonManager = gameObject.AddComponent<ResultButtonManager>();
        var filePath = Application.dataPath + "/Assets/Resources/Screenshot_result.png";

        // Act
        resultButtonManager.DeleteScreenshot();

        // Assert
        Assert.IsFalse(File.Exists(filePath));
    }
}
*/
