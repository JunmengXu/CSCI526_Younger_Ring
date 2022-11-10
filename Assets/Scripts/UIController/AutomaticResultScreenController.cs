using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    public class AutomaticResultScreenController : MonoBehaviour
    {

        public Player player;

        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
        }
        

        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover || Input.GetKeyDown(KeyCode.Return))
            {
                SceneManager.LoadScene("LevelMenu");
            }
        }
    }
}
