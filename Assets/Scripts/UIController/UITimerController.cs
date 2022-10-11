using System;
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
            if (Time.timeScale != 0)
            {
                timer += Time.unscaledDeltaTime;
            }
            timerText.text = ((int)timer).ToString();
        }
    }
}
