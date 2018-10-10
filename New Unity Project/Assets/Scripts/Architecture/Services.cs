using UnityEngine;

public static class Services
{

    private static EventManager events;
    public static EventManager Events
    {
        get
        {
            Debug.Assert(events != null, "No event manager. Are services being created out of order?");
            return events;
        }
        set { events = value; }
    }

    private static InputManager inputs;
    public static InputManager Inputs
    {
        get
        {
            Debug.Assert(inputs != null, "No input manager. Are services being created out of order?");
            return inputs;
        }
        set { inputs = value; }
    }
}

