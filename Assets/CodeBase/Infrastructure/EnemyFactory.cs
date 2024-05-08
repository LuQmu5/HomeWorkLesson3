using System;
using System.Collections.Generic;
using UnityEngine;
using Object = UnityEngine.Object;

public class EnemyFactory
{
    private Dictionary<RaceTypes, EnemyConfig> _configsMap;

    public EnemyFactory()
    {
        OrcConfig orcConfig = Resources.Load<OrcConfig>(AssetsPath.OrcConfigPath);
        ElfConfig elfConfig = Resources.Load<ElfConfig>(AssetsPath.ElfConfigPath);

        _configsMap = new Dictionary<RaceTypes, EnemyConfig>()
        {
            [RaceTypes.Orc] = orcConfig,
            [RaceTypes.Elf] = elfConfig,
        };
    }

    public Enemy GetEnemyByType(RaceTypes race, SpecTypes type)
    {
        switch (type)
        {
            case SpecTypes.Warrior:
                return Object.Instantiate(_configsMap[race].WarriorPrefab);

            case SpecTypes.Mage:
                return Object.Instantiate(_configsMap[race].MagePrefab);

            default:
                throw new ArgumentException($"can't find prefab for {type} type");
        }
    }
}
