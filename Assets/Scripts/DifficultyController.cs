using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    public Player player;
    
    public Button easyButton;
    public Button normalButton;
    public Button hardButton;

    public Difficulties difficultySelection;

    private readonly Dictionary<string, Difficulty> difficultyDictionary = new()
    {
        {"Easy", new Difficulty(4.9f,-4,5)},
        {"Normal", new Difficulty(13,-30,8)},
        {"Hard", new Difficulty(25,-80,10)}
    };
    
    // Start is called before the first frame update
    void Start()
    {
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

    void ChangeDifficulty(string difficulty)
    {
        // Reset the player's vertical velocity to 0 to prevent the player from
        // launching insanely high to the sky when the player's current vertical
        // velocity is too high
        player.SetVelocity(0);
        
        // Apply the difficulty change
        Difficulty newDifficulty = difficultyDictionary[difficulty];
        player.ChangeForceGravityAndMoveSpeed(
            newDifficulty.JumpForce,
            newDifficulty.Gravity,
            newDifficulty.MoveSpeed
        );
        UpdateButtonColor();
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

    class Difficulty
    {
        public float JumpForce { get; set; }
        public float Gravity { get; set; }
        public float MoveSpeed { get; set; }

        public Difficulty(float jumpForce, float gravity, float moveSpeed)
        {
            JumpForce = jumpForce;
            Gravity = gravity;
            MoveSpeed = moveSpeed;
        }
    }
    
    public enum Difficulties
    {
        Easy,
        Normal, 
        Hard
    };
}
