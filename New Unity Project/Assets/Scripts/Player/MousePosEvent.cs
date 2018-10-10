using UnityEngine;

public class MousePosEvent : Event
{


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //the mouse's position on screen
    //(0, 0) is the bottom-left
    public readonly Vector3 mousePos;


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //constructor
    public MousePosEvent(Vector3 mousePos)
    {
        this.mousePos = mousePos;
    }
}

