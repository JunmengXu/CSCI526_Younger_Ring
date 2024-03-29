using UnityEngine;
using UnityEngine.SceneManagement;

namespace PauseScreenScripts
{
    public class PauseScreenButtonsOnClickListeners : MonoBehaviour
    {
        public PauseController pauseController;
        
        public GameObject pauseMenu;
        
        public GameObject pauseOptions;

        public GameObject handBookScreen;

        public GameObject fakeStage;
        
        public GameObject speedSettingMenu;

        public SendToGoogle sendManger;

        void Start()
        {
            sendManger = GameObject.Find("AnalyticsManager").GetComponent<SendToGoogle>();
        }

        public void PauseGame()
        {
            if (Time.timeScale == 0)
            {
                pauseController.duringTimeFreeze = true;
            }
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }
        
        public void ResumeGame()
        {
            if (!pauseController.duringTimeFreeze)
            {
                Time.timeScale = pauseController.cachedTimeScale;
            }
            fakeStage.SetActive(false);
            speedSettingMenu.SetActive(false);
            pauseOptions.SetActive(true);
            pauseMenu.SetActive(false);
            pauseController.duringTimeFreeze = false;
        }
        
        public void ToggleDifficultyButtons()
        {
            pauseOptions.SetActive(false);
            fakeStage.SetActive(true);
            speedSettingMenu.SetActive(true);
        }

        public void RetryCurrentLevel()
        {
            // send analytics for retry
            sendManger.status = 2;
            sendManger.Send();

            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ReturnToMainMenu()
        {
            // send analytics for leave current level
            sendManger.status = 2;
            sendManger.Send();
            SceneManager.LoadScene("LevelMenu");
        }

        public void GoBack()
        {
            fakeStage.SetActive(false);
            pauseOptions.SetActive(true);
            speedSettingMenu.SetActive(false);
        }

        public void OpenHandBook()
        {
            pauseOptions.SetActive(false);
            handBookScreen.SetActive(true);
        }

        public void QuitHandBook()
        {
            handBookScreen.SetActive(false);
            pauseOptions.SetActive(true);
        }
    }
}
