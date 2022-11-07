using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UIController
{
    public class NextLevel : MonoBehaviour
    {
        private readonly string[] levelList = {
            "FirstLevelScene",
            "SecondLevel1",
            "SampleScene",
            "Catapult_1",
            "Catapult_2",
            "Catapult_3",
            "Brush_1",
            "Brush_2",
            "Brush_3",
            "Obstacle1Scene",
            "Obstacle2",
            "fragile_1",
            "fragile_2",
            "Wind_1",
            "Wind_2",
            "Wind_3",
            "Wind_4",
            "ColorAdd_1",
            "ColorAdd_2",
            "Night_1",
            "Night_2",
            "Magnet Tutorial",
            "SuperItem_1",
            "ColorAddWindNew_1",
            "Level3",
            "Mix_1",
            "magnetFramework",
            "NightColorAdd_1",
            "Mix_Brush_Catapult_Magnet"
        };

        private string currentSceneName;
        private int currentSceneLocalIndex;

        private Button nextLevelButton;
        
        // Start is called before the first frame update
        void Start()
        {
            currentSceneName = SceneManager.GetActiveScene().name;
            currentSceneLocalIndex = Array.IndexOf(levelList, currentSceneName);
            if (currentSceneLocalIndex == levelList.Length - 1)
            {
                gameObject.SetActive(false);
            }
            
            nextLevelButton = GetComponent<Button>();
            nextLevelButton.onClick.AddListener(LoadNextLevel);
        }

        void LoadNextLevel()
        {
            SceneManager.LoadScene(levelList[currentSceneLocalIndex + 1]);
        }
    }
}
