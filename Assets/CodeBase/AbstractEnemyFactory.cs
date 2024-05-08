using System;
using UnityEngine;

public abstract class AbstractEnemyFactory
{
    public abstract IEnemy GetEnemyByType(EnemyTypes type);
}

public class OrcEnemyFactory : AbstractEnemyFactory
{
    private const string OrcConfigPath = "StaticData/EnemyConfigs/OrcConfig";

    private OrcConfig _orcConfig;

    public OrcEnemyFactory()
    {
        _orcConfig = Resources.Load<OrcConfig>(OrcConfigPath);
    }

    public override IEnemy GetEnemyByType(EnemyTypes type)
    {
        switch (type)
        {
            case EnemyTypes.Warrior:
                return _orcConfig.WarriorPrefab;

            case EnemyTypes.Mage:
                return _orcConfig.MagePrefab;

            default:
                throw new ArgumentException($"can't find prefab for {type} type");
        }
    }
}

public class ElfEnemyFactory : AbstractEnemyFactory
{
    private const string ElfConfigPath = "StaticData/EnemyConfigs/ElfConfig";

    private ElfConfig _elfConfig;

    public ElfEnemyFactory()
    {
        _elfConfig = Resources.Load<ElfConfig>(ElfConfigPath);
    }

    public override IEnemy GetEnemyByType(EnemyTypes type)
    {
        switch (type)
        {
            case EnemyTypes.Warrior:
                return _elfConfig.WarriorPrefab;

            case EnemyTypes.Mage:
                return _elfConfig.MagePrefab;

            default:
                throw new ArgumentException($"can't find prefab for {type} type");
        }
    }
}

[CreateAssetMenu(menuName = "StaticData/EnemyConfigs/OrcConfig", fileName = "OrcConfig", order = 54)]
public class OrcConfig : ScriptableObject
{
    [field: SerializeField] public OrcMage MagePrefab { get; private set; }
    [field: SerializeField] public OrcWarrior WarriorPrefab { get; private set; }
}

[CreateAssetMenu(menuName = "StaticData/EnemyConfigs/ElfConfig", fileName = "ElfConfig", order = 54)]
public class ElfConfig : ScriptableObject
{
    [field: SerializeField] public ElfMage MagePrefab { get; private set; }
    [field: SerializeField] public ElfWarrior WarriorPrefab { get; private set; }
}