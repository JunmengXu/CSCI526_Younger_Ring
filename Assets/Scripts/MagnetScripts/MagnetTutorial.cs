using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetTutorial : MonoBehaviour
{
    public Player player;
    
    public GameObject[] tutorialDialogs;

    public GameObject goodJob;

    public GameObject[] parts;

    public GameObject continueText;

    public int currentIndex = 0;

    public bool paused = false;

    public int partCounter = 0;

    public int partOneCounter = 0;

    public int partTwoCounter = 0;

    void Start()
    {
        Time.timeScale = 1;
        StartCoroutine(WaitBeforeTutorial());
    }

    // Update is called once per frame
    void Update()
    {
        
        if ((currentIndex == 0 || 
                currentIndex == 1) && paused)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                currentIndex++;
                Proceed();
            }
        }

        if (currentIndex == 2)
        {
            if (paused && Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                continueText.SetActive(false);
                paused = false;
            }
            if(partOneCounter == 1){
                tutorialDialogs[currentIndex].SetActive(false);
                currentIndex++;
                StartCoroutine(PartFinish());
            }
        }
        if (currentIndex == 3)
        {
            if (paused && Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                continueText.SetActive(false);
                paused = false;
            }
            if(partTwoCounter == 1){
                tutorialDialogs[currentIndex].SetActive(false);
                currentIndex++;
                StartCoroutine(PartFinish());
            }
        }

        if (currentIndex == 4)
        {
            if (paused && Input.GetKeyDown(KeyCode.Return))
            {
                Time.timeScale = 1;
                continueText.SetActive(false);
                paused = false;
            }
        }
    }
    
    IEnumerator WaitBeforeTutorial()
    {
        yield return new WaitForSeconds(1);
        Proceed();
    }
    
    IEnumerator PartFinish()
    {
        goodJob.SetActive(true);
        yield return new WaitForSeconds(2);
        goodJob.SetActive(false);
        parts[partCounter++].SetActive(true);
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
