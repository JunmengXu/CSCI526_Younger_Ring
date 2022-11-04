using System.Collections;
using UnityEngine;

namespace CatapultScripts
{
    public class TutorialController : MonoBehaviour
    {
        public Player player;
        
        public GameObject[] tutorialDialogs;

        public GameObject continueText;


        public int currentIndex = 0;

        public bool paused = false;


        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(WaitBeforeTutorial());
        }

        // Update is called once per frame
        void Update()
        {
            if (currentIndex == 0 && paused)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentIndex++;   

                    Time.timeScale = 1;
                    continueText.SetActive(false);
                    tutorialDialogs[currentIndex - 1].SetActive(false);
                    paused = false;

                }
            }

        }
        
        IEnumerator WaitBeforeTutorial()
        {
            yield return new WaitForSeconds(1);
            Proceed();
        }
        
        void Proceed()
        {
            continueText.SetActive(true);
            for (int i = 0; i < tutorialDialogs.Length; i++)
            {
                tutorialDialogs[i].SetActive(false);
            }
            tutorialDialogs[currentIndex].SetActive(true);
            Time.timeScale = 0;
            paused = true;
        }
    }
}
