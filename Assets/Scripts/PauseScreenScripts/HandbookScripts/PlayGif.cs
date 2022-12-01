using System;
using UnityEngine;
using UnityEngine.UI;

namespace PauseScreenScripts.HandbookScripts
{
    public class PlayGif : MonoBehaviour
    {
        public Sprite[] frames;
        private const int FramesPerSecond = 10;
        private Image imageComponent;

        private void Start()
        {
            imageComponent = GetComponent<Image>();
        }

        void Update() {
            int index = (int)((Time.unscaledTime * FramesPerSecond) % frames.Length);
            imageComponent.sprite = frames[index];
        }
    }
}
