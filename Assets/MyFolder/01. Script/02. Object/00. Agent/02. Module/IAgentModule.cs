using MyFolder._01._Script._02._Object._00._Agent._03._State;

namespace MyFolder._01._Script._02._Object._00._Agent._02._Module
{
    /// <summary>
    /// PlayerModule interface
    /// </summary>
    /// <remarks>
    /// This interface defines the methods that a player module should implement.
    /// </remarks>
    /// <author>Jin</author>
    /// <date>2023/10/12</date>
    /// <version>1.0</version>
    /// <see cref="IAgentState"/>
    /// 
    public interface IAgentModule
    {
        public void Init(AgentController agent);
        public void OnEnable();
        public void OnDisable();
        public void ChangedState(IAgentState oldstate, IAgentState newstate);
    }
}
