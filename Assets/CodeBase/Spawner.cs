using System;
using System.Collections;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private EnemyTypes _enemyType;
    [SerializeField] private float _timeBetweenSpawn = 3;
    
    private WaitForSeconds _spawnDelay;

    private void Start()
    {
        _spawnDelay = new WaitForSeconds(_timeBetweenSpawn);
    }

    private IEnumerator Spawning()
    {
        while (true)
        {
            yield return _spawnDelay;

            SpawnRandomEnemy();
        }
    }

    private void SpawnRandomEnemy()
    {
        
    }
}
