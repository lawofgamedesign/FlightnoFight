using TMPro;
using UnityEngine;

public class SpeedManager {


    ////////////////////////////////////////////////
    /// Fields
    ////////////////////////////////////////////////


    //speeds
    private const string SLOW = "slow";
    private const string MEDIUM = "medium";
    private const string FAST = "fast";


    //speed readout
    private TextMeshProUGUI readout;
    private const string READOUT_OBJ = "Speed marker";


    //speed readout positions
    private Vector3 pos;


    ////////////////////////////////////////////////
    /// Functions
    ////////////////////////////////////////////////


    public void Setup(){
        Services.Events.Register<PositionEvent>(MoveSpeedMarker);
        readout = GameObject.Find(READOUT_OBJ).GetComponent<TextMeshProUGUI>();
    }


    private void MoveSpeedMarker(global::Event e){
        Debug.Assert(e.GetType() == typeof(PositionEvent), "Non-PositionEvent in MoveSpeedMarker");

        PositionEvent posEvent = e as PositionEvent;

        readout.rectTransform.position = RepositionMarker(posEvent.pos);
        readout.text = ChangeMarkerText(posEvent.pos);
        readout.color = ChangeMarkerColor(posEvent.pos);
    }


    private Vector3 RepositionMarker(Vector3 position){
        pos = readout.rectTransform.position;
        pos.y = Camera.main.WorldToScreenPoint(position).y;
        return pos;
    }


    private string ChangeMarkerText(Vector3 position){
        if (position.y >= ScoreManager.FAST_ZONE) return FAST;
        else if (position.y <= ScoreManager.SLOW_ZONE) return SLOW;
        else return MEDIUM;
    }


    private Color ChangeMarkerColor(Vector3 position){
        if (position.y >= ScoreManager.FAST_ZONE) return Color.green;
        else if (position.y <= ScoreManager.SLOW_ZONE) return Color.red;
        else return Color.yellow;
    }
}
