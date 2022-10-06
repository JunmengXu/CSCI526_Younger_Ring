using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ColorAdd
{
    public class ColorAddResultScreenController : MonoBehaviour
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
        public SendToGoogle SendLevel4;

        // Only send once to Google
        private bool send;

        public string retryLevelSceneStr;

        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            selectLevelButton.onClick.AddListener(SelectLevel);

            SendLevel4 = gameObject.AddComponent<SendToGoogle>();

            send = true;
    }

        void ResetGame()
        {
            SceneManager.LoadScene(retryLevelSceneStr);
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
                // Send level 3info to Goolge Form
                SendLevel4.sessionID = GlobalVarStorage.globalSessionID;
                SendLevel4.levelClearTime = timer.text;
                SendLevel4.level = 4;
                SendLevel4.numNumps = player.jumps;
                SendLevel4.Send();

                Time.timeScale = 0;
                result.text = "You used " + timer.text + "s";
                resultScreen.SetActive(true);

                send = false;
            }
        }
    }
}