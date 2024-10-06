using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveEnemySpwner : MonoBehaviour
{

    [Header("Waves Handler")]
    [SerializeField] List<WaveConfigSO> waveConfigs;

    [Header("Returing ref from PathFinder Script")]
    WaveConfigSO currentWave;

    [Header("Time Between Waves Handler")]
    [SerializeField] float timeBetweenWaves = 1f;
    [SerializeField] float timeVariance = 0.5f;
    [SerializeField] float minimumSpwanTime = 0.2f;

    public bool enemyWaveIsLooping;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpwanEnemies());
    }

    public WaveConfigSO GetCurrentWaveSO()
    {
        return currentWave;
    }
    public float GetRandomSpwanTimeBetweenEachWave()
    {
        float spwanTime = Random.Range(timeBetweenWaves - timeVariance, timeBetweenWaves + timeVariance);

        return Mathf.Clamp(timeVariance, minimumSpwanTime, float.MaxValue);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private IEnumerator SpwanEnemies()
    {
        do
        {
            foreach (WaveConfigSO wave in waveConfigs)
            {
                currentWave = wave;
                for (int i = 0; i < currentWave.GetGameObjCount(); i++)
                {

                    Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
                    yield return new WaitForSeconds(currentWave.GetRandomSpwanTimeBetweenEachEnemy());
                    Debug.Log(currentWave.GetRandomSpwanTimeBetweenEachEnemy());

                }
            }
            yield return new WaitForSeconds(GetRandomSpwanTimeBetweenEachWave());
        } while (enemyWaveIsLooping);
    }

}



//while (enemyWaveIsLooping)
//{
//    foreach (WaveConfigSO wave in waveConfigs)
//    {
//        currentWave = wave;
//        for (int i = 0; i < currentWave.GetGameObjCount(); i++)
//        {

//            Instantiate(currentWave.GetEnemyPrefabs(i), currentWave.GetStartingWayPoint().position, Quaternion.identity, transform);
//            yield return new WaitForSeconds(currentWave.GetRandomSpwanTimeBetweenEachEnemy());
//        }
//    }
//    yield return new WaitForSeconds(GetRandomSpwanTimeBetweenEachWave());
//}