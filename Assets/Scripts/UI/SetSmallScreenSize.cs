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
        Screen.SetResolution(800, 1020, FullScreenMode.Windowed);
    }
}
