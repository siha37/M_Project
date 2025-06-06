using BehaviorDesigner.Runtime.Tasks.Unity.UnityGameObject;
using FishNet.Object;
using MyFolder._01._Script._02._Object._00._Agent._00._Player;
using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._03._State.child;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using MyFolder._01._Script._02._Object._00._Agent._05._Data;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness
{
    class StateModule : IAgentModule
    {
        #region COMPONENT

        private AgentController _agentController;
        
        #endregion
        #region DATA

        private AgentBaseData _baseData = new();
        #region DATAPROPERTIES
        //DATACLASS
        public AgentBaseData GetBaseData => _baseData;
        
        //HP
        public float GetMaxHp => _baseData.MaxHP;
        public float GetSetCurrentHp
        {
            get { return _baseData.CurrentHP; }
            set
            {
                if (_agentController.IsOwner)
                {
                    _baseData.CurrentHP = value;
                    OnHitCallback?.Invoke(); 
                    OnHitCallbackRf?.Invoke(value);
                }
            }
        }
        
        //MOVEMENT
        public float GetMoveSpeed => _baseData.MoveSeed;
        
        //BULLET
        public float GetBulletSpeed => _baseData.BulletSpeed;
        public float GetBulletDamage => _baseData.BulletDamage;
        
        #endregion

        #endregion
        
        #region CALLBACK

        public delegate void VoidCallback();
        public delegate void VoidCallbackRf(float value);
        public VoidCallback OnHitCallback;
        public VoidCallbackRf OnHitCallbackRf;
        
        
        #endregion
        
        #region INIT
        
        public void Init(AgentController agent)
        {
            _agentController = agent;
            GetSetCurrentHp = GetMaxHp;
            OnHitCallback += HP_Zero;
        }

        #endregion
        
        

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
            
        }
        public void InputActionSet(IInputProvider inputProvider)
        {
            
        }
        public void OnDisable()
        {
        }

        public void OnEnable()
        {
        }

        #region ACTIONS

        private void HP_Zero()
        {
            if (GetSetCurrentHp <= 0)
            {
                _agentController.SetState<DieState>();
            }
        }

        #endregion

    }
}
