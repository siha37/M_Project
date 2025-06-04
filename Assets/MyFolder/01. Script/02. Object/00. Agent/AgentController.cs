using System;
using System.Collections.Generic;
using FishNet.Object;
using MyFolder._01._Script._02._Object._00._Agent._02._Module;
using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;
using UnityEngine.InputSystem;

namespace MyFolder._01._Script._02._Object._00._Agent
{
    public class AgentController : NetworkBehaviour
    {

        #region STATE_VARIABLES

        protected AgentStateMachine StateMachine;

        #endregion

        #region Inspector_VARIABLES

        [Header("State")]
        [SerializeField] protected string currentStateName;
        
        #endregion

        #region Prefab

        [SerializeField] public GameObject projectilePrefab;

        #endregion

        #region MODULE_VARIABLES

        public bool moduleAble;
        protected Dictionary<System.Type, IAgentModule> Modules = new Dictionary<System.Type, IAgentModule>();
        protected List<IAgentTickableModule> TickableModules = new List<IAgentTickableModule>();
        protected List<IAgentColliderModule> ColliderModules = new List<IAgentColliderModule>();
        #endregion

        #region INPUTPROVIDER_VARIABLES

        protected IInputProvider InputProvider;
        public IInputProvider InputProviderInstance => InputProvider;
        
        [SerializeField] protected InputActionAsset playerInput; 
        public InputActionAsset PlayerInput
        {
            get { return playerInput;}
            private set { playerInput = value; }
        }

        #endregion
        

        
        /**********************INIT**********************/
        #region INIT
        public override void OnStartClient()
        {
            ModuleInit();
            StateInit();
            if(IsOwner)
            {
                moduleAble = true;
                InputProviderInit();
                ModuleInputDelegateInit();
            }
        }

        #endregion

        /********************Update********************/
        #region UPDATE
        private void Update()
        {
            if (!IsOwner)
            {
                Debug.Log(gameObject.name + " is no longer owned");
                moduleAble = false;
                return;
            }
            if (moduleAble)
            {
                foreach (var state in TickableModules)
                {
                    state.Update();
                }
            }
            if(InputProvider != null)
                InputProvider.Update(Time.deltaTime);
        }
        private void FixedUpdate()
        {
            if (!IsOwner)
                return;
            if (moduleAble)
            {
                foreach (var state in TickableModules)
                {
                    state.FixedUpdate();
                }
            }
        }
        #endregion
        
        #region INPUTPROVIDER

        protected virtual void InputProviderInit()
        {
            InputProvider = new AIInputProvider();
        }
        
        #endregion

        #region MODULE
        public T AddModule<T>() where T : IAgentModule, new()
        {
            System.Type type = typeof(T);
            if (Modules.ContainsKey(type))
            {
                Debug.LogError($"Already Exist Module : {type}");
                return default;
            }
            IAgentModule module = new T();

            Modules.Add(type, module);
            if (module is IAgentTickableModule tickable)
                TickableModules.Add(tickable);
            else if (module is IAgentColliderModule colliderable)
                ColliderModules.Add(colliderable);
            module.Init(this);

            return (T)module;
        }

        public void RemoveModule<T>() where T : IAgentModule
        {
            System.Type type = typeof(T);
            if (Modules.ContainsKey(type))
            {
                if (Modules[type] is IAgentTickableModule tickable)
                    TickableModules.Remove(tickable);

                Modules.Remove(type);
            }
            else
            {
                Debug.LogError($"Not Exist Module : {type}");
            }
        }

        public T GetModule<T>() where T : IAgentModule
        {
            System.Type type = typeof(T);
            if (Modules.ContainsKey(type))
            {
                return (T)Modules[type];
            }
            Debug.LogError($"Not Exist Module : {type}");
            return default;
        }
        protected virtual void ModuleInit()
        {

        }

        protected void ModuleInputDelegateInit()
        {
            foreach (KeyValuePair<Type,IAgentModule> module in Modules)
            {
                module.Value.InputActionSet(InputProvider);
            }
        }
        #endregion

        #region STATE
        public void SetState<T>() where T : IAgentState, new()
        {
            IAgentState oldState;
            IAgentState newState;
            StateMachine.ChangeState<T>(out oldState, out newState);
            currentStateName = newState.GetName();
            foreach (var module in Modules)
            {
                module.Value.ChangedState(oldState, newState);
            }
        }

        public string GetCurrentState()
        {
            return StateMachine.GetCurrentState();
        }
        protected virtual void StateInit()
        {

        }
        #endregion
        
        #region COLLIDER
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            foreach (IAgentColliderModule colliderModule in ColliderModules)
            {
                colliderModule.OnTriggerEnter2D(col);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            foreach (IAgentColliderModule colliderModule in ColliderModules)
            {
                colliderModule.OnTriggerExit2D(col);
            }
        }
        #endregion

    }
}
