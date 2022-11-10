using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace PauseScreenScripts
{
    public class ButtonEventTriggers : MonoBehaviour
    {
        public Sprite pauseButtonUp;
        public Sprite pauseButtonDown;
        
        public Sprite menuButtonUp;
        public Sprite menuButtonDown;
        
        public void OnPauseButtonDown()
        {
            GameObject pauseButton = EventSystem.current.currentSelectedGameObject;
            pauseButton.GetComponent<Image>().sprite = pauseButtonDown;
            Smile(pauseButton, true);
        }
        public void OnPauseButtonUp()
        {
            GameObject pauseButton = EventSystem.current.currentSelectedGameObject;
            pauseButton.GetComponent<Image>().sprite = pauseButtonUp;
            Smile(pauseButton, false);
        }

        public void OnPauseMenuButtonDown()
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = menuButtonDown;
        }
        
        public void OnPauseMenuButtonUp()
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = menuButtonUp;
        }

        void Smile(GameObject button, bool smile)
        {
            button.transform.Find("PauseIcon").gameObject.SetActive(!smile);
            button.transform.Find("SmileFace").gameObject.SetActive(smile);
        }
    }
}
