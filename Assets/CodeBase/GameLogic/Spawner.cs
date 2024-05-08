using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

[RequireComponent(typeof(MeshRenderer))]
public class Spawner : MonoBehaviour
{
    [SerializeField] private RaceTypes _race;
    [SerializeField] private float _timeBetweenSpawn = 3;
    [SerializeField] private Transform _spawnPoint;
    
    private MeshRenderer _renderer;
    private EnemyFactory _enemyFactory;
    private WaitForSeconds _spawnDelay;

    public void Init(EnemyFactory enemyFactory)
    {
        _spawnDelay = new WaitForSeconds(_timeBetweenSpawn);
        _renderer = GetComponent<MeshRenderer>();

        ChangeMaterial();

        _enemyFactory = enemyFactory;

        StartCoroutine(Spawning());
    }

    private void OnMouseDown()
    {
        int currentRaceIndex = (int)_race;
        currentRaceIndex++;

        if (currentRaceIndex == Enum.GetValues(typeof(RaceTypes)).Length)
            currentRaceIndex = 0;

        _race = (RaceTypes)currentRaceIndex;
        ChangeMaterial();
    }

    private void ChangeMaterial()
    {
        switch (_race)
        {
            case RaceTypes.Orc:
                _renderer.materials[0].color = Color.green;
                break;

            case RaceTypes.Elf:
                _renderer.materials[0].color = Color.blue;
                break;
        }
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
        SpecTypes randomSpec = (SpecTypes)Random.Range(0, Enum.GetValues(typeof(SpecTypes)).Length);

        Enemy newEnemy = _enemyFactory.GetEnemyByType(_race, randomSpec);
        newEnemy.transform.position = _spawnPoint.position;
    }
}
