using UnityEngine;

public class InputManager {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //tracking movement
    protected Vector2 lastFramePos = new Vector2(0.0f, 0.0f);
    protected Vector2 thisFramePos = new Vector2(0.0f, 0.0f);


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    /// <summary>
    /// Each frame, if the player is giving an input, send out information PlayerControl needs to move the ship.
    /// </summary>
    public virtual void Tick(){
        lastFramePos = thisFramePos;
        //thisFramePos = Input.mousePosition;

        //if (Input.GetMouseButton(0)){
        //    Services.Events.Fire(new InputEvent(lastFramePos, thisFramePos));
        //}

        if (Input.touchCount > 0){
            thisFramePos = Input.GetTouch(0).position;

            if (Input.GetTouch(0).phase == TouchPhase.Began) lastFramePos = thisFramePos;
            
            Services.Events.Fire(new InputEvent(lastFramePos, thisFramePos));
        }
    }
}
