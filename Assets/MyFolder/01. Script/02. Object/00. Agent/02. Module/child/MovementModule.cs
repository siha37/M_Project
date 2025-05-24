using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child
{
    /// <summary>
    /// AnimationController is responsible for controlling the player's animations.
    /// </summary>
    /// <remarks>
    /// This class implements the IPlayerModule interface and provides methods to handle player state changes.
    /// </remarks>
    public class MovementModule : IAgentTickableModule
    {
        AgentController _agent;
        BaseStateModule _baseStateModule;
        
        
        
        Rigidbody2D _rd;
        
        

        public void Init(AgentController agent)
        {
            this._agent = agent;
            _baseStateModule = agent.GetModule<BaseStateModule>();
            agent.TryGetComponent(out _rd);
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
            if (_rd)
                _rd.linearVelocity = _agent.InputProviderInstance.MovePos * _baseStateModule.GetMoveSpeed();
        }

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
        }

        public void InputActionSet(IInputProvider inputProvider)
        {
            
        }

        public void Jump()
        {
        }
    }
}