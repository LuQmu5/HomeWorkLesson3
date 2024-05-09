using UnityEngine;

public class GameBootstrapper : MonoBehaviour
{
    [SerializeField] private Character _character;

    private void Awake()
    {
        StatsProvider baseStats = new StatsProvider(10, 10, 10);
        RaceStatsProvider raceStats = new RaceStatsProvider(baseStats, Races.Human);
        SpecStatsProvider specStats = new SpecStatsProvider(raceStats, Specs.Rogue);
        PassiveAbilityStatsProvider passiveAbilityStatsProvider = new PassiveAbilityStatsProvider(specStats, agilityPassiveBonus: 3);

        _character.Init(new CharacterStats(passiveAbilityStatsProvider));
    }
}
