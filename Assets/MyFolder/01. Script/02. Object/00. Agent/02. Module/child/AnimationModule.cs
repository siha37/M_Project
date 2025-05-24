using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._03._State.child;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child
{
    /// <summary>
    /// AnimationController class
    /// </summary>
    /// <remarks>
    /// This class is responsible for controlling the player's animations.
    /// </remarks>
    /// <author>Jin</author>
    /// <date>2023/10/12</date>
    /// <version>1.0</version>
    /// <see cref="IAgentModule"/>
    public class AnimationModule : IAgentTickableModule
    {
        AgentController player;
        Animator animator;

        public void FixedUpdate()
        {
        }

        public void Init(AgentController agent)
        {
            this.player = agent;
            agent.TryGetComponent(out animator);
        }

        public void LateUpdate()
        {
        }

        public void OnDisable()
        {
        }

        public void OnEnable()
        {
        }

        public void Update()
        {
        }

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
            if(newstate is MoveState)
            {
                
            }
        }

        public void InputActionSet(IInputProvider inputProvider)
        {
            
        }
    }
}