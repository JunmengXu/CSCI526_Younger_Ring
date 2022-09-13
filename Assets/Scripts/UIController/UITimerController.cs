using TMPro;
using UnityEngine;

namespace UIController
{
    public class UITimerController : MonoBehaviour
    {
        // Timer text on the top right
        public TMP_Text timerText;
        
        private float timer = 0;
        
        void Update()
        {
            timer += Time.deltaTime;
            timerText.text = ((int)timer).ToString();
        }
    }
}
