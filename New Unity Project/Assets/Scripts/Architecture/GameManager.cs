using UnityEngine;

public class GameManager : MonoBehaviour {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //player vehicle
    private const string PLAYER_OBJ = "Player";


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    /// <summary>
    /// This is the only Unity-driven setup function in the game. (I.e., no other class has Start(), Awake(), etc.)
    /// 
    /// All other classes that need to set up do so through here.
    /// </summary>
    private void Start(){
        Services.Events = new EventManager();
        Services.Inputs = new InputManager();
        GameObject.Find(PLAYER_OBJ).GetComponent<PlayerControl>().Setup();
    }


    /// <summary>
    /// This is the only update loop permitted in the game. All other classes that need to act each frame
    /// are called through here.
    /// </summary>
    private void Update(){
        Services.Inputs.Tick();
    }
}
