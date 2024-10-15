using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameOverGetScore : MonoBehaviour
{
    ScoreManager scoreManager;
    [SerializeField] TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
        ShowFinalScore();
    }

    private void ShowFinalScore()
    {
        textMeshProUGUI.text = scoreManager.GetScore().ToString();
    }

}
