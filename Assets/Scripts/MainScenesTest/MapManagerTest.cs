/*using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

[TestFixture]
public class MapManagerTests
{
    private MapManager _mapManager;
    private GameObject _card;
    private DragAndDrop _dragAndDrop;

    [SetUp]
    public void SetUp()
    {
        // Create a new instance of the MapManager class
        _mapManager = new MapManager();
        _mapManager.id = 1;
        // Create a new GameObject to represent the card
        _card = new GameObject();
        _dragAndDrop = _card.AddComponent<DragAndDrop>();
        _dragAndDrop.id = 1;
    }

    [Test]
    public void OnDrop_CardIdMatchesBackgroundId_CardIsPlacedOnBackgroundAndDestroyed()
    {
        // Create a new PointerEventData object
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.pointerDrag = _card;

        // Call the OnDrop method
        _mapManager.OnDrop(pointerEventData);

        // Assert that the card's position is set to the background's position
        Assert.AreEqual(_card.GetComponent<RectTransform>().position, _mapManager.GetComponent<RectTransform>().position);
        // Assert that the background object is deactivated
        Assert.IsFalse(_mapManager.gameObject.activeSelf);
        // Assert that the DragAndDrop component is destroyed
        Assert.IsNull(_card.GetComponent<DragAndDrop>());
    }

    [Test]
    public void OnDrop_CardIdDoesNotMatchBackgroundId_CardIsMovedBackToOriginalPosition()
    {
        _dragAndDrop.id = 2;
        Vector3 originalPosition = _card.GetComponent<RectTransform>().position;
        // Create a new PointerEventData object
        PointerEventData pointerEventData = new PointerEventData(EventSystem.current);
        pointerEventData.pointerDrag = _card;

        // Call the OnDrop method
        _mapManager.OnDrop(pointerEventData);

        // Assert that the card's position is set to the background's position
        Assert.AreEqual(originalPosition, _card.GetComponent<RectTransform>().position);
    }
}
*/