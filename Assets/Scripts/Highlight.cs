using System;
using UnityEngine;
using UnityEngine.UI;

public class Highlight : MonoBehaviour
{
    // Start is called before the first frame update

    private string[] mixTutorialName = { "Level1", "Catapult1", "Obstacle1", "Magnetic" };

    private string[] colorWind = { "Level1", "Wind1", "ColorAdd1" };

    private string[] colorNight = { "Level1", "Night1", "ColorAdd1" };

    private string[] hugeMap = { "Level1", "SuperItem" };

    private string[] magnetMix = {"Level1", "Obstacle1", "Magnetic", "Fragile1", "Wind1"};

    private string[] brushMix = { "Level1", "Magnetic", "Catapult1", "Brush1"};

    private String level1 = "Level1";

    private String catapult1 = "Catapult1";

    private String obstacle1 = "Obstacle1";

    private String fragile1 = "Fragile1";

    private String wind1 = "Wind1";

    private String colorAdd1 = "ColorAdd1";

    private String night = "Night1";

    private String magnetic = "Magnetic";

    private String superItem = "SuperItem";


    public GameObject textInfo;
    
    void Start()
    {
        textInfo.SetActive(false);
    }

    void HighLightButton(string Name)
    {
        var level = transform.Find(Name);
        var button = level.GetComponent<Button>();
        button.OnSelect(null);
    }

    void DeHighLightButton(string Name)
    {
        var level = transform.Find(Name);
        var button = level.GetComponent<Button>();
        button.OnDeselect(null);
    }
    
    public void OnSelectMix1()
    {
        textInfo.SetActive(true);
        foreach (var s in mixTutorialName)
        {
            HighLightButton(s);
        }
    }

    public void OnDeSelectMix1()
    {
        textInfo.SetActive(false);
        foreach (var s in mixTutorialName)
        {
            DeHighLightButton(s);
        }
    }
    
    public void OnSelectMagnetMix()
    {
        textInfo.SetActive(true);
        foreach (var s in magnetMix)
        {
            HighLightButton(s);
        }
    }

    public void OnDeSelectMagnetMix()
    {
        textInfo.SetActive(false);
        foreach (var s in magnetMix)
        {
            DeHighLightButton(s);
        }
    }

    public void OnSelectColorWind()
    {
        textInfo.SetActive(true);
        foreach (var s in colorWind)
        {
            HighLightButton(s);   
        }
    }

    public void OnDeselectColorWind()
    {
        textInfo.SetActive(false);
        foreach (var s in colorWind)
        {
            DeHighLightButton(s);
        }
    }

    public void OnSelectColorNight()
    {
        textInfo.SetActive(true);
        foreach (var s in colorNight)
        {
            HighLightButton(s);
        }
    }

    public void OnDeselectColorNight()
    {
        textInfo.SetActive(false);
        foreach (var s in colorNight)
        {
            DeHighLightButton(s);
        }
    }
    public void OnSelectHugeMap()
    {
        textInfo.SetActive(true);
        foreach (var s in hugeMap)
        {
            HighLightButton(s);
        }
    }

    public void OnDeselectHugeMap()
    {
        textInfo.SetActive(false);
        foreach (var s in hugeMap)
        {
            DeHighLightButton(s);
        }
    }

    public void OnSelectBrushMixMap()
    {
        textInfo.SetActive(true);
        foreach (var s in brushMix) 
        {
            HighLightButton(s);
        }
    }
    
    public void OnDeSelectBrushMixMap()
    {
        textInfo.SetActive(true);
        foreach (var s in brushMix) 
        {
            DeHighLightButton(s);
        }
    }

    public void OnSelectButton(String s)
    {
        textInfo.SetActive(true);
        HighLightButton(s);
    }

    public void OnDeSelectButton(String s)
    {
        textInfo.SetActive(false);
        DeHighLightButton(s);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
