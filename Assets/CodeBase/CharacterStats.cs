using UnityEngine;

public class CharacterStats
{
    private IStatsProvider _statsProvider;

    public CharacterStats(IStatsProvider statsProvider)
    {
        _statsProvider = statsProvider;
    }

    public void Show()
    {
        Debug.Log($"Strength: {_statsProvider.Strength}\nAgility: {_statsProvider.Agility}\nIntelligence: {_statsProvider.Intelligence}");
    }
}
