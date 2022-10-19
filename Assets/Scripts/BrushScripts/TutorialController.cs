using System.Collections;
using UnityEngine;

namespace BrushScripts
{
    public class TutorialController : MonoBehaviour
    {
        public Player player;
        
        public GameObject[] tutorialDialogs;

        public GameObject goodJob;

        public GameObject partTwo;

        public GameObject partThree;

        public TutorialPassDetector tutorialPassDetector;

        public TileBrush playerBrush;

        public GameObject continueText;

        public GameObject resultScreen;

        public GameObject tutorial;

        public GameObject actualLevel;

        public int currentIndex = 0;

        public bool paused = false;

        private bool finishedPartOne = false;
        
        private bool finishedPartTwo = false;
        
        private bool finishedPartThree = false;

        private bool finishDisplay = false;

        // Start is called before the first frame update
        void Start()
        {
            Time.timeScale = 1;
            StartCoroutine(WaitBeforeTutorial());
        }

        // Update is called once per frame
        void Update()
        {
            if ((currentIndex == 0 || 
                 currentIndex == 1 || 
                 currentIndex == 6) && paused)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentIndex++;
                    Proceed();
                }
            }
            
            if (currentIndex == 2 && paused)
            {
                if (Input.GetKeyDown(KeyCode.Return))
                {
                    currentIndex++;
                }
            }

            if (currentIndex == 3)
            {
                if (paused && !finishedPartOne)
                {
                    Time.timeScale = 1;
                    continueText.SetActive(false);
                    paused = false;
                }

                if (!paused && !finishedPartOne)
                {
                    if (playerBrush.brushes == 0)
                    {
                        finishedPartOne = true;
                        tutorialDialogs[currentIndex - 1].SetActive(false);
                        StartCoroutine(PartOneFinish());
                    }
                }

                if (finishedPartOne)
                {
                    if (Input.GetKeyDown(KeyCode.Return) && finishDisplay)
                    {
                        currentIndex++;
                        Proceed();
                        currentIndex++;
                        finishDisplay = false;
                    }
                }
            }

            if (currentIndex == 5)
            {
                if (paused && !finishedPartTwo)
                {
                    Time.timeScale = 1;
                    continueText.SetActive(false);
                    paused = false;
                }

                if (!paused && !finishedPartTwo)
                {
                    if (tutorialPassDetector.partTwoComplete)
                    {
                        finishedPartTwo = true;
                        tutorialDialogs[currentIndex - 1].SetActive(false);
                        StartCoroutine(PartTwoFinish());
                    }
                }

                if (finishedPartTwo)
                {
                    if (Input.GetKeyDown(KeyCode.Return) && finishDisplay)
                    {
                        currentIndex++;
                        Proceed();
                        finishDisplay = false;
                    }
                }
            }

            if (currentIndex == 7)
            {
                if (paused && !finishedPartThree)
                {
                    Time.timeScale = 1;
                    continueText.SetActive(false);
                    paused = false;
                }

                if (!paused && !finishedPartThree)
                {
                    if (Input.GetKeyDown(KeyCode.Space))
                    {
                        finishedPartThree = true;
                        tutorialDialogs[currentIndex].SetActive(false);
                        StartCoroutine(PartThreeFinish());
                    }
                }
            }

            if (currentIndex == 8)
            {
                if (paused)
                {
                    Time.timeScale = 1;
                    continueText.SetActive(false);
                    paused = false;
                }

                if (player.gameover)
                {
                    Time.timeScale = 0;
                    tutorialDialogs[currentIndex].SetActive(false);
                    resultScreen.SetActive(true);
                }
            }

        }
        
        IEnumerator WaitBeforeTutorial()
        {
            yield return new WaitForSeconds(1);
            Proceed();
        }
        
        IEnumerator PartOneFinish()
        {
            goodJob.SetActive(true);
            yield return new WaitForSeconds(2);
            goodJob.SetActive(false);
            partTwo.SetActive(true);
            Proceed();
            finishDisplay = true;
        }
        
        IEnumerator PartTwoFinish()
        {
            yield return new WaitForSeconds(2);
            Proceed();
            finishDisplay = true;
        }
        
        IEnumerator PartThreeFinish()
        {
            goodJob.SetActive(true);
            yield return new WaitForSeconds(2);
            goodJob.SetActive(false);
            partThree.SetActive(true);
            currentIndex++;
            Proceed();
            finishDisplay = true;
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

        public void StartLevel()
        {
            tutorial.SetActive(false);
            actualLevel.SetActive(true);
            Time.timeScale = 1;
        }
    }
}
