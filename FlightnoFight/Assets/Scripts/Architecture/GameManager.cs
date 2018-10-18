using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //is the game underway?
    public bool Playing { get; set; }


    //player vehicle
    private const string PLAYER_OBJ = "Player";


    //restart process
    private const float RESTART_DELAY = 1.5f;
    private float restartTimer = 0.0f;
    private const string TITLE_SCENE = "Title";


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
        Services.Environment = new EnvironmentManager();
        Services.Environment.Setup();
        Services.Level = new LevelManager();
        Services.Score = new ScoreManager();
        Services.Score.Setup();
        GameObject.Find(PLAYER_OBJ).GetComponent<PlayerControl>().Setup();

        if (Application.isEditor) Services.Inputs = new EditorInputManager();
        else Services.Inputs = new InputManager();

        Playing = true;
    }


    /// <summary>
    /// This is the only update loop permitted in the game. All other classes that need to act each frame
    /// are called through here.
    /// </summary>
    private void Update(){
        if (Playing) Play();
        else CountdownToRestart();

       
    }


    /// <summary>
    /// All actions that occur each frame of play.
    /// </summary>
    private void Play(){
        Services.Inputs.Tick();
        Services.Environment.Tick();
        Services.Level.Tick();
        Services.Score.Tick();
    }


    /// <summary>
    /// All actions required to end the game.
    /// </summary>
    private void CountdownToRestart(){
        restartTimer += Time.deltaTime;

        if (restartTimer >= RESTART_DELAY) SceneManager.LoadScene(TITLE_SCENE);
    }
}
