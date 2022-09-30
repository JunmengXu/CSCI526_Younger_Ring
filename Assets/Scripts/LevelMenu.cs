using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public string Level1;
    public string Level2;
    public string Level3;

    public string Catapult1;
    public string Catapult2;
    public string Catapult3;

    // Brush tile levels
    public string Brush1;
    
    // In development sandbox levels
    public string HugeMapLevel;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartLevel1()
    {
        SceneManager.LoadScene(Level1);
    }

    public void StartLevel2()
    {
        SceneManager.LoadScene(Level2);
    }

    public void StartLevel3()
    {
        SceneManager.LoadScene(Level3);
    }

    public void StartCatapult1()
    {
        SceneManager.LoadScene(Catapult1);
    }

    public void StartCatapult2()
    {
        SceneManager.LoadScene(Catapult2);
    }

    public void StartCatapult3()
    {
        SceneManager.LoadScene(Catapult3);
    }
    
    public void StartBrush1()
    {
        SceneManager.LoadScene(Brush1);
    }

    public void StartHugeMapLevel()
    {
        SceneManager.LoadScene(HugeMapLevel);
    }
}
