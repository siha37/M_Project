using MyFolder._01._Script._02._Object._00._Agent._00._Player;

namespace MyFolder._01._Script._02._Object._00._Agent._03._State.child
{
    public class DieState : IAgentState
    {
        private PlayerController player;
        public void Enter(AgentController agent)
        {
        }

        public void Update()
        {
            
        }

        public void Exit()
        {
            
        }

        public string GetName()
        {
            return this.GetType().Name;
        }

    }
}