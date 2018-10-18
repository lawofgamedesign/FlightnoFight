using UnityEngine;

public class EditorInputManager : InputManager {

    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    /// <summary>
    /// Each frame, if the player is giving an input, send out information PlayerControl needs to move the ship.
    /// </summary>
    public override void Tick()
    {
        lastFramePos = thisFramePos;
        thisFramePos = Input.mousePosition;

        if (Input.GetMouseButton(0)){
            Services.Events.Fire(new InputEvent(lastFramePos, thisFramePos));
        }
    }
}
