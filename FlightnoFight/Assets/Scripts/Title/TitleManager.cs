namespace Title
{
    using UnityEngine;
    using UnityEngine.SceneManagement;

    public class TitleManager : MonoBehaviour
    {


        ////////////////////////////////////////////////
        /// Fields
        ////////////////////////////////////////////////


        //scene to load
        private const string GAME_SCENE = "Game";


        //delegate for input-listening functions
        private delegate bool inputMethod();
        private inputMethod inputFunction;


        ////////////////////////////////////////////////
        /// Fields
        ////////////////////////////////////////////////


        /// <summary>
        /// Determine what kind of inputs to listen for: mouse (if running in the editor) or touch (for builds).
        /// </summary>
        private void Start(){
            if (Application.isEditor) inputFunction = CheckMouseInput;
            else inputFunction = CheckTouchInput;
        }


        /// <summary>
        /// Load game on input.
        /// </summary>
        private void Update(){
            if (inputFunction()) SceneManager.LoadScene(GAME_SCENE);
        }


        /// <summary>
        /// Check for touch input.
        /// </summary>
        /// <returns><c>true</c> if there is a touch, <c>false</c> otherwise.</returns>
        private bool CheckTouchInput(){
            if (Input.touchCount > 0) return true;
            else return false;
        }


        /// <summary>
        /// Check for left mouse button being pressed.
        /// </summary>
        /// <returns><c>true</c> if LMB is pressed, <c>false</c> otherwise.</returns>
        private bool CheckMouseInput(){
            if (Input.GetMouseButtonDown(0)) return true;
            else return false;
        }
    }
}
