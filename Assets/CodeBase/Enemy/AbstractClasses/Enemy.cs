using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    private void Start()
    {
        Destroy(gameObject, 3);
    }

    private void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime);
    }
}
