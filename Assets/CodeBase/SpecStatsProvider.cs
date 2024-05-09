public class SpecStatsProvider : IStatsProvider
{
    private IStatsProvider _statsProvider;

    private int _specStrengthMultiplier = 1;
    private int _specAgilityMultiplier = 1;
    private int _specInteligenceMultiplier = 1;

    public int Strength => _statsProvider.Strength * _specStrengthMultiplier;
    public int Agility => _statsProvider.Agility * _specAgilityMultiplier;
    public int Intelligence => _statsProvider.Intelligence * _specInteligenceMultiplier;

    public SpecStatsProvider(IStatsProvider statsProvider, Specs spec)
    {
        _statsProvider = statsProvider;

        switch (spec)
        {
            case Specs.Rogue:
                _specAgilityMultiplier = 2;
                break;

            case Specs.Warrior:
                _specStrengthMultiplier = 2;
                break;

            case Specs.Mage:
                _specInteligenceMultiplier = 2;
                break;
        }
    }
}
