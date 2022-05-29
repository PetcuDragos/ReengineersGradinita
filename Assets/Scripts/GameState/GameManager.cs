using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace GameState
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        private string _scoreFilePath;
    
        public string ChildName { get; set; }
        public Dictionary<Game, int> Score { get; } = new Dictionary<Game, int>();

        private void Awake()
        {
            // TODO: should only save to persistentDataPath
            _scoreFilePath = Application.dataPath + "/" + "scor_copii.csv";
            Debug.Log($"filepath:{_scoreFilePath}");
        
            Instance = this;
        
            // initialize all scores with -1
            foreach (Game game in Enum.GetValues(typeof(Game)))
                Score.Add(game, -1);
        }

        // Start is called before the first frame update
        void Start()
        {
        
        }
    
        public void SaveScoreForCurrentChild()
        {
            // Build the csv row of the child
            StringBuilder scoreRow = new StringBuilder($"{ChildName},");
            foreach (Game game in Enum.GetValues(typeof(Game)))
            {
                var score = Score[game];
                scoreRow.Append(score.Equals(-1) ? "NETERMINAT," : $"{score},");
            }

            scoreRow.Remove(scoreRow.Length - 1, 1); // Remove last comma

            // Save the new row with scores to csv
            if (!File.Exists(_scoreFilePath))
            {
                StringBuilder header = new StringBuilder("Nume copil,");
                for (int i = 0; i < Enum.GetValues(typeof(Game)).Length; i++)
                {
                    header.Append($"Joc {i+1},");
                }
                header.Remove(header.Length - 1, 1);
                File.AppendAllText(_scoreFilePath, header.ToString());
            }
        
            var prevScores = File.ReadAllText(_scoreFilePath);
            var prevRow = "";
            foreach (var row in prevScores.Split(Environment.NewLine))
            {
                if (row.StartsWith(ChildName))
                    prevRow = row;
            }

            string newScores;
            if (prevRow.Equals(""))
                newScores = prevScores + Environment.NewLine + scoreRow.ToString();
            else
                newScores = prevScores.Replace(prevRow, scoreRow.ToString());

            File.WriteAllText(_scoreFilePath, newScores);
        }

        public void ResetGame()
        {
            Debug.Log("GameManager - GAME RESET");
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public enum Game
    {
        One, Two, Three, Four, Five, Six
    }
}