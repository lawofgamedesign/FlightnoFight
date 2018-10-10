using UnityEngine;

public class AsteroidBehavior : SpaceObjSandbox {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //movement
    private const float MIN_SPEED = 3.0f;
    private const float MAX_SPEED = 6.0f;
    private float speed = 0.0f;


    //direction
    private const float MIN_ANGLE = 135.0f;
    private const float MAX_ANGLE = 225.0f;


    //starting locations
    private Vector2[] startLocs = new Vector2[5] { new Vector2(-1.5f, 4.0f),
                                                   new Vector2(-0.75f, 4.0f),
                                                   new Vector2(0.0f, 4.0f),
                                                   new Vector2(0.75f, 4.0f),
                                                   new Vector2(1.5f, 4.0f)};



    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    public override void Setup(){
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        transform.position = startLocs[Random.Range(0, startLocs.Length)];
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(MIN_ANGLE, MAX_ANGLE)));
        base.Setup();
    }


    public override void Tick(){
        rb2D.MovePosition(rb2D.position + (Vector2)transform.up * speed * Time.deltaTime);
    }
}
