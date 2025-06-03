using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HighscoreManager : MonoBehaviour
{
    public TextMeshProUGUI highscoreText; // Reference to the TextMeshPro component
    public int maxTopScores = 5; // Number of top scores to show prominently

    [SerializeField] private List<PlayerScore> highScores = new List<PlayerScore>();

    // Class to hold player scores
    [System.Serializable]
    public class PlayerScore
    {
        public string playerName;
        public int score;

        public PlayerScore(string name, int score)
        {
            this.playerName = name;
            this.score = score;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        // Add some dummy high scores
        highScores.Add(new PlayerScore("Player A", 100));
        highScores.Add(new PlayerScore("Player B", 90));
        highScores.Add(new PlayerScore("Player C", 80));
        highScores.Add(new PlayerScore("Player D", 70));
        highScores.Add(new PlayerScore("Player E", 60));

        // Example: Add a new score and update the highscore list
        AddNewScore("New Player", 85);
        AddNewScore("New Playe1", 55);
    }

    // Function to add a new score and update the highscore table
    public void AddNewScore(string playerName, int score)
    {
        PlayerScore newScore = new PlayerScore(playerName, score);

        // Insert the new score in the correct place in the sorted list
        highScores.Add(newScore);
        highScores.Sort((x, y) => y.score.CompareTo(x.score)); // Sort descending

        // Check if the new score is in the top list
        bool isInTop = highScores.IndexOf(newScore) < maxTopScores;

        // Update the display
        UpdateHighscoreDisplay(newScore, isInTop);
    }

    // Function to update the highscore display in TextMeshPro
    void UpdateHighscoreDisplay(PlayerScore newScore, bool isInTop)
    {
        string highscoreTextContent = "";

        // Display the top scores
        for (int i = 0; i < highScores.Count && i < maxTopScores; i++)
        {
            PlayerScore scoreEntry = highScores[i];
            if (scoreEntry == newScore && isInTop)
            {
                // Highlight the new score if it's in the top list
                highscoreTextContent += $"<b>{scoreEntry.playerName}: {scoreEntry.score}</b>\n";
            }
            else
            {
                highscoreTextContent += $"{scoreEntry.playerName}: {scoreEntry.score}\n";
            }
        }

        // If the score is not in the top, display it at the bottom with its position
        if (!isInTop)
        {
            int position = highScores.IndexOf(newScore) + 1; // 1-based position
            highscoreTextContent += $"\nYour Position: <b>{position}</b> - {newScore.playerName}: {newScore.score}";
        }

        // Update the TextMeshProUGUI text
        highscoreText.text = highscoreTextContent;
    }
}
