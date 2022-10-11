using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using PauseScreenScripts;

public class DifficultyController : MonoBehaviour
{
    public Player player;
    
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;

    public PauseController pauseController;

    public Difficulties difficultySelection;
    
    // Using time scale to control the player speed, i.e. difficulty
    // Credit: Xiao Li
    private readonly Dictionary<string, float> difficultyDictionary = new()
    {
        {"Easy", 0.5f},
        {"Normal", 1f},
        {"Hard", 1.5f}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        // Manually force set the player's attributes, to avoid updating these in the inspector for every scene.
        player.ChangeForceGravityAndMoveSpeed(9, -14, 6);
        
        // Setup onClick listeners for the difficulty buttons
        easyButton.onClick.AddListener(delegate
        {
            difficultySelection = Difficulties.Easy;
            ChangeDifficulty("Easy");
        });
        normalButton.onClick.AddListener(delegate
        {
            difficultySelection = Difficulties.Normal;
            ChangeDifficulty("Normal");
        });
        hardButton.onClick.AddListener(delegate
        {
            difficultySelection = Difficulties.Hard;
            ChangeDifficulty("Hard");
        });
        
        // Default the difficulty to normal
        difficultySelection = Difficulties.Normal;
        UpdateButtonColor();
    }

    private void Update()
    {
        // When exit pause state, if not during tutorial, retain the current difficulty setting
        if (Math.Abs(Time.timeScale - pauseController.cachedTimeScale) > 0)
        {
            if (Time.timeScale != 0)
            {
                Time.timeScale = pauseController.cachedTimeScale;
            }
        }
    }

    void ChangeDifficulty(string difficulty)
    {
        // Apply the difficulty change
        float difficultyScale = difficultyDictionary[difficulty];
        pauseController.cachedTimeScale = difficultyScale;
        UpdateButtonColor();
        
        // Automatically resume the game
        pauseController.backToGame();
    }

    // TODO: Remove hard coded logic
    // Hard coded selected button color, will refactor later
    private void UpdateButtonColor()
    {
        switch (difficultySelection)
        {
            case Difficulties.Easy:
                var easyButtonColors = easyButton.colors;
                easyButtonColors.normalColor = Color.yellow;
                easyButton.colors = easyButtonColors;
                ResetButtonColor(normalButton);
                ResetButtonColor(hardButton);
                break;
            case Difficulties.Normal:
                var normalButtonColors = normalButton.colors;
                normalButtonColors.normalColor = Color.yellow;
                normalButton.colors = normalButtonColors;
                ResetButtonColor(easyButton);
                ResetButtonColor(hardButton);
                break;
            case Difficulties.Hard:
                var hardButtonColors = hardButton.colors;
                hardButtonColors.normalColor = Color.yellow;
                hardButton.colors = hardButtonColors;
                ResetButtonColor(easyButton);
                ResetButtonColor(normalButton);
                break;
        }
    }

    void ResetButtonColor(Button button)
    {
        var buttonColors = button.colors;
        buttonColors.normalColor = Color.white;
        button.colors = buttonColors;
    }

    public enum Difficulties
    {
        Easy,
        Normal, 
        Hard
    };
}
