using MyFolder._01.Script._02.Object.Player.State;
using UnityEngine;

namespace Assets.MyFolder._01.Script._02.Object.Player.Module.child
{
    /// <summary>
    /// AnimationController is responsible for controlling the player's animations.
    /// </summary>
    /// <remarks>
    /// This class implements the IPlayerModule interface and provides methods to handle player state changes.
    /// </remarks>
    public class MovementModule : IAgentTickableModule
    {
        AgentController player;
        Rigidbody2D rd;

        public void Init(AgentController player)
        {
            this.player = player;
            player.TryGetComponent(out rd);
        }

        public void FixedUpdate()
        {
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
        }

        public void Jump()
        {
        }
    }
}