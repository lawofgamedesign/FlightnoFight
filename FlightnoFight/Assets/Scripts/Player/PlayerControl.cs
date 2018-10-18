using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //used to calculate movement
    private Vector3 screenMoveDir;
    private float moveMagnitude;
    private Vector3 totalScreenMove;
    private Vector3 characterScreenPos;
    private Vector3 newPos;


    //player's rigidbody
    private Rigidbody2D rb2D;


    //things the player can run into
    private const string DANGER_TAG = "Danger";


    //access to the game manager
    private const string MANAGER_OBJ = "Game manager";


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //initialize variables and register for events
    public void Setup(){
        rb2D = GetComponent<Rigidbody2D>();
        Services.Events.Register<InputEvent>(Move);
    }


    /// <summary>
    /// Move the player ship along with the cursor, without jumping to the location of the cursor.
    /// 
    /// In this way, the player can provide input anywhere on the screen to move the ship, rather
    /// than having to cover it.
    /// </summary>
    /// <param name="e">An InputEvent.</param>
    private void Move(global::Event e)
    {
        Debug.Assert(e.GetType() == typeof(InputEvent), "Non-InputEvent in Move()");

        InputEvent inputEvent = e as InputEvent;

        //calculate movement
        screenMoveDir = (Camera.main.ScreenToWorldPoint(inputEvent.thisFramePos) -
                         Camera.main.ScreenToWorldPoint(inputEvent.lastFramePos)).normalized; //what direction did the input move?
        moveMagnitude = Vector2.Distance(inputEvent.thisFramePos, inputEvent.lastFramePos); //how far did the input move?
        totalScreenMove = screenMoveDir * moveMagnitude; //calculate total movement
        characterScreenPos = Camera.main.WorldToScreenPoint(transform.position); //player position, in terms of the screen


        //move in the same direction, and for the same distance, as the cursor
        //also send out a notification of the player's new position for, e.g., the speed readout
        newPos = Camera.main.ScreenToWorldPoint(characterScreenPos + totalScreenMove);
        rb2D.MovePosition(newPos);
        Services.Events.Fire(new PositionEvent(transform, newPos));
    }


    /// <summary>
    /// Handle collisions.
    /// </summary>
    /// <param name="other">The object the player ran into.</param>
    private void OnTriggerEnter2D(Collider2D other){
        if (other.tag == DANGER_TAG){
            gameObject.SetActive(false);
            GameObject.Find(MANAGER_OBJ).GetComponent<GameManager>().Playing = false;
        }
    }
}
