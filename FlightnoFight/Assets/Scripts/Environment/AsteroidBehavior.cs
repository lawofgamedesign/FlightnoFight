using UnityEngine;

public class AsteroidBehavior : SpaceObjSandbox {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //movement
    private float speed = 5.0f;


    //starting location
    private Vector2 startLoc = new Vector2(0.0f, 4.0f);



    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    public override void Setup(){
        transform.position = startLoc;
        base.Setup();
    }


    public override void Tick(){
        rb2D.MovePosition(rb2D.position + Vector2.down * speed * Time.deltaTime);
    }
}
