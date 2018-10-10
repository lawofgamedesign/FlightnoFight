using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class SpaceObjSandbox : MonoBehaviour {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //rigidbody for the object
    protected Rigidbody2D rb2D;


    //tag for objects that are dangerous to the player
    protected const string DANGER_TAG = "Danger";


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    public virtual void Setup(Vector2 position){
        rb2D = GetComponent<Rigidbody2D>();
    }


    /// <summary>
    /// Each space object is responsible for figuring out how it ticks.
    /// </summary>
    public abstract void Tick();


    /// <summary>
    /// Move the space object.
    /// </summary>
    public virtual void Move(){}
}
