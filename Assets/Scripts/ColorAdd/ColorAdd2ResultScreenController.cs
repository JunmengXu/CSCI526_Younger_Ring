using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace ColorAdd
{
    public class ColorAdd2ResultScreenController : MonoBehaviour
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
        public SendToGoogle SendCoLorAdd2;

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

            SendCoLorAdd2 = gameObject.AddComponent<SendToGoogle>();

            send = true;
        }

        void ResetGame()
        {
            SceneManager.LoadScene("ColorAdd_2");
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
                // Send SendCoLorAdd2 info to Goolge Form
                SendCoLorAdd2.sessionID = GlobalVarStorage.globalSessionID;
                SendCoLorAdd2.levelClearTime = timer.text;
                SendCoLorAdd2.level = 2;
                SendCoLorAdd2.numNumps = player.jumps;
                SendCoLorAdd2.Send();

                Time.timeScale = 0;
                result.text = "You used " + timer.text + "s";
                resultScreen.SetActive(true);

                send = false;
            }
        }
    }
}