using System;
using UnityEngine;

namespace Assets.Visitor
{
    public abstract class Enemy: MonoBehaviour
    {
        [SerializeField] private EnemyType _type;

        public EnemyType Type => _type;
        
        public event Action<Enemy> Died;

        //Какая то общая логика врага: передвижение, жизни и тп.

        public void MoveTo(Vector3 position) => transform.position = position;

        public void Kill()
        {
            Died?.Invoke(this);
            Destroy(gameObject);
        }
    }
}
