using UnityEngine;

public class CoinFactory
{
    private const string CoinPrefabPath = "StaticData/CoinPrefab";

    private Coin _coinPrefab;

    public CoinFactory()
    {
        _coinPrefab = Resources.Load<Coin>(CoinPrefabPath);
    }

    public Coin Get()
    {
        Coin coin = Object.Instantiate(_coinPrefab);

        return coin;
    }
}