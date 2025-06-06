using MyFolder._01._Script._02._Object._00._Agent;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using UnityEngine;
using UnityEngine.UI;

namespace MyFolder._01._Script._04._UI._03._Agent
{
    public class UI_AgentHp : MonoBehaviour
    {
        private AgentController _agentController;
        private StateModule     _stateModule;

        [SerializeField]
        private Image           frontBar;
        [SerializeField]
        private Image           backBar; 
        
        void Start()
        {
            if (transform.root.TryGetComponent(out _agentController))
            {
                _agentController.OnStartAllCallBack += OnStartOnClient;
            } 
        }

        void OnStartOnClient()
        {
            _stateModule = _agentController.GetModule<StateModule>();
            if (_stateModule != null)
            {
                OnHpValueChange();
                _stateModule.OnHitCallback += OnHpValueChange;
            }
        }

        private void Update()
        {
            backBar.fillAmount = Mathf.Lerp(backBar.fillAmount, frontBar.fillAmount, Time.deltaTime * 2);
        }
        
        private void OnHpValueChange()
        {
            frontBar.fillAmount = _stateModule.GetSetCurrentHp / _stateModule.GetMaxHp;
        }
        
    }
}
