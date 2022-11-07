using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

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
    public string Brush2;
    public string Brush3;
    
    // In development sandbox levels
    public string HugeMapLevel;
    
    public string Obstacle1;
    public string Obstacle2 ;
    public string Fragile1;

    public string Fragile2;

    public string Wind1;
    public string Wind2;
    public string Wind3;
    public string Wind4;

    public string ColorWind1;

    public string ColorNight;


    public string Night1;
    public string Night2;

    public string Magnetic1;

    public string Mix1;
    
    public string MagnetFramework;

    public string SuperItem1;

    public string BrushMix;

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
    
    public void StartBrush2()
    {
        SceneManager.LoadScene(Brush2);
    }
    
    public void StartBrush3()
    {
        SceneManager.LoadScene(Brush3);
    }

    public void StartHugeMapLevel()
    {
        SceneManager.LoadScene(HugeMapLevel);
    }
    
    public void StartObstacle1()
    {
        SceneManager.LoadScene(Obstacle1);
    }

    public void StartObstacle2()
    {
        SceneManager.LoadScene(Obstacle2);
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

    public void StartColorWind1()
    {
        SceneManager.LoadScene(ColorWind1);
    }

    public void StartColorNight()
    {
        SceneManager.LoadScene(ColorNight);
    }

    public void StartNight1()
    {
        SceneManager.LoadScene(Night1);
    }

    public void StartNight2()
    {
        SceneManager.LoadScene(Night2);
    }

    public void StartMagnetic1()
    {
        SceneManager.LoadScene(Magnetic1);
    }

    public void StartMix1()
    {
        SceneManager.LoadScene(Mix1);
    }

    public void StartSuperItem1() 
    {
        SceneManager.LoadScene(SuperItem1);
    }
    
    public void StartMagnetMix()
    {
        SceneManager.LoadScene(MagnetFramework);
    }

    public void StartBrushMix()
    {
        SceneManager.LoadScene(BrushMix);
    }
}
