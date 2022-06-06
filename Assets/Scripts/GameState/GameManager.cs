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
        public Dictionary<Game, int> Score { get; set; } = new Dictionary<Game, int>();

        public Dictionary<Game, int> MaxScore { get; } = new Dictionary<Game, int>()
        {
            { Game.One, 100 },
            { Game.Two, 700 },
            { Game.Three, 500 },
            { Game.Four, 200 },
            { Game.Five, 100 },
            { Game.Six, 600 }
        };

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

        public void LoadScoreForCurrentChild()
        {
            if (File.Exists(_scoreFilePath))
            {
                Debug.Log($"LOADING SCORES - Child name '{ChildName}'");
                var prevScores = File.ReadAllText(_scoreFilePath);
                var childRow = "";
                foreach (var row in prevScores.Split(Environment.NewLine))
                {
                    if (row.StartsWith(ChildName))
                    {
                        childRow = row;
                        break;
                    }
                }
                if(childRow != "")
                {
                    string[] gamesScore = childRow.Split(',');
                    Score.Clear();
                    
                    int index = 1;
                    foreach (Game game in Enum.GetValues(typeof(Game)))
                    {
                        Debug.Log("games" + game + " scor " + gamesScore[index]);
                        if (gamesScore[index].Contains("NETERMINAT"))
                        {
                            Score.Add(game, -1);
                        }
                        else
                        {
                            Score.Add(game, int.Parse(gamesScore[index]));
                        }
                        index++;
                    }
                }
                else
                {
                    Score.Clear();
                    foreach (Game game in Enum.GetValues(typeof(Game)))
                    {
                        Score.Add(game, -1);
                    }
                }
            }
        }
    
        public void SaveScoreForCurrentChild()
        {
            // Build the csv row of the child
            StringBuilder scoreRow = new StringBuilder($"{ChildName},");
            float sumAverages = 0f;
            foreach (Game game in Enum.GetValues(typeof(Game)))
            {
                scoreRow.Append(Score[game].Equals(-1) ? "NETERMINAT," : $"{Score[game]},");
                var nonNegativeScore = Score[game] < 0 ? 0 : Score[game];
                sumAverages += (float)nonNegativeScore / MaxScore[game] * 10;
            }
            float finalAvg = sumAverages / Enum.GetValues(typeof(Game)).Length;
            scoreRow.Append($"{finalAvg:F1}");

            // Save the new row with scores to csv
            if (!File.Exists(_scoreFilePath))
            {
                StringBuilder header = new StringBuilder("Nume copil,");
                for (int i = 0; i < Enum.GetValues(typeof(Game)).Length; i++)
                {
                    header.Append($"Joc {i+1},");
                }
                header.Append("Media (max. 10)");
                header.Append($"{Environment.NewLine}Scor maxim,");
                foreach (Game game in Enum.GetValues(typeof(Game)))
                {
                    header.Append($"{MaxScore[game]},");
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