using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public string Level1;
    public string Level2;
    public string Level3;
    public string ColorAdd1;
    public string ColorAdd2;


    public string Catapult1;
    public string Catapult2;
    public string Catapult3;

    // Brush tile levels
    public string Brush1;
    
    // In development sandbox levels
    public string HugeMapLevel;
    
    public string Obstacle1;
    public string Fragile1;

    public string Fragile2;

    public string Wind1;
    public string Wind2;
    public string Wind3;
    public string Wind4;

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
    public void StartColorAdd1()
    {
        SceneManager.LoadScene(ColorAdd1);
    }
    public void StartColorAdd2()
    {
        SceneManager.LoadScene(ColorAdd2);
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
    
    public void StartObstacle1()
    {
        SceneManager.LoadScene(Obstacle1);
    }

    public void StartFragile1()
    {
        SceneManager.LoadScene(Fragile1);
    }

    public void StartFragile2()
    {
        SceneManager.LoadScene(Fragile2);
    }

    public void StartWind1()
    {
        SceneManager.LoadScene(Wind1);
    }

    public void StartWind2()
    {
        SceneManager.LoadScene(Wind2);
    }

    public void StartWind3()
    {
        SceneManager.LoadScene(Wind3);
    }

    public void StartWind4()
    {
        SceneManager.LoadScene(Wind4);
    }
}
