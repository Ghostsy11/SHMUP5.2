using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{



    [Tooltip("TutorialPanle refrenaces")]
    [SerializeField] GameObject tutorialPanle;


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
        Debug.Log("Resetting EveryThing");
    }
    public void GameOverShowScene()
    {
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
    }

}
