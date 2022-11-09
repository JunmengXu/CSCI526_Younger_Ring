using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;
using System.Text;
using System.Collections.Generic;

namespace UIController
{
    public class ResultScreenController : MonoBehaviour
    {
        public GameObject resultScreen;
        
        public Player player;
    
        public Button retryButton;
        public Button selectLevelButton;

        public string nextLevelSceneStr;

        // "You used ...s" Text
        public TMP_Text result;

        // Timer text on the top right
        public TMP_Text timer;
        
        //User's avg time list
        List<List<string>> avgTimeList;
        List<List<string>> stdTimeList;
        int index;
        void Start()
        {
            // TODO: Move the Time setting to a new global controller
            Time.timeScale = 1;
            
            // At the start, hide self
            resultScreen.SetActive(false);
            
            retryButton.onClick.AddListener(ResetGame);

            selectLevelButton.onClick.AddListener(SelectLevel);

            index = SceneManager.GetActiveScene().buildIndex;
            #if UNITY_WEBGL
                Debug.Log("WebGL");
                avgTimeList = ReadCSV.Read(Application.streamingAssetsPath + "/3 - Avg Level Clear Time.csv", Encoding.Default);
                stdTimeList = ReadCSV.Read(Application.streamingAssetsPath + "/7 - Std Level Clear Time.csv", Encoding.Default);
            #else
                Debug.Log("PC");
                avgTimeList = ReadCSV.Read(Application.dataPath + "/3 - Avg Level Clear Time.csv", Encoding.Default);
                stdTimeList = ReadCSV.Read(Application.dataPath + "/7 - Std Level Clear Time.csv", Encoding.Default);
            #endif
        }
    
        void ResetGame()
        {
            SceneManager.LoadScene(nextLevelSceneStr);
        }
        void SelectLevel()
        {
            SceneManager.LoadScene("LevelMenu");
        }

        // Update is called once per frame
        void Update()
        {
            // When the player gets to the finish line, pause the game and show resultScreen
            if (player.gameover)
            {
                Time.timeScale = 0;

                double userTime = double.Parse(timer.text);
                double avgTime = double.Parse(avgTimeList[index][1]);
                double stdTime = double.Parse(stdTimeList[index][1]);
                Debug.Log("userTime: " + userTime + " avgTime: " + avgTime + " stdTime: " + stdTime);
                double p = Normal(userTime, avgTime, stdTime);
                double cnd = CND((userTime - avgTime)/stdTime);
                double percent = (1.0 - cnd) * 100;
                Debug.Log("p = " + p + " cnd = " + cnd);

                result.text = "You used " + timer.text + "s and beat " + percent.ToString("0.00") + "% of players!";
                resultScreen.SetActive(true);
            }
        }

        // Normal distribution
        public double Normal(double x, double miu, double sigma)
        {
            return 1.0 / (x * Math.Sqrt(2 * Math.PI) * sigma) * Math.Exp(-1 * (Math.Log(x) - miu) * (Math.Log(x) - miu) / (2 * sigma * sigma));
        }

        //Cumulative normal distribution function
        public static double CND(double d)
        {
            const double       A1 = 0.31938153;
            const double       A2 = -0.356563782;
            const double       A3 = 1.781477937;
            const double       A4 = -1.821255978;
            const double       A5 = 1.330274429;
            const double RSQRT2PI = 0.39894228040143267793994605993438;

            double
            K = 1.0 / (1.0 + 0.2316419 * Math.Abs(d));

            double
            cnd = RSQRT2PI * Math.Exp(- 0.5 * d * d) *
                (K * (A1 + K * (A2 + K * (A3 + K * (A4 + K * A5)))));

            if (d > 0)
                cnd = 1.0 - cnd;

            return cnd;
        }
    }
}
