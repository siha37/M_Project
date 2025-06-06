using MyFolder._01._Script._02._Object._00._Agent;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._01._Projectile
{
    public class Projectile : MonoBehaviour
    {
        private float _speed;
        private float _damage;
        private Transform _tf;
        [SerializeField] private LayerMask _hitLayer;
        [SerializeField] private LayerMask _isDamageLayer;
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
            if ((_isDamageLayer & (1 << col.gameObject.layer)) != 0)
            {
                if (col.TryGetComponent(out AgentController agent))
                {
                    agent.GetModule<StateModule>().GetSetCurrentHp -= _damage;
                    Destroy(this.gameObject);
                }
            }
            else if ((_hitLayer & (1 << col.gameObject.layer)) != 0)
            {
                Destroy(this.gameObject);
            }
        }
    }
}