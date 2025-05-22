using MyFolder._01.Script._02.Object.Player;
using MyFolder._01.Script._02.Object.Player.State;
using UnityEngine;

namespace Assets.MyFolder._01.Script._02.Object.Player.Module
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
        public void Init(AgentController player);
        public void OnEnable();
        public void OnDisable();
        public void ChangedState(IAgentState oldstate, IAgentState newstate);
    }
}
