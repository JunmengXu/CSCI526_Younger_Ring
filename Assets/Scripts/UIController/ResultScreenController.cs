using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    public class ResultScreenController : MonoBehaviour
    {
        public GameObject resultScreen;
        
        public Player player;
    
        public Button retryButton;

        // "You used ...s" Text
        public TMP_Text result;

        // Timer text on the top right
        public TMP_Text timer;

        // Send to google instance
        public SendToGoogle SendLevel3;

        // Only send once to Google
        private bool send;

        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            SendLevel3 = gameObject.AddComponent<SendToGoogle>();

            send = true;
        }
    
        void ResetGame()
        {
            SceneManager.LoadScene("FirstLevelScene");
        }

        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover && send)
            {
                // Send level 2 info to Goolge Form
                SendLevel3.sessionID = GlobalVarStorage.globalSessionID;
                SendLevel3.levelClearTime = timer.text;
                SendLevel3.level = 3;
                SendLevel3.numNumps = player.jumps;
                SendLevel3.Send();

                Time.timeScale = 0;
                result.text = "You used " + timer.text + "s";
                resultScreen.SetActive(true);

                send = false;
            }
        }
    }
}
