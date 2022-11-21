using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace UIController
{
    public class ResultScreenButtonEventTriggers : MonoBehaviour
    {
        public Sprite buttonUp;
        public Sprite buttonDown;
        
        public void OnButtonDown()
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = buttonDown;
        }
        
        public void OnButtonUp()
        {
            EventSystem.current.currentSelectedGameObject.GetComponent<Image>().sprite = buttonUp;
        }
    }
}
