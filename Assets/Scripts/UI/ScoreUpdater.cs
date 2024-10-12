using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreUpdater : MonoBehaviour
{
    [Header("UI refrences")]
    [Tooltip("Refrences that are managed via code")]
    [SerializeField] ScoreManager scoreManager;

    [Tooltip("Refreances managed via inspector")]
    [SerializeField] TextMeshProUGUI scoreText;

    //[Tooltip("Refreances managed via inspector")]
    //[SerializeField] TextMeshProUGUI goldText;

    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();

        scoreText.text = scoreManager.GetScore().ToString();
        //goldText.text = scoreManager.GetGold().ToString();

    }

    private void Update()
    {
        scoreText.text = scoreManager.GetScore().ToString();
        //goldText.text = scoreManager.GetGold().ToString();
    }
}
