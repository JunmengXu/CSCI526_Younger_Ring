using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultyController : MonoBehaviour
{
    public Player player;
    
    public Button easy;
    public Button normal;
    public Button hard;

    private readonly Dictionary<string, Difficulty> difficulties = new()
    {
        {"Easy", new Difficulty(4.9f,-4,5)},
        {"Normal", new Difficulty(13,-30,8)},
        {"Hard", new Difficulty(25,-80,10)}
    };
    
    // Start is called before the first frame update
    void Start()
    {
        easy.onClick.AddListener(delegate { ChangeDifficulty("Easy"); });
        normal.onClick.AddListener(delegate { ChangeDifficulty("Normal"); });
        hard.onClick.AddListener(delegate { ChangeDifficulty("Hard"); });
    }

    void ChangeDifficulty(string difficulty)
    {
        Difficulty newDifficulty = difficulties[difficulty];
        player.ChangeForceGravityAndMoveSpeed(
            newDifficulty.JumpForce,
            newDifficulty.Gravity,
            newDifficulty.MoveSpeed
        );
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
}
