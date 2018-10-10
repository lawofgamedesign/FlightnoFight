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


    public override void Setup(Vector2 position)
    {
        Debug.Log("Small Asteroid Setup() called; position == " + position);
        rb2D = GetComponent<Rigidbody2D>();
        speed = Random.Range(MIN_SPEED, MAX_SPEED);
        transform.position = position;
        transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, Random.Range(MIN_ANGLE, MAX_ANGLE)));
    }


    protected override void OnTriggerEnter2D(Collider2D other)
    {
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
