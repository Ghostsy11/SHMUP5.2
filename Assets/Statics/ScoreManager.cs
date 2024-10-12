using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{


    static ScoreManager instance;
    [Header("General Settigns")]

    [Tooltip("Current score")]
    [SerializeField] int score;

    [Tooltip("Current gold")]
    [SerializeField] int gold = 0;

    [Header("Diffeclty Settings")]
    [Tooltip("Current diffeclty")]
    [SerializeField] internal int diffeclty;


    private void Awake()
    {
        ManageForScoreKeeperSingleton();

    }

    private void ManageForScoreKeeperSingleton()
    {
        if (instance != null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }

        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }

    public void ModifyScore(int value)
    {
        score += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        // Debug.Log(score);
    }

    public void AddGold(int value)
    {
        gold += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log(score);
    }

    public void RemoveGold(int value)
    {
        gold += value;
        Mathf.Clamp(score, 0, int.MaxValue);
        //Debug.Log(score);
    }

    public int GetScore()
    {
        return score;
    }

    public int GetGold()
    {
        return gold;
    }

    public void ResetGold() { gold = 0; }
    public void ResetScore() { score = 0; }
}
