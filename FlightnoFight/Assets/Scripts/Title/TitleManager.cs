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


        //load game on touch
        void Update()
        {
            if (Input.touchCount > 0) SceneManager.LoadScene(GAME_SCENE);
        }
    }
}
