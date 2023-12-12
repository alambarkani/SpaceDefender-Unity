using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] PathwaySO currentWave;
    void Start()
    {
        SpawnEnemy();
    }

    public PathwaySO GetCurrentWave()
    {
        return currentWave;
    }

    private void SpawnEnemy()
    {
        for (int i = 0; i < currentWave.GetEnemyCount(); i++)
        {
            Instantiate(currentWave.GetEnemyPrefab(i), currentWave.GetStart().position, Quaternion.identity, transform);
        }
    }
}
