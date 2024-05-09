using UnityEngine;

public class Character : MonoBehaviour
{
    private CharacterStats _stats;

    public void Init(CharacterStats stats)
    {
        _stats = stats;
        _stats.Show();
    }
}
