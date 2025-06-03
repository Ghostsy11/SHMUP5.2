using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PauseGame : MonoBehaviour
{
    [Header("Pause Menu")]
    private PlayerInput playerInput;
    public bool MneuOpenCloseInput { get; private set; }
    [SerializeField] private bool isPause;
    private InputAction _MneuOpenCloseInput;
    [SerializeField] private GameObject pauseMenu;

    [Header("Shop")]
    private PlayerInput _playerInput;
    public bool ShopOpenClose { get; private set; }
    [SerializeField] private bool _ShopOpenClose;
    private InputAction _ShopOpenCloseInput;
    [SerializeField] private GameObject shop;


    private void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        _MneuOpenCloseInput = playerInput.actions["MenuOpenClose"];
        pauseMenu.SetActive(false);

        _playerInput = GetComponent<PlayerInput>();
        _ShopOpenCloseInput = _playerInput.actions["OpenCloseShop"];
        shop.SetActive(false);
    }

    private void Update()
    {
        MneuOpenCloseInput = _MneuOpenCloseInput.WasPressedThisFrame();
        PauseUnpause();

        ShopOpenClose = _ShopOpenCloseInput.WasPressedThisFrame();
        PauseUnpasueShop();
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

    private void PauseUnpasueShop()
    {
        if (ShopOpenClose)
        {
            if (!_ShopOpenClose)
            {
                OpenShop();
            }
            else
            {
                CloseShop();
            }
        }
    }

    private void OpenShop()
    {
        _ShopOpenClose = true;
        Time.timeScale = 0f;
        shop.SetActive(true);
    }
    private void CloseShop()
    {
        _ShopOpenClose = false;
        shop.SetActive(false);
        Time.timeScale = 1f;

    }


    //void CheckPause()
    //{
    //    if (_MneuOpenCloseInput.WasPressedThisFrame())
    //    {
    //        isPause = !isPause;
    //    }
    // >> in if statmeant
    //    if (!isPause)
    //    {
    //        Pause();
    //    }
    //    else
    //    {
    //        UnPause();
    //    }
    //}

}
