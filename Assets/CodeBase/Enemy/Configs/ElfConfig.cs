using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/EnemyConfig/Elf", order = 54, fileName = "Elf")]
public class ElfConfig : EnemyConfig
{
    [SerializeField] private ElfMage _magePrefab;
    [SerializeField] private ElfWarrior _warriorPrefab;

    public override Enemy MagePrefab => _magePrefab;
    public override Enemy WarriorPrefab => _warriorPrefab;
}