using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawners;

    private void Awake()
    {
        EnemyFactory enemyFactory = new EnemyFactory();

        foreach (var spawner in _spawners)
            spawner.Init(enemyFactory);
    }
}
