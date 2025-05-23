namespace MyFolder._01._Script._02._Object._00._Agent._03._State
{
    public interface IAgentState
    {
        public void Enter(AgentController agent);
        public void Update();
        public void Exit();
        public string GetName();
    }
}