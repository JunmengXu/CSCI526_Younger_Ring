using UnityEngine;

namespace PauseScreenScripts
{
    public class PauseController : MonoBehaviour
    {
        public GameObject pauseMenu;

        public GameObject pauseOptions;
        
        public GameObject speedSettingMenu;

        public GameObject fakeStage;

        public GameObject handBookScreen;

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
            fakeStage.SetActive(false);
            speedSettingMenu.SetActive(false);
            handBookScreen.SetActive(false);
            pauseOptions.SetActive(true);
            pauseMenu.SetActive(false);
        }

        bool IsPaused()
        {
            return pauseMenu.activeSelf;
        }
    }
}
