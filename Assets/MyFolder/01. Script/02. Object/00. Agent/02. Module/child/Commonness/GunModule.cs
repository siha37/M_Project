using System.Collections;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
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
        private bool _isShotPossible = true;
        private float _shotCooldown = 0.5f;
        private float _remainingShotCooldown = 0;
        public void Init(AgentController agent)
        {
            _agent = agent;
            _shotIKTf = agent.transform.Find("shotIkTf");
            _shotPivot = _shotIKTf.Find("shotPivot");
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

        public void InputActionSet(IInputProvider inputProvider)
        {
            if (inputProvider is InputProvider provider)
            {
                provider.FireStartCallback += ShotTrigger;
            }
        }

        public void Update()
        {
            if (!_isShotPossible)
            {
                _remainingShotCooldown += Time.deltaTime;
                if (_shotCooldown <= _remainingShotCooldown)
                {
                    _isShotPossible = true;
                }
            }
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

        #region ShotMethod

        private void ShotTrigger()
        {
            //예외 처리
            if(!_isShotPossible)
                return;
            
            // 총알 생성
            BulletCreate();
            
            // 슈팅 쿨타임 값 초기화
            _isShotPossible = false;
            _remainingShotCooldown = 0;
        }

        private void BulletCreate()
        {
            Quaternion rot = _shotPivot.rotation;
            Vector3 spawnPoint = _shotPivot.position;
            Object.Instantiate(_projectile, spawnPoint, rot).TryGetComponent(out Projectile newP);

            StateModule state = _agent.GetModule<StateModule>();
            newP.Init(state.GetBulletSpeed,state.GetBulletDamage);
        }

        #endregion
    }
}