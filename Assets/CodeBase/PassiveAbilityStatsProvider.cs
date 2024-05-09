public class PassiveAbilityStatsProvider : IStatsProvider
{
    private IStatsProvider _statsProvider;

    private int _passiveAbilityStrengthBonus;
    private int _passiveAbilityAgilityBonus;
    private int _passiveAbilityInteligenceBonus;

    public int Strength => _statsProvider.Strength + _passiveAbilityStrengthBonus;
    public int Agility => _statsProvider.Agility + _passiveAbilityAgilityBonus;
    public int Intelligence => _statsProvider.Intelligence + _passiveAbilityInteligenceBonus;

    public PassiveAbilityStatsProvider(IStatsProvider statsProvider, int strengthPassiveBonus = 0, int agilityPassiveBonus = 0, int IntelligencePassiveBonus = 0)
    {
        _statsProvider = statsProvider;
        _passiveAbilityStrengthBonus = strengthPassiveBonus;
        _passiveAbilityAgilityBonus = agilityPassiveBonus;
        _passiveAbilityInteligenceBonus = IntelligencePassiveBonus;
    }
}
