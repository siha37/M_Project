using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public class InputProvider : IInputProvider
    {
        #region INPUT_VALUE
        public Vector2 MousePos { get; set; }
        public virtual Vector2 WorldMousePos => MousePos;
        public Vector2 MovePos { get; set; }
        
        #endregion
        
        #region DELEGATES
        
        public delegate void VoidCallback();
        public VoidCallback InteractStartCallback; 
        public VoidCallback InteractEndCallback;
        public VoidCallback FireStartCallback;
        public VoidCallback FireEndCallback;
        
        #endregion
        
        public virtual void Initialize(AgentController agentController)
        {
            
        }

        public virtual void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
        
        #region EventMethod

        public void InteractStarted(InputAction.CallbackContext context)
        {
            InteractStartCallback?.Invoke();
        }

        public void InteractEnded(InputAction.CallbackContext context)
        {
            InteractEndCallback?.Invoke();
        }

        public void FireStarted(InputAction.CallbackContext context)
        {
            FireStartCallback?.Invoke();
        }

        public void FireEnded(InputAction.CallbackContext context)
        {
            FireEndCallback?.Invoke();
        }
        
        #endregion
    }
}