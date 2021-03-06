﻿using System;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager {

    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //dictionary of all space objects
    private Dictionary<Type, List<SpaceObjSandbox>> spaceObjs = new Dictionary<Type, List<SpaceObjSandbox>>();


    //used to parent space objects in Unity's hierarchy
    private const string ENVIRONEMNT_ORGANIZER = "Environment";
    private Transform environmentOrganizer;


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    public void Setup(){
        environmentOrganizer = GameObject.Find(ENVIRONEMNT_ORGANIZER).transform;
    }


    //every frame, tick all objects in the environment
    public void Tick(){
        foreach (Type type in spaceObjs.Keys){
            foreach (SpaceObjSandbox obj in spaceObjs[type]) obj.Tick();
        }
    }


    /// <summary>
    /// Create a new object in space from the Resources folder, set it up, and add it to the relevant list
    /// in the list of space objects.
    /// </summary>
    /// <returns>The space object's gameobject.</returns>
    /// <param name="name">The name of the object's prefab in the Resources folder.</param>
    /// <typeparam name="T">The type of the object's space object script.</typeparam>
    public GameObject CreateSpaceObj<T>(string name, Vector2 position) where T : SpaceObjSandbox{
        Type type = typeof(T);

        if (!spaceObjs.ContainsKey(type)) spaceObjs.Add(type, new List<SpaceObjSandbox>());

        GameObject newObj = MonoBehaviour.Instantiate<GameObject>(Resources.Load<GameObject>(name));
        newObj.transform.parent = environmentOrganizer;
        newObj.GetComponent<SpaceObjSandbox>().Setup(position);
        spaceObjs[type].Add(newObj.GetComponent<SpaceObjSandbox>());

        return newObj;
    }


    /// <summary>
    /// Remove an object from management, usually because it has been destroyed in the game.
    /// </summary>
    /// <param name="obj">The object's script.</param>
    /// <typeparam name="T">The type of the object's script.</typeparam>
    public void RemoveObj<T>(SpaceObjSandbox obj){
        Type type = typeof(T);

        Debug.Assert(spaceObjs.ContainsKey(type), "Trying to remove an object that was never managed.");

        spaceObjs[type].Remove(obj);
        obj.gameObject.SetActive(false);
    }
}
