namespace MyFolder._01.Script._02.Object.Player.State
{
    public interface IAgentState
    {
        public void Enter(AgentController player);
        public void Update();
        public void Exit();
        public string GetName();
    }
}