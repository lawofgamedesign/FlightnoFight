using UnityEngine;

public class SmallAsteroidBehavior : AsteroidBehavior {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////

    private const float MIN_ANGLE = 90.0f;
    private const float MAX_ANGLE = 270.0f;


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //initialize variables
    //don't call base.Setup here! Doing so will make this behave like a large asteroid.
    public override void Setup(Vector2 position){
        rb2D = GetComponent<Rigidbody2D>();
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        transform.position = position;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(MIN_ANGLE, MAX_ANGLE)));
    }


    /// <summary>
    /// Handle collisions.
    /// </summary>
    /// <param name="other">The collider of the object with which this collided.</param>
    protected override void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == DANGER_TAG)
        {
            if (other.name.Contains(ASTEROID))
            {
                Services.Environment.CreateSpaceObj<SmallAsteroidBehavior>(SMALL_ASTEROID, transform.position);
                Services.Environment.RemoveObj<SmallAsteroidBehavior>(this);
            }
        }
    }
}
