using MyFolder._01._Script._02._Object._00._Agent._02._Module.child;
using MyFolder._01._Script._02._Object._00._Agent._02._Module.child.Commonness;
using MyFolder._01._Script._02._Object._00._Agent._03._State;
using MyFolder._01._Script._02._Object._00._Agent._03._State.child;
using MyFolder._01._Script._02._Object._00._Agent._04._InputProvider;
using UnityEngine;

namespace MyFolder._01._Script._02._Object._00._Agent._00._Player
{
    /// <summary>
    /// PlayerController class
    /// </summary>
    /// <remarks>
    /// This class is responsible for controlling the player's state and modules.
    /// </remarks>
    /// <author>Jin</author>
    /// <date>2023/10/12</date>
    /// <version>1.0</version>
    /// <see cref="MonoBehaviour"/>
    public class PlayerController : AgentController
    {
        /********************Property********************/


        #region PROPERTY 
        
        
        
        #endregion
        
        /********************  ********************/
        #region INIT
        public override void OnStartClient()
        {
            base.OnStartClient();
        }
        #endregion
        /********************Protected Method**********************/

        #region INPUTPROVIDER

        protected override void InputProviderInit()
        {
            InputProvider = new PlayerInputProvider();
            InputProvider.Initialize(this);
        }

        #endregion
        
        #region MODULE

        protected override void ModuleInit()
        {
            AddModule<StateModule>();
            AddModule<MovementModule>();
            AddModule<GunModule>();
        }

        #endregion

        #region STATE

        protected override void StateInit()
        {
            base.StateInit();
            SetState<IdleState>();
        }

        #endregion
        
    }
}