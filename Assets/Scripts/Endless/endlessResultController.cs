using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Networking;
using System;
using System.Text;
using System.Xml;
using System.IO;
using System.Collections;
using System.Collections.Generic;

public class endlessResultController : MonoBehaviour
{
    public GameObject resultScreen;
        
    public endlessPlayer player;

    public Button retryButton;
    public Button selectLevelButton;

    // "You score is " Text
    public TMP_Text result;

    // Score text on the top left
    public TMP_Text score;

    // Set player's name
    [SerializeField] public TMP_Text playerName;
    public Button confirmNameButton;
    private string playername = "player";
    
    // leaderboard socre list

    public TMP_Text leaderboard;

    void Start()
    {
        // TODO: Move the Time setting to a new global controller
        Time.timeScale = 1;
        
        // At the start, hide self
        resultScreen.SetActive(false);
        
        retryButton.onClick.AddListener(ResetGame);

        selectLevelButton.onClick.AddListener(SelectLevel);

        confirmNameButton.onClick.AddListener(confirmName);

        GetHighScores();
    }

    void ResetGame()
    {
        // updateLeaderBoard();
        int playerScore = int.Parse(score.text);
        AddScore(playername, playerScore);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        
    }

    void SelectLevel()
    {
        SceneManager.LoadScene("LevelMenu");
    }

    void confirmName()
    {
        playername = playerName.text;
        playername.Trim();
        if(string.IsNullOrEmpty(playername)){
            playername = "player";
        }
        ResetGame();
    }


    void AddScore(string name, int score)
    {
        int newScore;
        string newName;
        int oldScore;
        string oldName;
        newScore = score;
        newName = name;
        for(int i=0;i<15;i++){
            if(PlayerPrefs.HasKey(i+"HScore")){
                if(PlayerPrefs.GetInt(i+"HScore")<newScore){ 
                    // new score is higher than the stored score
                    oldScore = PlayerPrefs.GetInt(i+"HScore");
                    oldName = PlayerPrefs.GetString(i+"HScoreName");
                    PlayerPrefs.SetInt(i+"HScore",newScore);
                    PlayerPrefs.SetString(i+"HScoreName",newName);
                    newScore = oldScore;
                    newName = oldName;
                }
            }else{
                PlayerPrefs.SetInt(i+"HScore",newScore);
                PlayerPrefs.SetString(i+"HScoreName",newName);
                newScore = 0;
                newName = "";
            }
        }
    }

    void GetHighScores()
    {
        string result = "";
        for(int i = 0; i < 15; i++)
        {
            // List<string> playerlist = new List<string>();
            string cur = "";

            int score = PlayerPrefs.GetInt(i + "HScore");
            string name = PlayerPrefs.GetString(i + "HScoreName");

            cur += (i+1);
            while(cur.Length<7){
                cur += " ";
            }
            cur += score;
            while(cur.Length<14){
                cur += " ";
            }
            cur += name + "\n";
            result += cur;

        }
        leaderboard.text = result;
        
    }

    // Update is called once per frame
    void Update()
    {
        // When the player gets to the finish line, pause the game and show resultScreen
        if (player.gameover)
        {
            Time.timeScale = 0;
            result.text = "You score is " + score.text + " !";
            resultScreen.SetActive(true);
        }
    }
}
