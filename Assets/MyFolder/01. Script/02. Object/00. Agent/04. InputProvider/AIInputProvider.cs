using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._04._InputProvider
{
    public class AIInputProvider : IInputProvider
    {
        Camera _playerCamera;
        
        public Vector2 MousePos { get; set; }
        public Vector2 WorldMousePos => _playerCamera.ScreenToWorldPoint(MousePos);
        public Vector2 MovePos { get; set; }
        public void Initialize(AgentController agentController)
        {
            _playerCamera = Camera.main;
        }

        public void Update(float deltaTime)
        {
            throw new System.NotImplementedException();
        }
    }
}