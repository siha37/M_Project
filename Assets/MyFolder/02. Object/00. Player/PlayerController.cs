using System.Collections.Generic;
using Assets.MyFolder._01.Script._02.Object.Player.Module;
using Assets.MyFolder._01.Script._02.Object.Player.Module.child;
using MyFolder._01.Script._02.Object.Player.State;
using MyFolder._01.Script._02.Object.Player.State.child;
using UnityEngine;
using UnityEngine.InputSystem;
namespace MyFolder._01.Script._02.Object.Player
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
        private float backgroundSpeed = 1f;
        [SerializeField] private float dashMultiplier = 3f; 

        [SerializeField] private SpriteRenderer spriteObject;
        public SpriteRenderer SpriteObject => spriteObject; 
        
        #endregion
        
        /********************  ********************/
        #region INIT
        private void Start()
        {
            ModuleInit();
            StateInit();
        }

        #endregion

        /********************Ʈ  Լ********************/
        #region UPDATE
        private void Update()
        {
            if (moduleAble)
            {
                foreach (var state in tickableModules)
                {
                    state.Update();
                }
            }
        }
        private void FixedUpdate()
        {
            if (moduleAble)
            {
                foreach (var state in tickableModules)
                {
                    state.FixedUpdate();
                }
            }
        }
        #endregion

        /********************Public  Լ*********************/

        #region STATE



        #endregion
        


        /********************Private  Լ**********************/

        #region MODULE

        protected override void ModuleInit()
        {
            AddModule<PlayerStatsModule>();
            AddModule<MovementModule>();
        }

        #endregion

        #region STATE

        protected override void StateInit()
        {
            stateMachine = new AgentStateMachine(this);
            SetState<StartState>();
        }

        #endregion
        
        #region COLLIDER
        
        private void OnTriggerEnter2D(Collider2D col)
        {
            foreach (IAgentColliderModule colliderModule in colliderModules)
            {
                colliderModule.OnTriggerEnter2D(col);
            }
        }

        private void OnTriggerExit2D(Collider2D col)
        {
            foreach (IAgentColliderModule colliderModule in colliderModules)
            {
                colliderModule.OnTriggerExit2D(col);
            }
        }
        #endregion
    }
}