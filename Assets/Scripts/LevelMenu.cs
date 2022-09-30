using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelMenu : MonoBehaviour
{
    public string Level1;
    public string Level2;
    public string Level3;
    public string Obstacle1;
    public string Fragile1;

    public string Fragile2;

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
}
