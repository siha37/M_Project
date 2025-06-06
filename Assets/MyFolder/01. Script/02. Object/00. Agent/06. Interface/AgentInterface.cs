using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using MyFolder._01._Script._02._Object._00._Agent._05._Data;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._06._Interface
{
    public class AgentInterface : MonoBehaviour
    {
        AgentController _agentController;
        [SerializeField]private AgentBaseData data;
        void Start()
        {
            if (TryGetComponent(out _agentController))
            {
                _agentController.OnStartAllCallBack += OnStartOnClient;
            } 
        }

        protected void OnStartOnClient()
        {
            data = _agentController.GetModule<StateModule>().GetBaseData;
        }
    }
}