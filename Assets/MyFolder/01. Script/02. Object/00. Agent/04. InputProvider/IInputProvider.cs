using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public interface IInputProvider
    {
        public Vector2 MousePos { get; set; }
        public Vector2 WorldMousePos { get; }
        public Vector2 MovePos { get; set; }
        
        public void Initialize(AgentController agentController);

        public void Update(float deltaTime);
    }
}
