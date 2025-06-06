using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public class PlayerInputProvider : InputProvider
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
     
        #region INPUT_VALUE
        public override Vector2 WorldMousePos => _playerCamera.ScreenToWorldPoint(MousePos);
        #endregion


        #region INIT

        public override void Initialize(AgentController controller)
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

        public override void Update(float deltaTime)
        {
            if (!_playerInput)
                return;
            MousePos = _mouseAction.ReadValue<Vector2>();
            MovePos = _moveAction.ReadValue<Vector2>();
        }

        #endregion


    }
}