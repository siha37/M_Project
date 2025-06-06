using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public interface IInputProvider
    {
        #region INPUT_VALUE
        
        public Vector2 MousePos { get; set; }
        public Vector2 WorldMousePos { get; }
        public Vector2 MovePos { get; set; }
        
        #endregion
        public void Initialize(AgentController agentController);

        public void Update(float deltaTime);

        public void InteractStarted(InputAction.CallbackContext context);
        public void InteractEnded(InputAction.CallbackContext context);
        public void FireStarted(InputAction.CallbackContext context);
        public void FireEnded(InputAction.CallbackContext context);
    }
}
