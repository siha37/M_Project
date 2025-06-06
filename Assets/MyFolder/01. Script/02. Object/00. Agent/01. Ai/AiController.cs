using BehaviorDesigner.Runtime;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Enemy;
using MyFolder._01._Script._02._Object._00._Agent._03._State.child;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;
using UnityEngine.AI;

namespace MyFolder._01._Script._02._Object._00._Agent._01._Enemy
{
    public class AiController : AgentController
    {   
        
        
        #region INIT
        public override void OnStartClient()
        {
            base.OnStartClient();
            if(IsOwner)
            {
                if(TryGetComponent(out BehaviorTree behaviorTree))
                    behaviorTree.enabled = true;
            }
        }
        
        protected override void OnStart()
        {
            base.OnStart();
            
            if (TryGetComponent(out NavMeshAgent navAgent))
            {
                navAgent.updateRotation = false;
                navAgent.updateUpAxis = false;
                transform.rotation = Quaternion.identity;
            }
        }
        #endregion
                
        #region INPUTPROVIDER

        protected override void InputProviderInit()
        {
            InputProvider = new AIInputProvider();
        }
        
        #endregion

        #region MODULE

        protected override void ModuleInit()
        {
            AddModule<NavAgent2DModule>();
            AddModule<GunModule>();
            AddModule<StateModule>();
        }

        #endregion

        #region STATE

        protected override void StateInit()
        {
            base.StateInit();
            SetState<IdleState>();
        }

        #endregion
    }
}
