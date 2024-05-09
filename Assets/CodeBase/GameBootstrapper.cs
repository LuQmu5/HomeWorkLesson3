using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void Awake()
    {
        StatsProvider baseStats = new StatsProvider(10, 10, 10);
        RaceStatsProvider raceStats = new RaceStatsProvider(baseStats, Races.Human);
        PassiveAbilityStatsProvider passiveAbilityStatsProvider = new PassiveAbilityStatsProvider(raceStats, agilityPassiveBonus: 3);
        SpecStatsProvider specStats = new SpecStatsProvider(passiveAbilityStatsProvider, Specs.Rogue);

        _character.Init(new CharacterStats(specStats));
    }
}
