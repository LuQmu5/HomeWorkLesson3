using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private CoinSpawnPoint[] _coinSpawnPoints;

    private CoinFactory _coinFactory;

    private void Awake()
    {
        _coinFactory = new CoinFactory();

        SpawnCoins();
    }

    private void SpawnCoins()
    {
        foreach (CoinSpawnPoint coinSpawnPoint in _coinSpawnPoints)
        {
            if (coinSpawnPoint.HasCoin)
                continue;

            Coin spawnedCoin = _coinFactory.Get();
            coinSpawnPoint.Set(spawnedCoin);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.C))
            SpawnCoins();
    }
}
