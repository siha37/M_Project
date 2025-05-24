using MyFolder._01._Script._02._Object._00._Agent;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._01._Projectile
{
    public class Projectile : MonoBehaviour
    {
        private float _speed;
        private float _damage;
        private Transform _tf;

        private void Start()
        {
            _tf = transform;
        }
        public void Init(float speed,float damage)
        {
            _speed = speed;
            _damage = damage;
        }

        private void FixedUpdate()
        {
            _tf?.Translate(new Vector3(0, _speed * Time.deltaTime, 0));
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (col.gameObject.CompareTag("Player") || col.gameObject.CompareTag("Enemy"))
            {
                if (col.TryGetComponent(out AgentController agent))
                {
                    Debug.Log(agent);
                }
            }
        }
    }
}