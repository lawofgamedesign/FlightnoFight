using UnityEngine;

public class InputManager {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //tracking movement
    private Vector2 lastFramePos = new Vector2(0.0f, 0.0f);
    private Vector2 thisFramePos = new Vector2(0.0f, 0.0f);


    /// <summary>
    /// Each frame, if the player is giving an input, send out information PlayerControl needs to move the ship.
    /// </summary>
    public void Tick(){
        lastFramePos = thisFramePos;
        thisFramePos = Input.mousePosition;

        if (Input.GetMouseButton(0)){
            Services.Events.Fire(new InputEvent(lastFramePos, thisFramePos));
        }
    }
}
