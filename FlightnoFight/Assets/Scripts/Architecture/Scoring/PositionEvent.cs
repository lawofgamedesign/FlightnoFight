using UnityEngine;

public class PositionEvent : Event {

    public readonly Transform obj;
    public readonly Vector3 pos;


    public PositionEvent(Transform obj, Vector3 pos){
        this.obj = obj;
        this.pos = pos;
    }
}
