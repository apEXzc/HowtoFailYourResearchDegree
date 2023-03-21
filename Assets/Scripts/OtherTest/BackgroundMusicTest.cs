/*using NUnit.Framework;
using UnityEngine;

public class BackgroundMusicTests
{
    [Test]
    public void Awake_DestroysDuplicateMusicObjects()
    {
        // Arrange
        var musicObject1 = new GameObject();
        musicObject1.tag = "Music";
        var musicObject2 = new GameObject();
        musicObject2.tag = "Music";
        var backgroundMusic = new GameObject().AddComponent<BackgroundMusic>();

        // Act
        backgroundMusic.Awake();

        // Assert
        Assert.IsFalse(musicObject2.activeSelf);
    }
}
*/