using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


/*
 * This file is aim to create several card objects
 * Only one component --- card background
 * May add more logic components, like check card up/down/left/right arrow
 */


public class Card : MonoBehaviour
{
    public Sprite background; 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public Card(Sprite background) {
        this.background = background;
    }
}



// active card base and its children
public class ActiveCardBase : Card
{

    public ActiveCardBase(Sprite background) : base(background) {

    }

}

public class PlanCard : ActiveCardBase
{
    public string cardName;
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;

    public PlanCard(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right) : base(background)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }

    public void set(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }

}

public class ContextCard : ActiveCardBase
{
    public string cardName;
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;

    public ContextCard(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right) : base(background)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }

    public void set(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }
}

public class ImplementationCard : ActiveCardBase
{
    public string cardName;
    public bool Up = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;

    public ImplementationCard(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right) : base(background)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }

    public void set(Sprite background, string cardName, bool Up, bool Down, bool Left, bool Right)
    {
        this.background = background;
        this.cardName = cardName;
        this.Up = Up;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }
}

public class WriteUpCard : ActiveCardBase
{
    public string cardName;
    public bool Thesis = false;
    public bool Down = false;
    public bool Left = false;
    public bool Right = false;

    public bool hasThesis;
    public bool prevent = false;


    public WriteUpCard(Sprite background, string cardName, bool Thesis, bool Down, bool Left, bool Right) : base(background)
    {
        hasThesis = false;
        this.background = background;
        this.cardName = cardName;
        this.Thesis = Thesis;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }
    public void set(Sprite background, string cardName, bool Thesis, bool Down, bool Left, bool Right)
    {
        this.background = background;
        this.cardName = cardName;
        this.Thesis = Thesis;
        this.Down = Down;
        this.Left = Left;
        this.Right = Right;
    }

}


// Event card and its children
public class EventCardBase : Card
{

    public EventCardBase(Sprite background) : base(background) {

    }

}


public class EventContextCard : EventCardBase
{
    public string effect;

    public EventContextCard(Sprite background) : base(background)
    {

    }
    
    public void set(Sprite background, string effect)
    {
        this.background = background;
        this.effect = effect;
    }

}

public class EventImplementationCard : EventCardBase
{
    public string effect;

    public EventImplementationCard(Sprite background) : base(background)
    {

    }
    
    public void set(Sprite background, string effect)
    {
        this.background = background;
        this.effect = effect;
    }

}

public class EventWriteUpCard : EventCardBase
{
    public string effect;

    public EventWriteUpCard(Sprite background) : base(background)
    {

    }
    
    public void set(Sprite background, string effect)
    {
        this.background = background;
        this.effect = effect;
    }

}