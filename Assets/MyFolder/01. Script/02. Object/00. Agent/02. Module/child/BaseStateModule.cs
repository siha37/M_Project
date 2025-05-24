using System.Numerics;
using MyFolder._01._Script._02._Object._00._Agent._00._Player;
using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using MyFolder._01._Script._02._Object._00._Agent._05._Data;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child
{
    class BaseStateModule : IAgentModule
    {
        #region DATA

        public AgentBaseData BaseData = new();

        #endregion

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
            
        }

        public void InputActionSet(IInputProvider inputProvider)
        {
            
        }

        public void Init(PlayerController player)
        {
        }

        public void OnDisable()
        {
        }

        public void OnEnable()
        {
        }

        public void Init(AgentController agent)
        {
        }

        public float GetMoveSpeed()
        {
            return BaseData.MoveSeed;
        }

        public float GetMaxHp()
        {
            return BaseData.MaxHP;
        }

        public float GetBulletSpeed()
        {
            return BaseData.BulletSpeed;
        }
        public float GetBulletDamage()
        {
            return BaseData.BulletDamage;
        }
        
    }
}
