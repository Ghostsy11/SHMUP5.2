using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathFinder : MonoBehaviour
{

    [Header("Getting Refrences via code")]
    [SerializeField] WaveEnemySpwner enemySpwner;
    [SerializeField] WaveConfigSO waveConfigSO;

    [Header("List Refrence From WaveConfigSO")]
    [SerializeField] List<Transform> waypoints;
    [SerializeField] int wayPointIndex = 0;

    private void Awake()
    {
        enemySpwner = FindObjectOfType<WaveEnemySpwner>();
    }
    private void Start()
    {

        waveConfigSO = enemySpwner.GetCurrentWaveSO();
        waypoints = waveConfigSO.GetWayPoints();
        transform.position = waypoints[wayPointIndex].position;
    }


    private void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (wayPointIndex < waypoints.Count)
        {
            Vector3 targetpos = waypoints[wayPointIndex].position;
            float enemySpeed = waveConfigSO.GetMoveSpeed() * Time.deltaTime;

            transform.position = Vector2.MoveTowards(transform.position, targetpos, enemySpeed);

            if (transform.position == targetpos)
            {
                wayPointIndex++;
            }

        }
        else
        {
            wayPointIndex = 0;
        }
    }
}

