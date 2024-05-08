using UnityEngine;

public class ElfWarrior : MonoBehaviour, IWarrior
{
    public void Attack()
    {
        Debug.Log("Изящные атаки эльфа-воина оставляют на враге глубокие кровотечения");
    }
}
