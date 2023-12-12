using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinding : MonoBehaviour
{
    EnemySpawner enemySpawner;
    PathwaySO waveConfig;
    List<Transform> waypoint;
    int waypointIndex = 0;

    private void Awake()
    {
        enemySpawner = FindAnyObjectByType<EnemySpawner>();
    }

    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoint = waveConfig.GetWaypoints();
        transform.position = waypoint[waypointIndex].position;
    }

    // Update is called once per frame
    void Update()
    {
        FollowPath();
    }

    private void FollowPath()
    {
        if (waypointIndex < waypoint.Count)
        {
            Vector3 targetPosition = waypoint[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position ==  targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            Destroy(gameObject);
        }
        
    }
}
