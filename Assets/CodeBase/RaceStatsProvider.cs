public class RaceStatsProvider : IStatsProvider
{
    private IStatsProvider _statsProvider;

    private int _raceStrengthBonus;
    private int _raceAgilityBonus;
    private int _raceInteligenceBonus;

    public int Strength => _statsProvider.Strength + _raceStrengthBonus;
    public int Agility => _statsProvider.Agility + _raceAgilityBonus;
    public int Intelligence => _statsProvider.Intelligence + _raceInteligenceBonus;

    public RaceStatsProvider(IStatsProvider statsProvider, Races race)
    {
        _statsProvider = statsProvider;

        switch (race)
        {
            case Races.Human:
                _raceAgilityBonus = 10;
                break;

            case Races.Orc:
                _raceStrengthBonus = 10;
                break;

            case Races.Elf:
                _raceInteligenceBonus = 10;
                break;
        }
    }
}
