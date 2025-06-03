using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTimeSpwanMan : MonoBehaviour
{
    [Header("Requierd time to activeit the wave")]
    [SerializeField] float timeToActivietWaveSpwan1;
    [SerializeField] float timeToActivietWaveSpwan2;
    [SerializeField] float timeToActivietWaveSpwan3;
    [SerializeField] float timeToActivietWaveSpwan4;
    [SerializeField] float timeToActivietWaveSpwan5;


    [Header("Time at that moment")]
    [SerializeField] float timeRightNow1;
    [SerializeField] float timeRightNow2;
    [SerializeField] float timeRightNow3;
    [SerializeField] float timeRightNow4;
    [SerializeField] float timeRightNow5;

    [Header("Wave to be initialized")]
    [SerializeField] GameObject[] wavesGameObject;

    private void Update()
    {
        TimeToAddWave();
        TimeToAddWave1();
        TimeToAddWave2();
        TimeToAddWave3();
        TimeToAddWave4();
    }


    private void TimeToAddWave()
    {
        timeRightNow1 += Time.deltaTime;
        if (timeRightNow1 >= timeToActivietWaveSpwan1)
        {
            wavesGameObject[0].SetActive(true);
        }
    }

    private void TimeToAddWave1()
    {
        timeRightNow2 += Time.deltaTime;
        if (timeRightNow2 >= timeToActivietWaveSpwan2)
        {
            wavesGameObject[1].SetActive(true);
        }
    }

    private void TimeToAddWave2()
    {
        timeRightNow3 += Time.deltaTime;
        if (timeRightNow3 >= timeToActivietWaveSpwan3)
        {
            wavesGameObject[2].SetActive(true);
        }
    }

    private void TimeToAddWave3()
    {
        timeRightNow4 += Time.deltaTime;
        if (timeRightNow4 >= timeToActivietWaveSpwan4)
        {
            wavesGameObject[3].SetActive(true);
        }
    }

    private void TimeToAddWave4()
    {
        timeRightNow5 += Time.deltaTime;
        if (timeRightNow5 >= timeToActivietWaveSpwan5)
        {
            wavesGameObject[4].SetActive(true);
            gameObject.GetComponent<EnemyTimeSpwanMan>().enabled = false;
        }
    }

}
