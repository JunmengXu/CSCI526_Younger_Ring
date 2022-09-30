using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    public class LimitedJump1ResultScreenController : MonoBehaviour
    {
        public GameObject resultScreen;
        
        public Player player;
    
        public Button retryButton;
        public Button selectLevelButton;

        // "You used ...s" Text
        public TMP_Text result;

        // Timer text on the top right
        public TMP_Text timer;

        // Send to google instance
        public SendToGoogle SendLevelOb1;

        // Only send once to Google
        private bool send;

        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            selectLevelButton.onClick.AddListener(SelectLevel);

            SendLevelOb1 = gameObject.AddComponent<SendToGoogle>();

            send = true;
    }

        void ResetGame()
        {
            SceneManager.LoadScene("limitedJump_1");
        }
        void SelectLevel()
        {
            SceneManager.LoadScene("LevelMenu");
        }
        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover && send)
            {
                // Send level 1 info to Goolge Form
                SendLevelOb1.sessionID = GlobalVarStorage.globalSessionID;
                SendLevelOb1.levelClearTime = timer.text;
                SendLevelOb1.level = 10;
                SendLevelOb1.numNumps = player.jumps;
                SendLevelOb1.Send();

                Time.timeScale = 0;
                result.text = "You used " + timer.text + "s";
                resultScreen.SetActive(true);

                send = false;
            }
        }
    }
}