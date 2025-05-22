using MyFolder._01.Script._02.Object.Player;
using MyFolder._01.Script._02.Object.Player.State;
using MyFolder._01.Script._02.Object.Player.State.child;
using UnityEngine;

namespace Assets.MyFolder._01.Script._02.Object.Player.Module.child
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

        public void Init(AgentController player)
        {
            this.player = player;
            player.TryGetComponent(out animator);
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

    }
}