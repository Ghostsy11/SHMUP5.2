using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetSmallScreenSize : MonoBehaviour
{
    void Start()
    {
        SetR();
    }

    public void SetR()
    {
        Screen.SetResolution(2560, 1440, FullScreenMode.FullScreenWindow);
    }
}
