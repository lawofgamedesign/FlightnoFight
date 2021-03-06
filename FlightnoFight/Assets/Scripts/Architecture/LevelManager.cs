﻿using UnityEngine;

public class LevelManager {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //asteroids
    private const string ASTEROID_OBJ = "Asteroid";
    private float asteroidDelay = 0.25f;
    private float asteroidTimer = 0.0f;


    //nonsense location for objects that handle their own placement
    private Vector2 genericLoc = new Vector2(0.0f, 0.0f);


    /// <summary>
    /// Create asteroids over time.
    /// </summary>
    public void Tick(){
        asteroidTimer += Time.deltaTime;

        if (asteroidTimer >= asteroidDelay){
            Services.Environment.CreateSpaceObj<AsteroidBehavior>(ASTEROID_OBJ, genericLoc);
            asteroidTimer = 0.0f;
        }
    }
}
