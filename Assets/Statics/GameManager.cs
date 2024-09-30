using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public void LoadScene()
    {
        StaticLoadSceneFunction(1);
    }

    public void ControlTutorial()
    {
        Debug.Log("Open control tutorial panel");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    private void StaticLoadSceneFunction(int indexOfScene)
    {
        SceneManager.LoadScene(indexOfScene);
    }

}
