using TMPro;
using UnityEngine;

public class ScoreManager {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////

    //the player
    private const string PLAYER_OBJ = "Player";
    private Transform player;


    //the score readout
    private const string SCORE_OBJ = "Score";
    private TextMeshProUGUI score;


    //the score
    private int currentScore = 0;
    private float timer = 0.0f;
    private float TIME_TO_INCREMENT = 1.0f;


    //scoring regions
    private const float FAST_ZONE = 1.0f;
    private const float SLOW_ZONE = -1.0f;
    private const int FAST_PROGRESS = 3;
    private const int NORMAL_PROGRESS = 2;
    private const int SLOW_PROGRESS = 1;



    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    //initialize variables
    public void Setup(){
        player = GameObject.Find(PLAYER_OBJ).transform;
        score = GameObject.Find(SCORE_OBJ).GetComponent<TextMeshProUGUI>();
    }


    public void Tick(){
        timer += Time.deltaTime;

        if (timer >= TIME_TO_INCREMENT){
            timer = 0.0f;
            IncreaseScore();
        }
    }


    private void IncreaseScore(){
        if (player.position.y > FAST_ZONE) currentScore += FAST_PROGRESS;
        else if (player.position.y < SLOW_ZONE) currentScore += SLOW_PROGRESS;
        else currentScore += NORMAL_PROGRESS;

        score.text = currentScore.ToString();
    }
}
