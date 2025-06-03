using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Wave Config", fileName = "New Wave Config")]


public class WaveConfigSO : ScriptableObject
{
    [Header("Prefabs Releated")]
    [SerializeField] List<GameObject> enemyGameObjects = new List<GameObject>();
    [SerializeField] Transform pathPrefab;


    [Header("Initializing Lists")]
    [SerializeField] List<Transform> wayPoints = new List<Transform>();
    [SerializeField] int listIndexLimitaion = 3;

    [Header("Enemy Related")]
    [SerializeField] float evemyMoveSpeed;

    [Header("Time Between each enemy")]
    [Tooltip("Returning time between each enemy")]
    [SerializeField] float timeBetweenEnemySpwans = 1f;
    [SerializeField] float spwanTimeVariance = 0f;
    [SerializeField] float minimumSpwanTime = 0.2f;

    public Transform GetStartingWayPoint()
    {
        return pathPrefab.GetChild(0);
    }

    public List<Transform> GetWayPoints()
    {
        if (wayPoints.Count < listIndexLimitaion)
        {
            foreach (Transform child in pathPrefab)
            {
                wayPoints.Add(child);
            }
        }
        return wayPoints;
    }

    public int GetGameObjCount()
    {
        return enemyGameObjects.Count;
    }

    public GameObject GetEnemyPrefabs(int enemyPrefabIndex)
    {
        return enemyGameObjects[enemyPrefabIndex];
    }

    public float GetMoveSpeed()
    {
        return evemyMoveSpeed;
    }

    public float GetRandomSpwanTimeBetweenEachEnemy()
    {
        float spwanTime = Random.Range(timeBetweenEnemySpwans - spwanTimeVariance, timeBetweenEnemySpwans + spwanTimeVariance);

        return Mathf.Clamp(spwanTimeVariance, minimumSpwanTime, float.MaxValue);

    }
}
