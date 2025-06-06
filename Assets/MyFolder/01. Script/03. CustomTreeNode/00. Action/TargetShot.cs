using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using MyFolder._01._Script._02._Object._00._Agent._01._Enemy;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._03._CustomTreeNode._00._Action
{
    public class TargetShot : Action
    {
        public float AngleRotationSpeed = 2;
        public SharedGameObject AIObject;
        public SharedGameObject Target;
        private AiController _aiController;
 
        public override TaskStatus OnUpdate()
        {
            if (Target == null || AIObject == null)
                return TaskStatus.Failure;
            if(!AIObject.Value.TryGetComponent(out _aiController))
                return TaskStatus.Failure;

            GunModule gunModule = _aiController.GetModule<GunModule>();
            IInputProvider inputProvider = _aiController.InputProviderInstance;
            if (gunModule != null && inputProvider != null)
            {
                inputProvider.MousePos = Target.Value.transform.position;
                inputProvider.FireStarted(new InputAction.CallbackContext());
            }
            
            return TaskStatus.Success;
        }
    
        public override void OnReset()
        {
            AngleRotationSpeed = 2;
            Target = null;
        }
    }
}
