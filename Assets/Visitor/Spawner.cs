using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Visitor
{
    public class Spawner: MonoBehaviour, IEnemyDeathNotifier
    {
        [SerializeField] private float _spawnCooldown;
        [SerializeField] private List<Transform> _spawnPoints;
        [SerializeField] private EnemyFactory _enemyFactory;
        [SerializeField] private int _maxEnemiesWeight = 100;
 
        private Dictionary<EnemyType, int> _weightMap;
        private List<Enemy> _spawnedEnemies = new List<Enemy>();
        private int _currentWeight;

        private Coroutine _spawn;

        public event Action<Enemy> Notified;

        public void Init()
        {
            _weightMap = new Dictionary<EnemyType, int>()
            {
                [EnemyType.Human] = 10,
                [EnemyType.Ork] = 15,
                [EnemyType.Elf] = 12,
                [EnemyType.Robot] = 30,
            };
        }
        
        public void StartWork()
        {
            _currentWeight = 0;
            StopWork();

            _spawn = StartCoroutine(Spawn());
        }

        public void StopWork()
        {
            if (_spawn != null)
                StopCoroutine(_spawn);
        }

        public void KillRandomEnemy()
        {
            if (_spawnedEnemies.Count == 0)
                return;

            Enemy randomEnemy = _spawnedEnemies[UnityEngine.Random.Range(0, _spawnedEnemies.Count)];
            randomEnemy.Kill();
            _currentWeight -= _weightMap[randomEnemy.Type];
        }

        private IEnumerator Spawn()
        {
            while (true)
            {
                if (_currentWeight >= _maxEnemiesWeight)
                    yield continue;
                
                EnemyType randomType = (EnemyType)UnityEngine.Random.Range(0, Enum.GetValues(typeof(EnemyType)).Length);
                Enemy enemy = _enemyFactory.Get(randomType);
                _currentWeight += _weightMap[randomType];
                enemy.MoveTo(_spawnPoints[UnityEngine.Random.Range(0, _spawnPoints.Count)].position);
                enemy.Died += OnEnemyDied;
                _spawnedEnemies.Add(enemy);
                
                yield return new WaitForSeconds(_spawnCooldown);
            }
        }

        private void OnEnemyDied(Enemy enemy)
        {
            Notified?.Invoke(enemy);
            enemy.Died -= OnEnemyDied;
            _spawnedEnemies.Remove(enemy);
        }
    }
}
