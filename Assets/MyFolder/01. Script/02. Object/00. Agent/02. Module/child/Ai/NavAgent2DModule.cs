using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine.AI;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Enemy
{
    public class NavAgent2DModule : IAgentModule
    {
        public void Init(AgentController agent)
        {
            if (agent.TryGetComponent(out NavMeshAgent navAgent))
            {
                navAgent.updateRotation = false;
                navAgent.updateUpAxis = false;
            }
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
        }
    }
}