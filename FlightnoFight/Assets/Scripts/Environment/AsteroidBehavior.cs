using UnityEngine;

public class AsteroidBehavior : SpaceObjSandbox {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //movement
    protected const float MIN_SPEED = 1.0f;
    protected const float MAX_SPEED = 6.0f;
    protected float speed = 0.0f;


    //direction
    private const float MIN_ANGLE = 165.0f;
    private const float MAX_ANGLE = 195.0f;


    //starting locations
    protected Vector2[] startLocs = new Vector2[5] { new Vector2(-1.5f, 4.0f),
                                                   new Vector2(-0.75f, 4.0f),
                                                   new Vector2(0.0f, 4.0f),
                                                   new Vector2(0.75f, 4.0f),
                                                   new Vector2(1.5f, 4.0f)};


    //detect collision with another asteroid
    protected const string ASTEROID = "Asteroid";
    protected const string SMALL_ASTEROID = "Small Asteroid";



    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //intialize variables
    //position is not used for normal asteroids
    public override void Setup(Vector2 position) {
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        transform.position = startLocs[Random.Range(0, startLocs.Length)];
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(MIN_ANGLE, MAX_ANGLE)));
        base.Setup(position);
    }


    /// <summary>
    /// Move asteroid down the screen.
    /// </summary>
    public override void Tick(){
        rb2D.MovePosition(rb2D.position + (Vector2)transform.up * speed * Time.deltaTime);
    }


    protected virtual void OnTriggerEnter2D(Collider2D other){
        if (other.tag == DANGER_TAG){
            if (other.name.Contains(ASTEROID)){
                Services.Environment.CreateSpaceObj<SmallAsteroidBehavior>(SMALL_ASTEROID, transform.position);
                Services.Environment.RemoveObj<AsteroidBehavior>(this);
            }
        } 
    }
}
