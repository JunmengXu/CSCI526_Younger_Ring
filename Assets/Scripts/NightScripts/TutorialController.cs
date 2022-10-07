using System.Collections;
using UnityEngine;

namespace NightScripts
{
    public class TutorialController : MonoBehaviour
    {
        public GameObject[] tutorialDialogs;

        public int currentIndex = 0;


        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 0;
            tutorialDialogs[0].SetActive(true);
            tutorialDialogs[1].SetActive(false);
            tutorialDialogs[2].SetActive(false);
            tutorialDialogs[3].SetActive(true);
        }

        // Update is called once per frame
        void Update()
        {
            if(currentIndex == 3)
            {
                tutorialDialogs[2].SetActive(false);
                tutorialDialogs[3].SetActive(false);
                Time.timeScale = 1;
                currentIndex++; 
            }
            else if(currentIndex < 3)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    tutorialDialogs[currentIndex].SetActive(false);
                    currentIndex++;
                    tutorialDialogs[currentIndex].SetActive(true);
                }
            }
        }
        
    }
}
