using Assets.MyFolder._01.Script._02.Object.Player.Module;
using MyFolder._01.Script._02.Object.Player.State;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class AgentController : MonoBehaviour
{

    #region STATE_VARIABLES

    protected AgentStateMachine stateMachine;

    #endregion

    #region Inspector_VARIABLES

    [Header("State")]
    [SerializeField] protected string currentStateName;
    public InputActionAsset inputActionAsset;

    #endregion

    #region MODULE_VARIABLES

    public bool moduleAble = false;
    protected Dictionary<System.Type, IAgentModule> modules = new Dictionary<System.Type, IAgentModule>();
    protected List<IAgentTickableModule> tickableModules = new List<IAgentTickableModule>();
    protected List<IAgentColliderModule> colliderModules = new List<IAgentColliderModule>();
    #endregion



    #region MODULE
    public T AddModule<T>() where T : IAgentModule, new()
    {
        System.Type type = typeof(T);
        if (modules.ContainsKey(type))
        {
            Debug.LogError($"Already Exist Module : {type}");
            return default;
        }
        IAgentModule module = new T();

        modules.Add(type, module);
        if (module is IAgentTickableModule tickable)
            tickableModules.Add(tickable);
        else if (module is IAgentColliderModule colliderable)
            colliderModules.Add(colliderable);
        module.Init(this);

        return (T)module;
    }

    public void RemoveModule<T>() where T : IAgentModule
    {
        System.Type type = typeof(T);
        if (modules.ContainsKey(type))
        {
            if (modules[type] is IAgentTickableModule tickable)
                tickableModules.Remove(tickable);

            modules.Remove(type);
        }
        else
        {
            Debug.LogError($"Not Exist Module : {type}");
        }
    }

    public T GetModule<T>() where T : IAgentModule
    {
        System.Type type = typeof(T);
        if (modules.ContainsKey(type))
        {
            return (T)modules[type];
        }
        Debug.LogError($"Not Exist Module : {type}");
        return default;
    }
    protected virtual void ModuleInit()
    {

    }
    #endregion

    #region STATE
    public void SetState<T>() where T : IAgentState, new()
    {
        IAgentState oldState;
        IAgentState newState;
        stateMachine.ChangeState<T>(out oldState, out newState);
        currentStateName = newState.GetName();
        foreach (var module in modules)
        {
            module.Value.ChangedState(oldState, newState);
        }
    }

    public string GetCurrentState()
    {
        return stateMachine.GetCurrentState();
    }
    protected virtual void StateInit()
    {

    }
    #endregion

}
