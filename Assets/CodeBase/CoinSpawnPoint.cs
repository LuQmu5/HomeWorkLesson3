using UnityEngine;

public class CoinSpawnPoint : MonoBehaviour
{
    public bool HasCoin => _spawnedCoin != null;

    private Coin _spawnedCoin;

    public void Set(Coin coin)
    {
        _spawnedCoin = coin;
        _spawnedCoin.transform.position = transform.position;
        _spawnedCoin.Collected += OnCoinCollected;
    }

    private void OnCoinCollected()
    {
        _spawnedCoin.Collected -= OnCoinCollected;
        _spawnedCoin = null;
    }

    private void OnDestroy()
    {
        if (_spawnedCoin != null)
            _spawnedCoin.Collected -= OnCoinCollected;
    }
}