using UnityEngine;

public class InputEvent : Event {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //screen positions, this frame and last
    public readonly Vector2 lastFramePos;
    public readonly Vector2 thisFramePos;


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //constructor
    public InputEvent(Vector2 lastFramePos, Vector2 thisFramePos){
        this.lastFramePos = lastFramePos;
        this.thisFramePos = thisFramePos;
    }
}
