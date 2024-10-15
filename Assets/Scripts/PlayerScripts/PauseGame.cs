using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseGame : MonoBehaviour
{
    public bool MneuOpenCloseInput { get; private set; }

    private PlayerInput playerInput;
    private InputAction _MneuOpenCloseInput;

    [SerializeField] private bool isPause;
    [SerializeField] private GameObject pauseMenu;
    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _MneuOpenCloseInput = playerInput.actions["MenuOpenClose"];
        pauseMenu.SetActive(false);


    }

    private void Update()
    {
        MneuOpenCloseInput = _MneuOpenCloseInput.WasPressedThisFrame();
        PauseUnpause();
    }


    private void PauseUnpause()
    {
        if (MneuOpenCloseInput)
        {
            if (!isPause)
            {
                Pause();
            }
            else
            {
                UnPause();
            }
        }
    }

    private void Pause()
    {
        isPause = true;
        Time.timeScale = 0f;
        pauseMenu.SetActive(true);
    }
    private void UnPause()
    {
        isPause = false;
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;

    }


}
