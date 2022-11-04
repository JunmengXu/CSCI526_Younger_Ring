using System;
using UnityEngine;
using UnityEngine.UI;
using PauseScreenScripts;
using PauseScreenScripts.DifficultySettingScripts;

public class DifficultyController : MonoBehaviour
{
    public Player player;
    
    public PauseController pauseController;

    public PlayerPreference playerPreference;
    public Slider jumpSpeedSlider;

    // Use the slider to change time scale
    public void ChangeScale(float sliderValue)
    {
        // Save the new scale to playerPreference
        // playerPreference.scale = sliderValue;
        PlayerPrefs.SetFloat("Scale", sliderValue);
        
        // Apply the time scale change
        // pauseController.cachedTimeScale = playerPreference.scale;
        pauseController.cachedTimeScale = PlayerPrefs.GetFloat("Scale");
    }

    // Start is called before the first frame update
    void Start()
    {
        // Manually force set the player's attributes, to avoid updating these in the inspector for every scene.
        player.ChangeForceGravityAndMoveSpeed(9, -14, 6);
        
        // Initialize the time scale setting
        // pauseController.cachedTimeScale = playerPreference.scale;
        pauseController.cachedTimeScale = PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f;
        // jumpSpeedSlider.value = playerPreference.scale;
        jumpSpeedSlider.value = PlayerPrefs.HasKey("Scale") ? PlayerPrefs.GetFloat("Scale") : 1f;
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
