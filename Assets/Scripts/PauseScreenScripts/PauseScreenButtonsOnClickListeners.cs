using UnityEngine;
using UnityEngine.SceneManagement;

namespace PauseScreenScripts
{
    public class PauseScreenButtonsOnClickListeners : MonoBehaviour
    {
        public PauseController pauseController;
        
        public GameObject pauseMenu;
        
        public GameObject pauseOptions;
        
        public GameObject difficultySelectionButtons;

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
            pauseMenu.SetActive(false);
            pauseController.duringTimeFreeze = false;
        }
        
        public void ToggleDifficultyButtons()
        {
            pauseOptions.SetActive(false);
            difficultySelectionButtons.SetActive(true);
        }

        public void RetryCurrentLevel()
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void ReturnToMainMenu()
        {
            SceneManager.LoadScene("LevelMenu");
        }

        public void GoBack()
        {
            pauseOptions.SetActive(true);
            difficultySelectionButtons.SetActive(false);
        }
    }
}
