using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDifficiltyIncrase : MonoBehaviour
{
    [SerializeField] GameObject[] gameObjects;
    [SerializeField] float TimeToAddDifficilty;
    [SerializeField] float TimeRightNow;
    public float TimeLeftNow;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        HowLongLeftToIncraseDifficilty();
        GetRandomWave();
        MakeGameHard();
    }



    private void MakeGameHard()
    {
        TimeRightNow += Time.deltaTime;
        if (TimeRightNow > TimeToAddDifficilty)
        {
            Instantiate(gameObjects[GetRandomWave()], transform.position, Quaternion.identity);
            TimeRightNow = 0;
        }
    }

    private int GetRandomWave()
    {
        int randomIndex = Random.Range(0, 3);
        return randomIndex;

    }

    private void HowLongLeftToIncraseDifficilty()
    {
        TimeLeftNow = TimeToAddDifficilty - TimeRightNow;
    }
}
