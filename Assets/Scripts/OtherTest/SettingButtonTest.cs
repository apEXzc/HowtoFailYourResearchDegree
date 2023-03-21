/*using NUnit.Framework;
using UnityEngine;
using UnityEngine.UI;

public class SettingButtonTests
{
    [Test]
    public void OnClickSettingButton_ActivatesSettingPanel()
    {
        // Arrange
        var settingButton = new GameObject().AddComponent<SettingButton>();
        var settingPanel = new GameObject();
        settingButton.settingPanel = settingPanel;

        // Act
        settingButton.OnClickSettingButton();

        // Assert
        Assert.IsTrue(settingPanel.activeSelf);
    }
}
*/