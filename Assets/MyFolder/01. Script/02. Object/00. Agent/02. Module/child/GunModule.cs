using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._01._Projectile;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child
{
    public class GunModule : IAgentTickableModule
    {
        private AgentController _agent;
        private Transform _shotIKTf;
        private Transform _shotPivot;
        private GameObject _projectile;
        public void Init(AgentController agent)
        {
            _agent = agent;
            _shotIKTf = agent.transform.Find("shotIkTf");
            _shotPivot = agent.transform.Find("shotPivot");
            _projectile = agent.projectilePrefab;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
        }

        public void Update()
        {
        }

        public void FixedUpdate()
        {
            Vector2 mousepos = _agent.InputProviderInstance.WorldMousePos;
            Vector2 myPos = _agent.transform.position;
            float angle = Mathf.Atan2(mousepos.y - myPos.y, mousepos.x - myPos.x) * Mathf.Rad2Deg;
            Quaternion rot = Quaternion.AngleAxis(angle - 90 ,Vector3.forward);
            _shotIKTf.rotation = rot;
        }

        public void LateUpdate()
        {
        }
        
        /*********************Add Method************************/

        #region AddMethod

        private void ShotTrigger()
        {
            
        }

        private void BulletCreate()
        {
            Quaternion rot = _shotPivot.rotation;
            Vector3 spawnPoint = _shotPivot.position;
            Object.Instantiate(_projectile, spawnPoint, rot).TryGetComponent(out Projectile newP);

            newP.Init();
        }

        #endregion
    }
}