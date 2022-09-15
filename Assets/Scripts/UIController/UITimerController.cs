using TMPro;
using UnityEngine;

namespace UIController
{
    public class UITimerController : MonoBehaviour
    {
        // Timer text on the top right
        public TMP_Text timerText;
        
        private float timer = 0;
        private bool pause = false;
        
        void Update()
        {
            if(pause) return;
            else
            {
                timer += Time.deltaTime;
                timerText.text = ((int)timer).ToString();
            }
        }

        public void pauseTimer()
        {
            pause = true;
        }

        public void continueTimer()
        {
            pause = false;
        }
    }
}
