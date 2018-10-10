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
        currentScore++;

        score.text = currentScore.ToString();
    }
}
