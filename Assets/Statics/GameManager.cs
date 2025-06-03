using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{


    [Tooltip("TutorialPanle refrenaces")]
    [SerializeField] GameObject tutorialPanle;

    ScoreManager scoreManager;
    private void Start()
    {
        scoreManager = FindObjectOfType<ScoreManager>();
    }

    public void OpenTutorialPanel()
    {
        tutorialPanle.SetActive(true);
    }
    public void CloseTutorialPanel()
    {
        tutorialPanle.SetActive(false);
    }
    public void LoadScene(int sceneIndex)
    {
        StaticLoadSceneFunction(sceneIndex);
    }

    public void GameOverResetEveryThing()
    {
        scoreManager.ResetScore();
        scoreManager.ResetGold();
        Debug.Log("Resetting EveryThing");
    }
    public void GameOverShowScene()
    {
        scoreManager.GetScore();
        Debug.Log("Moveing to game over scene");

    }

    public void ControlTutorial()
    {
        Debug.Log("Open control tutorial panel");
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quiting");
    }

    private void StaticLoadSceneFunction(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);
        Time.timeScale = 1.0f;
    }

}
