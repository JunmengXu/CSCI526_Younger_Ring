using UnityEngine;

namespace PauseScreenScripts
{
    public class PauseController : MonoBehaviour
    {
        public GameObject pauseMenu;

        public GameObject pauseOptions;
        
        public GameObject difficultySelectionButtons;

        public bool duringTimeFreeze = false;

        // Store the selected difficulty time scale
        public float cachedTimeScale;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                bool isPaused = IsPaused();
                if (!isPaused)
                {
                    PauseGame();
                }

                if (isPaused)
                {
                    ResumeGame();
                }
            }
        }

        void PauseGame()
        {
            if (Time.timeScale == 0)
            {
                duringTimeFreeze = true;
            }
            Time.timeScale = 0;
            pauseMenu.SetActive(true);
        }

        void ResumeGame()
        {
            if (!duringTimeFreeze)
            {
                Time.timeScale = cachedTimeScale;
            }
            ResetPauseScreen();
            duringTimeFreeze = false;
        }

        void ResetPauseScreen()
        {
            difficultySelectionButtons.SetActive(false);
            pauseOptions.SetActive(true);
            pauseMenu.SetActive(false);
        }

        bool IsPaused()
        {
            return pauseMenu.activeSelf;
        }
    }
}
