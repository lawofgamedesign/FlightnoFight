using UnityEngine;

public static class Services
{

    private static EventManager events;
    public static EventManager Events {
        get{
            Debug.Assert(events != null, "No event manager. Are services being created out of order?");
            return events;
        }
        set { events = value; }
    }

    private static InputManager inputs;
    public static InputManager Inputs {
        get{
            Debug.Assert(inputs != null, "No input manager. Are services being created out of order?");
            return inputs;
        }
        set { inputs = value; }
    }


    private static EnvironmentManager environment;
    public static EnvironmentManager Environment {
        get {
            Debug.Assert(environment != null, "No environment manager. Are services being created out of order?");
            return environment;
        }
        set { environment = value; }
    }


    public static LevelManager level;
    public static LevelManager Level {
        get {
            Debug.Assert(level != null, "No level manager. Are services being created out of order?");
            return level;
        }
        set { level = value; }
    }


    public static ScoreManager score;
    public static ScoreManager Score {
        get {
            Debug.Assert(score != null, "No score manager. Are services being created out of order?");
            return score;
        }
        set { score = value; }
    }


    public static SpeedManager speed;
    public static SpeedManager Speed {
        get {
            Debug.Assert(speed != null, "No speed manager. Are services being created out of order?");
            return speed;
        }
        set { speed = value; }
    }
}

