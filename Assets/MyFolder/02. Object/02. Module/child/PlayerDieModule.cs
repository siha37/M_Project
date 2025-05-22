using Assets.MyFolder._01.Script._02.Object.Player.Module;
using MyFolder._01.Script._02.Object.Player.State;
using MyFolder._01.Script._02.Object.Player.State.child;

namespace MyFolder._01.Script._02.Object.Player.Module.child
{
    public class PlayerDieModule : IAgentModule
    {
        private AgentController player;
        public void Init(AgentController player)
        {
            this.player = player;
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