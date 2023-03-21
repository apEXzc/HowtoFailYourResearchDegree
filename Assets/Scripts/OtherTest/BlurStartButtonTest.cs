/*using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BlurStartButtonTests
{
    [Test]
    public void OnStartGame_SetsUsernameAndLoadsScene()
    {
        // Arrange
        var blurStartButton = new GameObject().AddComponent<BlurStartButton>();
        var inputFieldObject = new GameObject();
        inputFieldObject.AddComponent<Text>().text = "TestUsername";
        blurStartButton.inputField = inputFieldObject;
        var sceneNumber = 1;

        // Act
        blurStartButton.OnStartGame(sceneNumber);

        // Assert
        Assert.AreEqual("TestUsername", PlayerPrefs.GetString("Username"));
        Assert.AreEqual(sceneNumber, SceneManager.GetActiveScene().buildIndex);
    }
}
*/