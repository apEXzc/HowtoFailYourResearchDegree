/*
using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragAndDropTest
{
    private DragAndDrop dragAndDrop;
    private GameObject gameObject;

    [SetUp]
    public void SetUp()
    {
        gameObject = new GameObject();
        dragAndDrop = gameObject.AddComponent<DragAndDrop>();
    }

    [TearDown]
    public void TearDown()
    {
        Object.Destroy(gameObject);
    }

    [Test]
    public void TestStart()
    {
        dragAndDrop.Start();
        Assert.That(dragAndDrop.rectTras, Is.Not.Null);
        Assert.That(dragAndDrop.canvasGroup, Is.Not.Null);
        Assert.That(dragAndDrop.startPos, Is.EqualTo(dragAndDrop.transform.position));
    }

    [Test]
    public void TestOnBeginDrag()
    {
        var eventData = new PointerEventData(EventSystem.current);
        dragAndDrop.OnBeginDrag(eventData);
        Assert.That(dragAndDrop.canvasGroup.blocksRaycasts, Is.False);
    }

    [Test]
    public void TestOnDrag()
    {
        var eventData = new PointerEventData(EventSystem.current);
        dragAndDrop.OnBeginDrag(eventData);
        Vector3 originalPos = dragAndDrop.transform.position;
        dragAndDrop.OnDrag(eventData);
        Assert.That(dragAndDrop.transform.position, Is.Not.EqualTo(originalPos));
    }

    [Test]
    public void TestOnEndDrag()
    {
        var eventData = new PointerEventData(EventSystem.current);
        dragAndDrop.OnBeginDrag(eventData);
        dragAndDrop.OnEndDrag(eventData);
        Assert.That(dragAndDrop.canvasGroup.blocksRaycasts, Is.True);
    }

    [Test]
    public void TestResetPosition()
    {
        dragAndDrop.Start();
        dragAndDrop.transform.position = new Vector3(1, 1, 1);
        dragAndDrop.ResetPosition();
        Assert.That(dragAndDrop.transform.position, Is.EqualTo(dragAndDrop.startPos));
    }
}
*/