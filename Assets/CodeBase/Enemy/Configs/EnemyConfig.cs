using UnityEngine;

public abstract class EnemyConfig : ScriptableObject
{
    public abstract Enemy WarriorPrefab { get; }
    public abstract Enemy MagePrefab { get; }
}
