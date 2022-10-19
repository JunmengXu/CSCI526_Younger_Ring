using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    public class LimitedJump2ResultScreenController : MonoBehaviour
    {
        public GameObject resultScreen;
        
        public Player player;
    
        public Button retryButton;
        public Button selectLevelButton;

        // "You used ...s" Text
        public TMP_Text result;

        // Timer text on the top right
        public TMP_Text timer;


        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            selectLevelButton.onClick.AddListener(SelectLevel);
    }

        void ResetGame()
        {
            SceneManager.LoadScene("fragile_2");
        }
        void SelectLevel()
        {
            SceneManager.LoadScene("LevelMenu");
        }
        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover)
            {
                Time.timeScale = 0;
                result.text = "You used " + timer.text + "s";
                resultScreen.SetActive(true);
            }
        }
    }
}