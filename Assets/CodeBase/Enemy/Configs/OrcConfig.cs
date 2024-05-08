using UnityEngine;

[CreateAssetMenu(menuName = "StaticData/EnemyConfig/Orc", order = 54, fileName = "Orc")]
public class OrcConfig : EnemyConfig
{
    [SerializeField] private OrcMage _magePrefab;
    [SerializeField] private OrcWarrior _warriorPrefab;

    public override Enemy MagePrefab => _magePrefab;
    public override Enemy WarriorPrefab => _warriorPrefab;
}
