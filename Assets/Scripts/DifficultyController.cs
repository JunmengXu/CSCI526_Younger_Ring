using System;
using UnityEngine;
using UnityEngine.UI;
using PauseScreenScripts;

public class DifficultyController : MonoBehaviour
{
    public Player player;
    
    public PauseController pauseController;
    
    public Slider jumpSpeedSlider;
    public Slider moveSpeedSlider;

    // Use the slider to change time scale
    public void ChangeScale(float sliderValue)
    {
        // Save the new scale
        PlayerPrefs.SetFloat("Scale", sliderValue);
        
        // Apply the time scale change
        pauseController.cachedTimeScale = PlayerPrefs.GetFloat("Scale");
    }

    public void ChangeHorizontalMoveSpeed(float sliderValue)
    {
        PlayerPrefs.SetFloat("HorizontalScale", sliderValue);
        // Apply the horizontal speed scale change
        player.ChangeForceGravityAndMoveSpeed(9, -14, 6 * sliderValue);
    }

    public void ResetSetting()
    {
        jumpSpeedSlider.value = 1f;
        moveSpeedSlider.value = 1f;
    }

    // Start is called before the first frame update
    void Start()
    {
        // Manually force set the player's attributes, to avoid updating these in the inspector for every scene.
        player.ChangeForceGravityAndMoveSpeed(9, -14, 6);
        
        // Initialize the time scale setting
        pauseController.cachedTimeScale = PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f;
        player.ChangeForceGravityAndMoveSpeed(
            9, 
            -14, 
            6 * (PlayerPrefs.HasKey("HorizontalScale") ? PlayerPrefs.GetFloat("HorizontalScale") : 1f));
        // Initialize slider values
        jumpSpeedSlider.value = PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f;
        moveSpeedSlider.value = PlayerPrefs.HasKey("HorizontalScale") ? PlayerPrefs.GetFloat("HorizontalScale") : 1f;
    }

    private void Update()
    {
        // When exit pause state, if not during tutorial, retain the current difficulty setting
        if (Math.Abs(Time.timeScale - pauseController.cachedTimeScale) > 0)
        {
            if (Time.timeScale != 0)
            {
                // Using time scale to control the player speed, i.e. difficulty
                // Credit: Xiao Li
                Time.timeScale = pauseController.cachedTimeScale;
            }
        }
    }
}
