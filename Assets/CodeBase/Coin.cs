using System;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public event Action Collected;

    private void OnMouseDown()
    {
        Collected?.Invoke();
        Destroy(gameObject);
    }
}
