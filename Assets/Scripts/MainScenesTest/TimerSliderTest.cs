/*
using NUnit.Framework;
using UnityEngine;

public class TimerSliderTests
{
    [Test]
    public void OnSliderChanged_UpdateTime()
    {
        // Arrange
        var gameObject = new GameObject();
        var slider = gameObject.AddComponent<Slider>();
        var timer = new Timer();
        var timerSlider = gameObject.AddComponent<TimerSlider>();
        timerSlider.timeSlide = slider;
        timerSlider.timeToUpdate = timer;

        // Act
        timerSlider.OnSliderChanged(0.5f);

        // Assert
        Assert.AreEqual(75f, timer.startingTime);
    }
}
*/