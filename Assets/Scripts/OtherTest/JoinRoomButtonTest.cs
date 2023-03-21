/*using NUnit.Framework;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class JoinRoomButtonTests
{
    [Test]
    public void SaveData_SetsUsernameAndIncrementsDefaultIndex()
    {
        // Arrange
        var joinRoomButton = new GameObject().AddComponent<JoinRoomButton>();
        var inputFieldObject = new GameObject();
        inputFieldObject.AddComponent<InputField>();
        joinRoomButton.inputField = inputFieldObject.GetComponent<InputField>();
        PlayerPrefs.DeleteKey("Username");
        joinRoomButton.defaultIndex = 0;
        
        // Act
        joinRoomButton.SaveData();

        // Assert
        Assert.AreEqual("Group0", joinRoomButton.inputField.text);
        Assert.AreEqual("Group0", PlayerPrefs.GetString("Username"));
        Assert.AreEqual(1, joinRoomButton.defaultIndex);

        // Act
        joinRoomButton.SaveData();

        // Assert
        Assert.AreEqual("Group1", joinRoomButton.inputField.text);
        Assert.AreEqual("Group1", PlayerPrefs.GetString("Username"));
        Assert.AreEqual(2, joinRoomButton.defaultIndex);
    }

    [Test]
    public void SaveData_SetsUsernameToInputText()
    {
        // Arrange
        var joinRoomButton = new GameObject().AddComponent<JoinRoomButton>();
        var inputFieldObject = new GameObject();
        inputFieldObject.AddComponent<InputField>().text = "TestGroup";
        joinRoomButton.inputField = inputFieldObject.GetComponent<InputField>();
        PlayerPrefs.DeleteKey("Username");

        // Act
        joinRoomButton.SaveData();

        // Assert
        Assert.AreEqual("TestGroup", joinRoomButton.inputField.text);
        Assert.AreEqual("TestGroup", PlayerPrefs.GetString("Username"));
    }
}
*/