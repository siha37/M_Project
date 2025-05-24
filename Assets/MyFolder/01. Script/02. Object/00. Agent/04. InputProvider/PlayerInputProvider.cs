using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public class PlayerInputProvider : IInputProvider
    {
        #region Other

        private Camera _playerCamera;

        #endregion
        
        #region INPUTSYSTEM_VARIABLES

        private InputActionAsset _playerInput;
        private InputAction _mouseAction;
        private InputAction _moveAction;
        private InputAction _interactAction;
        private InputAction _fireAction;

        #endregion
        
        #region OUTPUT_VARIABLES
        
        public Vector2 MousePos { get; set; }
        public Vector2 WorldMousePos => _playerCamera.ScreenToWorldPoint(MousePos);
        public Vector2 MovePos { get; set; }
        
        #endregion
        
        #region DELEGATES
        
        public delegate void VoidCallback();
        public VoidCallback InteractStartCallback; 
        public VoidCallback InteractEndCallback;
        public VoidCallback FireStartCallback;
        public VoidCallback FireEndCallback;
        
        #endregion

        #region INIT

        public void Initialize(AgentController controller)
        {
            _playerCamera = Camera.main;
                
                
            _playerInput = controller.PlayerInput;
            _mouseAction = _playerInput["Tracking"];
            _moveAction = _playerInput["Move"];
            _interactAction = _playerInput["Interact"];
            _fireAction = _playerInput["Attack"];
            
            _interactAction.started += InteractStarted;
            _interactAction.canceled += InteractEnded;
            _fireAction.started += FireStarted;
            _fireAction.canceled += FireEnded;
            
        }

        #endregion

        #region UPDATE

        public void Update(float deltaTime)
        {
            if (!_playerInput)
                return;
            MousePos = _mouseAction.ReadValue<Vector2>();
            MovePos = _moveAction.ReadValue<Vector2>();
        }

        #endregion

        #region EventMethod

        private void InteractStarted(InputAction.CallbackContext context)
        {
            InteractStartCallback?.Invoke();
        }

        private void InteractEnded(InputAction.CallbackContext context)
        {
            InteractEndCallback?.Invoke();
        }

        private void FireStarted(InputAction.CallbackContext context)
        {
            FireStartCallback?.Invoke();
        }

        private void FireEnded(InputAction.CallbackContext context)
        {
            FireEndCallback?.Invoke();
        }
        
        #endregion
    }
}