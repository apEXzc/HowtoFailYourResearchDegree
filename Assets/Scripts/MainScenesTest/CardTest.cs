/*
using Nunit.Framework;
using UnityEngine;

[TestFixture]
public class PlanCardTests {
    [Test]
    public void TestPlanCardDefaultValues() {
        // Arrange
        var background = new Sprite();
        var planCard = new PlanCard(background);

        // Assert
        Assert.AreEqual("", planCard.cardName);
        Assert.IsFalse(planCard.Up);
        Assert.IsFalse(planCard.Down);
        Assert.IsFalse(planCard.Left);
        Assert.IsFalse(planCard.Right);
    }

    [Test]
    public void TestPlanCardCardName() {
        // Arrange
        var background = new Sprite();
        var planCard = new PlanCard(background);

        // Act
        planCard.cardName = "Test Card";

        // Assert
        Assert.AreEqual("Test Card", planCard.cardName);
    }

    [Test]
    public void TestPlanCardCardOrientation() {
        // Arrange
        var background = new Sprite();
        var planCard = new PlanCard(background);

        // Act
        planCard.Up = true;
        planCard.Down = true;
        planCard.Left = true;
        planCard.Right = true;

        // Assert
        Assert.IsTrue(planCard.Up);
        Assert.IsTrue(planCard.Down);
        Assert.IsTrue(planCard.Left);
        Assert.IsTrue(planCard.Right);
    }
}

[TestFixture]
public class ContextCardTests {
    [Test]
    public void TestDefaultValues() {
        // Arrange
        var background = new Sprite();
        var contextCard = new ContextCard(background);

        // Assert
        Assert.AreEqual("", contextCard.cardName);
        Assert.IsFalse(contextCard.Up);
        Assert.IsFalse(contextCard.Down);
        Assert.IsFalse(contextCard.Left);
        Assert.IsFalse(contextCard.Right);
    }

    [Test]
    public void TestCardName() {
        // Arrange
        var background = new Sprite();
        var contextCard = new ContextCard(background);

        // Act
        contextCard.cardName = "Test Card";

        // Assert
        Assert.AreEqual("Test Card", contextCard.cardName);
    }

    [Test]
    public void TestCardOrientation() {
        // Arrange
        var background = new Sprite();
        var contextCard = new ContextCard(background);

        // Act
        contextCard.Up = true;
        contextCard.Down = true;
        contextCard.Left = true;
        contextCard.Right = true;

        // Assert
        Assert.IsTrue(contextCard.Up);
        Assert.IsTrue(contextCard.Down);
        Assert.IsTrue(contextCard.Left);
        Assert.IsTrue(contextCard.Right);
    }
}

[TestFixture]
public class ImplementationCardTests {
    [Test]
    public void TestImplementationCardDefaultValues() {
        // Arrange
        var background = new Sprite();
        var implementationCard = new ImplementationCard(background);

        // Assert
        Assert.AreEqual("", implementationCard.cardName);
        Assert.IsFalse(implementationCard.Up);
        Assert.IsFalse(implementationCard.Down);
        Assert.IsFalse(implementationCard.Left);
        Assert.IsFalse(implementationCard.Right);
    }

    [Test]
    public void TestImplementationCardCardName() {
        // Arrange
        var background = new Sprite();
        var implementationCard = new ImplementationCard(background);

        // Act
        implementationCard.cardName = "Test Card";

        // Assert
        Assert.AreEqual("Test Card", implementationCard.cardName);
    }

    [Test]
    public void TestImplementationCardCardOrientation() {
        // Arrange
        var background = new Sprite();
        var implementationCard = new ImplementationCard(background);

        // Act
        implementationCard.Up = true;
        implementationCard.Down = true;
        implementationCard.Left = true;
        implementationCard.Right = true;

        // Assert
        Assert.IsTrue(implementationCard.Up);
        Assert.IsTrue(implementationCard.Down);
        Assert.IsTrue(implementationCard.Left);
        Assert.IsTrue(implementationCard.Right);
    }
}
[TestFixture]
public class WriteUpCardTests {
    [Test]
    public void WriteUpCardDefaultValues() {
        // Arrange
        var background = new Sprite();
        var WriteUpCard = new WriteUpCard(background);

        // Assert
        Assert.AreEqual("", WriteUpCard.cardName);
        Assert.IsFalse(WriteUpCard.Up);
        Assert.IsFalse(WriteUpCard.Down);
        Assert.IsFalse(WriteUpCard.Left);
        Assert.IsFalse(WriteUpCard.Right);
        Assert.IsFalse(WriteUpCard.hasThesis);
    }

    [Test]
    public void TestWriteUpCardCardName() {
        // Arrange
        var background = new Sprite();
        var WriteUpCard = new WriteUpCard(background);

        // Act
        WriteUpCard.cardName = "Test Card";

        // Assert
        Assert.AreEqual("Test Card", WriteUpCard.cardName);
    }

    [Test]
    public void TestWriteUpCardOrientation() {
        // Arrange
        var background = new Sprite();
        var WriteUpCard = new WriteUpCard(background);

        // Act
        WriteUpCard.Up = true;
        WriteUpCard.Down = true;
        WriteUpCard.Left = true;
        WriteUpCard.Right = true;
        WriteUpCard.hasThesis = true;

        // Assert
        Assert.IsTrue(WriteUpCard.Up);
        Assert.IsTrue(WriteUpCard.Down);
        Assert.IsTrue(WriteUpCard.Left);
        Assert.IsTrue(WriteUpCard.Right);
        Assert.IsTrue(WriteUpCard.hasThesis);
    }
}
*/