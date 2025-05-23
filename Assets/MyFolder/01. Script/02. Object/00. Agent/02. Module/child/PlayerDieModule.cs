using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._03._State.child;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module.child
{
    public class PlayerDieModule : IAgentModule
    {
        private AgentController _player;
        public void Init(AgentController agent)
        {
            this._player = agent;
        }

        public void OnEnable()
        {
        }

        public void OnDisable()
        {
        }

        public void ChangedState(IAgentState oldstate, IAgentState newstate)
        {
            if (newstate is DieState)
            {
            }
            else if(oldstate is DieState)
            {
                
            }
        }
    }
}