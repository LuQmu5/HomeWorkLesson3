public class StatsProvider : IStatsProvider
{
    private int _strength;
    private int _agility;
    private int _intelligence;

    public int Strength => _strength;
    public int Agility => _agility;
    public int Intelligence => _intelligence;

    public StatsProvider(int strength, int agility, int intelligence)
    {
        _strength = strength;
        _agility = agility;
        _intelligence = intelligence;
    }
}
