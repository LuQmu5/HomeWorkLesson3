using UnityEngine;

public class OrcWarrior : MonoBehaviour, IWarrior
{
    public void Attack()
    {
        Debug.Log("Орк-воин взмахивает оружием с невероятной силой, нанося двойной урон");
    }
}
